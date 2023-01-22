
/*Reto #19: CONVERSOR TIEMPO
 *FÁCIL
 * Crea una función que reciba días, horas, minutos y segundos (como enteros)
 * y retorne su resultado en milisegundos.
 */

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(GetMilliseconds(0,0,0,10));
        Console.WriteLine(GetMilliseconds(2, 5, -45, 10));
        Console.WriteLine(GetMilliseconds(2000000000, 5, 45, 10));
    }

    private static long GetMilliseconds(int days, int hours, int minutes, int seconds)
    {
        var daysToMillis = Convert.ToInt64(days) * 24 * 60 * 60 * 1000;
        var hoursToMillis = Convert.ToInt64(hours) * 60 * 60 * 1000;
        var minutesToMillis = Convert.ToInt64(minutes) * 60 * 1000;
        var secondsToMillis = Convert.ToInt64(seconds) * 1000;
        
        return daysToMillis + hoursToMillis + minutesToMillis + secondsToMillis;
    }
}