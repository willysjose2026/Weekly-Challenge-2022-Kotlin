/*
 * Reto #30: MARCO DE PALABRAS
 * FÁCIL | Publicación: 26 / 07 / 22 | Resolución: 01 / 08 / 22
 * 
 * Crea una función que reciba un texto y muestre cada palabra en una línea,
 * formando un marco rectangular de asteriscos.
 * - ¿Qué te parece el reto? Se vería así:
 *   **********
 *   * ¿Qué   *
 *   * te     *
 *   * parece *
 *   * el     *
 *   * reto?  *
 *   **********
 *   
 *   Nuestra solucion: separar las palabras con un split basado en espacios en blanco y utilizar LINQ para filtrar los
 *   espacios vacios, luego conseguir el length del string mas largo del array para crear el marco, esto en principio lo
 *   hice creando un array de enteros, llenandolo con el length de todas las palabras, sorteandolo y devolviendo el ultimo
 *   elemento, ESTE PROCESO FUE SIMPLIFICADO por una variable maxLength que cambiaba cada vez que el length de una palabra
 *   superaba el valor de esta variable en un bucle foreach (TOMADO DE MAURE DEV)
 *   
 *   luego se crea una variable para representar el top y bottom del frame usando maxlength, se printea esta variable, 
 *   luego con un foreach y una variable para editar, igualamos la variable a la palabra a printear, y si su length es
 *   menor al length maximo, se le suma la cantidad de espacios faltantes al final y se printea.
 *   
 *   COMPARACION CON MAURE DEV (ver notas en el codigo)
 *   se cambio la forma de conseguir el length maximo por una que a su vez mejora el performance.
 */
using System.Diagnostics.Tracing;

internal class Program
{
    private static void Main(string[] args)
    {
        DrawTextFrame("¿Qué te parece el reto?");
        DrawTextFrame("¿Qué te     parece el reto?");
        DrawTextFrame("¿Cuántos retos de código de la comunidad has resuelto?");
    }

    private static void DrawTextFrame(string input)
    {

        string[] input_array = input.Split(' ').Where(word => !string.IsNullOrEmpty(word)).ToArray();
        int max_word_length = GetMaxLength(input_array);
        string top_and_bottom_frame_lines = new('*', max_word_length + 4);

        Console.WriteLine(top_and_bottom_frame_lines);
        foreach(var word in input_array)
        {
            string finalWord = word;
            if (finalWord.Length < max_word_length)
                finalWord += new string(' ',(max_word_length - finalWord.Length));
            Console.WriteLine("* " + finalWord + " *");
        }
        Console.WriteLine(top_and_bottom_frame_lines);
    }

    private static int GetMaxLength(string[] words)
    {
        /*NOTAS
         * Como yo lo hice
        int[] length_per_word = Array.Empty<int>(); 
        foreach(string word in input_array)
        {
            length_per_word = length_per_word.Append(word.Length).ToArray();
        }
        Array.Sort(length_per_word);*/
        //Una mejor manera
        int maxLength = 0;
        foreach(var word in words)
        {
            if (word.Length > maxLength)
                maxLength = word.Length;
        }
        return maxLength;
    }
}