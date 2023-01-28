/*
 * Reto #34: LOS NÚMEROS PERDIDOS
 * MEDIA | Publicación: 22 / 08 / 22 | Resolución: 29 / 08 / 22
 * 
 * Enunciado: Dado un array de enteros ordenado y sin repetidos, 
 * crea una función que calcule y retorne todos los que faltan entre
 * el mayor y el menor.
 * - Lanza un error si el array de entrada no es correcto.
 */
internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine(string.Join(",", FindLostNumbers(new int[] {1,3,5})));
            Console.WriteLine(string.Join(",", FindLostNumbers(new int[] {5,3,1})));
            Console.WriteLine(string.Join(",", FindLostNumbers(new int[] {5,1})));
            Console.WriteLine(string.Join(",", FindLostNumbers(new int[] {-5,1})));
            Console.WriteLine(string.Join(",", FindLostNumbers(new int[] { 5, 7, 1 })));
            Console.WriteLine(string.Join(",", FindLostNumbers(new int[] { 10, 7, 7, 1 })));
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static int[] FindLostNumbers(int[] numbers)
    {
        if (numbers.Length == 0)
            return Array.Empty<int>();

        int[] tempArray = (int[]) numbers.Clone();
        Array.Sort(tempArray);
        if (Enumerable.SequenceEqual(numbers, tempArray))
        {
            if(numbers.Length == numbers.Distinct().Count())
            {
                int[] LostNumbers = Array.Empty<int>();
                int firstNumber = numbers[0];
                int lastNumber = numbers[^1];
                
                if(firstNumber > lastNumber)
                    (firstNumber, lastNumber) = (lastNumber, firstNumber);

                for(int i = firstNumber; i <= lastNumber; i++)
                {
                    if (!numbers.Contains(i))
                        LostNumbers = LostNumbers.Append(i).ToArray();
                }

                return LostNumbers;
            }

            throw new FormatException("El array contiene duplicados");
        }

        throw new FormatException("El array no esta ordenado");
    }
}