/*
 * Reto #21: CALCULADORA .TXT
 * MEDIA | Publicación: 23 / 05 / 22 | Resolución: 01 / 06 / 22

 * Lee el fichero "Challenge21.txt" incluido en el proyecto, calcula su
 * resultado e imprímelo.
 * - El .txt se corresponde con las entradas de una calculadora.
 * - Cada línea tendrá un número o una operación representada por un
 *   símbolo (alternando ambos).
 * - Soporta números enteros y decimales.
 * - Soporta las operaciones suma "+", resta "-", multiplicación "*"
 *   y división "/".
 * - El resultado se muestra al finalizar la lectura de la última
 *   línea (si el .txt es correcto).
 * - Si el formato del .txt no es correcto, se indicará que no se han
 *   podido resolver las operaciones.
 */
using System.Data;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string filePath = "..\\..\\..\\Challenge21.txt";
        CalculateFromFile(filePath);
  
    }

    private static void CalculateFromFile(string fileURI)
    {
        if (!File.Exists(fileURI))
            Console.WriteLine("El archivo especificado no existe");
        else
        {
            string[] fileLines = File.ReadAllLines(fileURI);
            string fileContent = "";

            foreach(var line in fileLines)
            {
                fileContent += line;
            }

            if (Regex.IsMatch(fileContent, @"[^0-9/*+-]"))
                Console.WriteLine("El formato del archivo no es correcto");
            else
            {
                string? result = new DataTable().Compute(fileContent, null).ToString();
                if (result == null)
                    Console.WriteLine("No se han podido resolver las ecuaciones");
                else
                    Console.WriteLine(result);
            }
        }
    }
}