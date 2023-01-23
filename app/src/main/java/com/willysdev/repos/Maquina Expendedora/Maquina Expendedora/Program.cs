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
            KeyValuePair<string, int[]>? result = ExpandableMachine(coffe.Key, coffe.Value);
            if (result != null)
                Console.WriteLine(result.Value.Key + " [" + string.Join(",", result.Value.Value) + "]");

        }
    }
    private static KeyValuePair<string, int[]>? ExpandableMachine(int[] coins, int option)
    {
        if (!IsOptionValid(option))
        {
            Console.WriteLine("La opcion que ha introducido es incorrecta");
            return null;
        }

        int[] SupportedCoins = { 5, 10, 50, 100, 200 };
        Array.Reverse(SupportedCoins);
        var coffeName = Coffes[option].Key;
        var coffeCost = Coffes[option].Value;
        int balance = coins.Sum();

        if (!AreCoinsSupported(coins, SupportedCoins))
        {
            Console.WriteLine("Las monedas soportadas son: 5, 10, 50, 100 y 200");
            return null;
        }
        else if (!IsBalanceSufficient(balance, coffeCost))
        {
            Console.WriteLine("El balance introducido es insuficiente");
            return new KeyValuePair<string, int[]>("", coins);
        }
        else
        {
            int[] changeInCoins = Array.Empty<int>();
            int change = balance - coffeCost;

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