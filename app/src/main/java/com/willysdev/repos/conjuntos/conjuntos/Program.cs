/*
 * Reto #22: CONJUNTOS
 * FÁCIL | Publicación: 01 / 06 / 22 | Resolución: 07 / 06 / 22

 * Crea una función que reciba dos array, un booleano y retorne un array.
 * - Si el booleano es verdadero buscará y retornará los elementos comunes
 *   de los dos array.
 * - Si el booleano es falso buscará y retornará los elementos no comunes
 *   de los dos array.
 * - No se pueden utilizar operaciones del lenguaje que
 *   lo resuelvan directamente.
 *   
 *   La solucion fue declarar un array de retorno, y de acuerdo al boolean pasado, se buscan los comunes en un
 *   solo for loop, o los no comunes usando dos for loop, uno por cada array. Ahora, una opcion que creo que es 
 *   mas optimizada, es la de añadir los comunes a un array diferente del de retorno, copiar ambos arrays de 
 *   entrada al array de retorno y, remover con un for loop, los comunes usando ese array de elementos comunes 
 *   creados.
 *   
 *   De esta manera solo se utiliza un for loop por cada operacion, sea el boolean pasado falso o verdadero.
 */

internal class Program
{
    private static void Main(string[] args)
    {
        int[] array1 = { 1, 2, 3 };
        int[] array2 = { 1, 5, 6, 7 };
        Console.WriteLine("[{0}]",string.Join(", ", GetCommonsOrNonCommons(array1, array2, true)));
        Console.WriteLine("[{0}]", string.Join(", ", GetCommonsOrNonCommons(array1, array2, false)));
        Console.WriteLine("[{0}]", string.Join(", ", GetCommonsOrNonCommons(array2, array1, true)));
        Console.WriteLine("[{0}]", string.Join(", ", GetCommonsOrNonCommons(array2, array1, false)));

    }

    private static int[] GetCommonsOrNonCommons(int[] array1, int[] array2, bool isCommon)
    {
        List<int> returned_array = new();
        
        if(array1.Length > array2.Length)
            (array2, array1) = (array1, array2);

        if (isCommon)
        {
            foreach (int value in array1)
            {
                if(array2.Contains(value))
                    returned_array.Add(value);
            }
        }
        else
        {
            foreach (int value in array1)
            {
                if (!array2.Contains(value))
                    returned_array.Add(value);
            }

            foreach (int value in array2)
            {
                if (!array1.Contains(value))
                    returned_array.Add(value);
            }
        }

        return returned_array.ToArray();
    }
}