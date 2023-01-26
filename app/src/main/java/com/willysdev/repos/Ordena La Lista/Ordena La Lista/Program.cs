/*
 * Reto #29: ORDENA LA LISTA
 * FÁCIL | Publicación: 18 / 07 / 22 | Resolución: 26 / 07 / 22
 * 
 * Crea una función que ordene y retorne una matriz de números.
 * - La función recibirá un listado (por ejemplo [2, 4, 6, 8, 9]) y un parámetro
 *   adicional "Asc" o "Desc" para indicar si debe ordenarse de menor a mayor
 *   o de mayor a menor.
 * - No se pueden utilizar funciones propias del lenguaje que lo resuelvan
 *   automáticamente.
 *   
 *   Solucion: crear dos loop for nestados, para comparar elemento con cada elemento del array, y asi poder ordenarlo de forma
 *   ascendente de manera predeterminada, para luego comparar, si se pide ascendente, se retorna el array, de lo contrario
 *   se reordena el array reversandolo con un for loop tradicional invertido y un array de reversa.
 */

using System.Linq.Expressions;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] array = Sort(new int[]{ 2,5,-1,27,45,1,2}, true);
        int[] reversed_array = Sort(new int[]{ 2,5,-1,27,45,1,2}, false);
        foreach(int number in array)
        {
            Console.Write(number + ", ");
        }

        foreach (int number in reversed_array)
        {
            Console.Write(number + ", ");
        }
    }
    private static int[] Sort(int[] array, bool isAsc)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for(int j = i+1; j < array.Length; j++)
            {
                if (array[i] > array[j])
                    (array[j], array[i]) = (array[i], array[j]);
            }
        }

        if (isAsc)
            return array;
        else
        {
            int[] reversed_array = Array.Empty<int>();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                reversed_array = reversed_array.Append(array[i]).ToArray();
            }
            return reversed_array;
        }
    }
}