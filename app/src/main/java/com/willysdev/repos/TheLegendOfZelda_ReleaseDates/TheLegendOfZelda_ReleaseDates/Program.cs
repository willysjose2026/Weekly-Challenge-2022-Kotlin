/* Reto #37: LOS LANZAMIENTOS DE "THE LEGEND OF ZELDA”
 * MEDIA | Publicación: 14 / 09 / 22 | Resolución: 19 / 09 / 22
 * 
 * Enunciado: ¡Han anunciado un nuevo "The Legend of Zelda"! 
 * Se llamará "Tears of the Kingdom" y se lanzará el 12 de mayo de 2023.
 * Pero, ¿recuerdas cuánto tiempo ha pasado entre los distintos
 * "The Legend of Zelda" de la historia?
 * Crea un programa que calcule cuántos años y días hay entre 2 juegos de Zelda
 * que tú selecciones.
 * - Debes buscar cada uno de los títulos y su día de lanzamiento 
 *   (si no encuentras el día exacto puedes usar el mes, o incluso inventártelo)
 */

/* Solution: 
 * created a function that takes two zelda games as strings. That function has a dictionary with all the zelda games
 * and their exact release date. With a custom normalize function I bring the correct data to work with. See if both games exists.
 * then I make sure to be comparing the dates correctly and take the years in between, then I take the older date (startDate) and
 * update the year to the younger date (endDate) to change the timespan between them and take the days. Before taking the days I
 * compare again the dates to make sure to be working in the correct order, then take the days out of that.
 * */

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(CalculateTimeBetweenGames("The Legend of Zelda", "The Legend of Zelda: Majora's Mask"));
        Console.WriteLine(CalculateTimeBetweenGames("Twilight Princess", "The Legend of Zelda A link to the past"));
        Console.WriteLine(CalculateTimeBetweenGames("Majora's Mask", "The Legend of Zelda"));
        Console.WriteLine(CalculateTimeBetweenGames("Majora's Mask", "A link to the past"));
        Console.WriteLine(CalculateTimeBetweenGames("The Legend of   Zelda", "Majora's Mask"));
        Console.WriteLine(CalculateTimeBetweenGames("The Legend of Zeldon", "Majora's Mask"));
    }

    private static string CalculateTimeBetweenGames(string firstGame, string secondGame)
    {
        Dictionary<string, DateTime> ZeldaGames = new()
        {
            { "the legend of zelda", new DateTime(1986,02,21) },
            { "the adventure of link", new DateTime(1987,01,14) },
            {"a link to the past", new DateTime(1991, 11, 21) },
            {"link's awakening", new DateTime(1993, 09, 20) },
            {"ocarina of time", new DateTime(1998, 11, 21) },
            {"majora's mask", new DateTime(2000, 04, 27) },
            {"oracle of seasons", new DateTime(2001, 02, 27) },
            {"oracle of ages", new DateTime(2001, 02, 27) },
            {"the wind waker", new DateTime(2002, 12, 13) },
            {"four swords adventure", new DateTime(2004, 03, 18) },
            {"the minish cap", new DateTime(2004, 11, 04) },
            {"twilight princess", new DateTime(2006, 11, 19) },
            {"phantom hourglass", new DateTime(2007, 06, 23) },
            {"spirit tracks", new DateTime(2009, 12, 07) },
            {"skyward sword", new DateTime(2011, 11, 18) },
            {"a link between worlds", new DateTime(2013, 11, 22) },
            {"trinity force heroes", new DateTime(2015, 10, 22) },
            {"breath of the wild", new DateTime(2017, 03, 03) },
            {"tears of the kingdom", new DateTime(2023, 05, 12) },
        };

        firstGame = normalize(firstGame.ToLower());
        secondGame = normalize(secondGame.ToLower());

        if (!ZeldaGames.ContainsKey(firstGame) || !ZeldaGames.ContainsKey(secondGame))
            return "El juego introducido no existe, intente escribir el nombre en ingles";
        
        var startDate = ZeldaGames.Where(g => g.Key.Contains(firstGame)).FirstOrDefault().Value;
        var endDate = ZeldaGames.Where(g => g.Key.Contains(secondGame)).FirstOrDefault().Value;

        if (startDate > endDate)
            (startDate, endDate) = (endDate, startDate);

        int timeInYears = endDate.Year - startDate.Year;

        //calcular cantidad de dias
        startDate = startDate.AddYears(timeInYears);
        
        //reorganizar las fechas en caso de que la primera tenga un mes y un dia posterior a la fecha final
        if (startDate > endDate)
            (startDate, endDate) = (endDate, startDate);

        var timeInDays = (endDate - startDate).TotalDays;
        
        return $"Han pasado {timeInYears} años y {timeInDays} dias";
    }

    private static string normalize(string word)
    {
        string[] word_array = word.Split(' ').Where(element 
            => !string.IsNullOrEmpty(element)).ToArray();

        string newWord = string.Join(" ", word_array);
        
        if (newWord != "the legend of zelda")
            newWord = newWord.Replace("the legend of zelda: ", string.Empty).Replace("the legend of zelda ", string.Empty);
        
        return newWord;
    }

}