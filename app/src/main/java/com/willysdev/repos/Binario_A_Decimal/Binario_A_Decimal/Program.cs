/* Reto #38: BINARIO A DECIMAL
 * MEDIA | Publicación: 19 / 09 / 22 | Resolución: 27 / 09 / 22
 * 
 * Enunciado: Crea un programa se encargue de transformar un número binario
 * a decimal sin utilizar funciones propias del lenguaje que 
 * lo hagan directamente.
 */

/* Solucion:
 * Se declara una funcion que toma un string que represente un numero binario, se asegura con regex que sean solo 0 y 1, y se
 * asegura que el string no contenga espacios ni tampoco sea un string vacio. Se crea un exponente con el indice del ultimo
 * elemento del string, con un for se itera por cada digito y se multiplica por dos elevado al exponente, y se decrementa el 
 * exponente en cada iteracion.
*/
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(BinaryToDecimal("00110"));
        Console.WriteLine(BinaryToDecimal("01100"));
        Console.WriteLine(BinaryToDecimal("000000000"));
        Console.WriteLine(BinaryToDecimal("00210"));
        Console.WriteLine(BinaryToDecimal("001101001110"));
        Console.WriteLine(BinaryToDecimal("00b10"));
        Console.WriteLine(BinaryToDecimal("-00110"));
        Console.WriteLine(BinaryToDecimal(" "));
        Console.WriteLine(BinaryToDecimal(""));
        Console.WriteLine(BinaryToDecimal(" 10011"));
        Console.WriteLine(BinaryToDecimal("1O1OO11"));
    }

    private static double? BinaryToDecimal(string binaryNumber)
    {
        double decimalNumber = 0;
        if(Regex.IsMatch(binaryNumber, @"[^10]") || binaryNumber.Contains(" ")
            || binaryNumber.Equals(string.Empty))
        {
            Console.WriteLine("El formato no es correcto, los numeros binarios estan compuestos solo de 1 y 0");
            return null;
        }

        int exp = binaryNumber.Length - 1;
        for(int i = 0; i < binaryNumber.Length; i++)
        {
            double digit = double.Parse(binaryNumber[i].ToString());
            decimalNumber += (digit * Math.Pow(2, exp));
            exp--;
        }

        return decimalNumber;
    }
}