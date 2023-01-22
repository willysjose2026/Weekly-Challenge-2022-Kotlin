using System.Threading;

/*
 * Reto #20: PARANDO EL TIEMPO
 * MEDIA
 * 
 * Crea una función que sume 2 números y retorne su resultado pasados
 * unos segundos.
 * - Recibirá por parámetros los 2 números a sumar y los segundos que
 *   debe tardar en finalizar su ejecución.
 * - Si el lenguaje lo soporta, deberá retornar el resultado de forma
 *   asíncrona, es decir, sin detener la ejecución del programa principal.
 *   Se podría ejecutar varias veces al mismo tiempo.
 */

internal class Program
{
    private static void Main(string[] args)
    {
        AddWithDelay(5, 5, 5);
        Console.WriteLine("Hello");
        AddWithDelay(2, 7, 2);
        Console.WriteLine("Hola");
        AddWithDelay(3, 11, 3);
    }

    public static void AddWithDelay(int number_one, int number_two, int delayInSeconds)
    {
        Thread thread = new(new ThreadStart(() =>
        {
            Thread.Sleep(delayInSeconds * 1000);
            Console.WriteLine(number_one + number_two);
        }));

        thread.Start();
    }
}