/*
 * Reto #31: AÑOS BISIESTOS
 * FÁCIL | Publicación: 01 / 08 / 22 | Resolución: 08 / 08 / 22
 * 
 * Crea una función que imprima los 30 próximos años bisiestos
 * siguientes a uno dado.
 * - Utiliza el menor número de líneas para resolver el ejercicio.
 */

using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        PrintNextLeapYears(300);
    }

    private static void PrintNextLeapYears(int year)
    {
        GregorianCalendar gregorianCalendar = new();
        int Leap_Year_Counter = 0;
        int NumberOfDaysInYear = gregorianCalendar.GetDaysInYear(year);
        int newYear = year;

        while(Leap_Year_Counter < 30)
        {
            if (NumberOfDaysInYear == 366)
            {
                Leap_Year_Counter++;
                Console.WriteLine(newYear);
            }
            newYear++;
            NumberOfDaysInYear = gregorianCalendar.GetDaysInYear(newYear);
        }
    }
}