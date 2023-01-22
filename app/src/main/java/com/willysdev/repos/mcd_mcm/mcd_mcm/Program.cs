/*
 * Reto #23: MÁXIMO COMÚN DIVISOR Y MÍNIMO COMÚN MÚLTIPLO
 * MEDIA | Publicación: 07 / 06 / 22 | Resolución: 13 / 06 / 22
 * 
 * Crea dos funciones, una que calcule el máximo común divisor (MCD) y otra
 * que calcule el mínimo común múltiplo (mcm) de dos números enteros.
 * - No se pueden utilizar operaciones del lenguaje que 
 *   lo resuelvan directamente.
 *   
 * La solucion fue utilzar el algoritmo de euclides para el maximo comun divisor, el cual explica que el maximo
 * comun divisor de dos numeros, es igual al maximo comun divisor de el ultimo numero y el residuo de la division
 * de dos numeros, y que si este segundo numero es 0, el mcd es el primer numero.
 * 
 * Con este algoritmo de funcion recursiva, completamos tambien el minimo comun divisor, que se define como: el
 * valor absoluto del producto de ambos numeros, divididos entre el maximo comun divisor de ambos numeros.
 * 
 * Tambien se pudo haber buscado el maximo comun divisor, con el metodo tradicional, pero cuesta mas trabajo xdd.
 */

using System.Net.Sockets;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(MCD(56, 180));
        Console.WriteLine(MCM(56, 180));
    }

    private static long MCM(long number_one, long number_two)
        => (number_one / MCD(number_one, number_two)) * number_two;

    private static long MCD(long number_one, long number_two)
    {
        if(number_one < 0 || number_two < 0) return 0;
        if (number_two == 0)
            return number_one;

        long remainder = number_one % number_two;
        return MCD(number_two, remainder);
    }
}