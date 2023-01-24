/*
 * Reto #28: MÁQUINA EXPENDEDORA
 * MEDIA | Publicación: 11 / 07 / 22 | Resolución: 18 / 07 / 22
 * 
 * Simula el funcionamiento de una máquina expendedora creando una operación
 * que reciba dinero (array de monedas) y un número que indique la selección
 * del producto.
 * - El programa retornará el nombre del producto y un array con el dinero
 *   de vuelta (con el menor número de monedas).
 * - Si el dinero es insuficiente o el número de producto no existe,
 *   deberá indicarse con un mensaje y retornar todas las monedas.
 * - Si no hay dinero de vuelta, el array se retornará vacío.
 * - Para que resulte más simple, trabajaremos en céntimos con monedas
 *   de 5, 10, 50, 100 y 200.
 * - Debemos controlar que las monedas enviadas estén dentro de las soportadas.
 * 
 *   Solucion dada por mi: crear un diccionario para los productos, sus precios y su codigo. Crear 3 funciones (tal vez
 *   inncesarias pero hacen ver mejor al codigo) para validar su existe el producto, si el monto es suficiente y si las
 *   monedas ingresadas son las correctas. Para la parte principal nuestro metodo fue realizando division, quedandonos 
 *   con el resto y haciendo un bucle for de 0 hasta el cociente de la division, donde dicho cociente es la cantidad de
 *   la moneda x a devolverse, cambiando luego el cambio por el restante de la division y repitiendo el proceso hasta 
 *   llegar a 0.
 *   
 *   El proceso se pudo simplificar, sencillamente con un bucle for dentro de un while, comparando la moneda mas grande 
 *   con el cambio, y de ser esta moneda menor o igual al cambio, restarle su monto a este, añadir la moneda al array y 
 *   romper el bucle for para que vuelva a revaluar la condicion de que el cambio sea distinto de 0.
 *   
 *   NOTAS: MIRAR CORRECCIONES DEL CODIGO ABAJO
 */

using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        KeyValuePair<int[], int>[] CoffeTestInput =
        {
            new KeyValuePair<int[], int>(new int[]{ 100,200 }, 1),
            new KeyValuePair<int[], int>(new int[]{ 25,200 }, 1),
            new KeyValuePair<int[], int>(new int[]{ 100,200 }, 85),
            new KeyValuePair<int[], int>(new int[]{ 5 }, 1)

        };

        foreach(var coffe in CoffeTestInput)
        {
            KeyValuePair<string, int[]> result = ExpandableMachine(coffe.Key, coffe.Value);
            Console.WriteLine(result.Key + " [" + string.Join(",", result.Value) + "]");
        }
    }
    private static KeyValuePair<string, int[]> ExpandableMachine(int[] coins, int option)
    {
        if (!IsOptionValid(option))
            /*NOTAS
             * LA FORMA EN QUE LO HICE
            Console.WriteLine("La opcion que ha introducido es incorrecta");
            return new KeyValuePair<string, int[]>("", coins);

            UNA MEJORADA*/
            return new KeyValuePair<string, int[]>("La opcion que ha introducido es incorrecta", coins);

        int[] SupportedCoins = { 5, 10, 50, 100, 200 };
        Array.Reverse(SupportedCoins);
        var coffeName = Coffes[option].Key;
        var coffeCost = Coffes[option].Value;
        int balance = coins.Sum();

        if (!AreCoinsSupported(coins, SupportedCoins))
            return new KeyValuePair<string, int[]>("Las monedas soportadas son: 5, 10, 50, 100 y 200", coins);
        else if (!IsBalanceSufficient(balance, coffeCost))
            return new KeyValuePair<string, int[]>("El balance introducido es insuficiente", coins);
        else
        {
            int[] changeInCoins = Array.Empty<int>();
            int change = balance - coffeCost;

            /*NOTAS
             * LA FORMA EN QUE LO HICE
            foreach (int supportedCoin in SupportedCoins)
            {
                int NumberOfCoins = change / supportedCoin;
                int remainder = change % supportedCoin;

                if (remainder > 0)
                {
                    for (int i = 0; i < NumberOfCoins; i++)
                    {
                        changeInCoins = changeInCoins.Append(supportedCoin).ToArray();
                    }

                    change = remainder;
                }
                else
                {
                    for (int i = 0; i < NumberOfCoins; i++)
                    {
                        changeInCoins = changeInCoins.Append(supportedCoin).ToArray();
                    }
                }
            }

            UNA FORMA MAS LIMPIA Y CORTA, Y MEJORADA DE LA VERSION DE MAUREDEV*/
            while(change != 0)
            {
                foreach (var coin in SupportedCoins)
                {
                    if (coin <= change)
                    {
                        change -= coin;
                        changeInCoins = changeInCoins.Append(coin).ToArray();
                        break;
                    }
                }
            }
            
            return new KeyValuePair<string, int[]>(coffeName, changeInCoins);
        }
    }

    private static bool IsBalanceSufficient(int balance, int cost) => balance > cost;
    private static bool IsOptionValid(int option) => Coffes.ContainsKey(option);
    private static bool AreCoinsSupported(int[] coins, int[] SupportedCoins)
    {
        foreach (int coin in coins)
        {
            if (!SupportedCoins.Contains(coin))
                return false;
        }

        return true;
    }

    private static Dictionary<int, KeyValuePair<string, int>> Coffes { get; } = new()
    {
        { 1, new("Cafe Negro", 15) },
        { 2, new("Cafe Con Leche", 25) },
        { 3, new("Mocca Trad", 50) },
        { 4, new("Mocca Vainilla", 80) },
        { 5, new("Mocca Chocolate", 100) },
        { 6, new("Descafeinado", 30) }
    };
}