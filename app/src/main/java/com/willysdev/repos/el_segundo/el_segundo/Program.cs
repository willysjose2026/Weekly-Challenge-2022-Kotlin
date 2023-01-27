/*
 * Reto #32: EL SEGUNDO
 * FÁCIL | Publicación: 08 / 08 / 22 | Resolución: 15 / 08 / 22
 * 
 * Dado un listado de números, encuentra el SEGUNDO más grande.
 */
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(GetSecondGrearest(new long[] { 4, 6, 1, 8, 2 }));
        Console.WriteLine(GetSecondGrearest(new long[] { 4, 6, 8, 8, 6 }));
        Console.WriteLine(GetSecondGrearest(new long[] { 4, 4 }));
        Console.WriteLine(GetSecondGrearest(Array.Empty<long>()));
    }

    private static long? GetSecondGrearest(long[] numbers)
    {
        Array.Sort(numbers);
        if (numbers.Length >= 2)
            return numbers[^2];
        else if (numbers.Length > 0 && numbers.Length < 2)
            return numbers[0];
        else
            return null;
    }
}