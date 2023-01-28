/*
 * Reto #35: BATALLA POKÉMON
 * MEDIA | Publicación: 29 / 08 / 22 | Resolución: 06 / 09 / 22
 * 
 * Enunciado: Crea un programa que calcule el daño de un ataque durante
 * una batalla Pokémon.
 * - La fórmula será la siguiente: daño = 50 * (ataque / defensa) * efectividad
 * - Efectividad: x2 (súper efectivo), x1 (neutral), x0.5 (no es muy efectivo)
 * - Sólo hay 4 tipos de Pokémon: Agua, Fuego, Planta y Eléctrico 
 *   (buscar su efectividad)
 * - El programa recibe los siguientes parámetros:
 *  - Tipo del Pokémon atacante.
 *  - Tipo del Pokémon defensor.
 *  - Ataque: Entre 1 y 100.
 *  - Defensa: Entre 1 y 100.
 *  
 */
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(CalculateAttackDamage(Pokemon.Agua, Pokemon.Fuego, 50, 30));
        Console.WriteLine(CalculateAttackDamage(Pokemon.Agua, Pokemon.Fuego, 101, -10));
        Console.WriteLine(CalculateAttackDamage(Pokemon.Fuego, Pokemon.Agua, 50, 30));
        Console.WriteLine(CalculateAttackDamage(Pokemon.Fuego, Pokemon.Fuego, 50, 30));
        Console.WriteLine(CalculateAttackDamage(Pokemon.Planta, Pokemon.Electrico, 30, 50));
    }

    public static class Pokemon
    {
        public static string Agua { get; } = "agua";
        public static string Fuego { get; } = "fuego";
        public static string Planta { get; } = "planta";
        public static string Electrico { get; } = "electrico";
    }

    private class PokemonChart
    {
        public PokemonChart(string strongAgainst, string weakAgainst)
        {
            this.StrongAgainst = strongAgainst;
            this.WeakAgainst = weakAgainst;
        }

        public string StrongAgainst { get; }
        public string WeakAgainst { get; }
    }

    private static double? CalculateAttackDamage(string attacker, string defender, 
        double damage_level, double defense_level)
    {
        if(damage_level <= 0 || damage_level > 100 
            || defense_level <= 0 || defense_level > 100)
        {
            Console.WriteLine("El ataque o la defensa tienen valores erroneos");
            return null;
        }

        Dictionary<string, PokemonChart> effectiveChart = new()
        {
            {Pokemon.Agua, new PokemonChart(Pokemon.Fuego, Pokemon.Planta)},
            {Pokemon.Fuego, new PokemonChart(Pokemon.Planta, Pokemon.Agua)},
            {Pokemon.Planta, new PokemonChart(Pokemon.Agua, Pokemon.Fuego)},
            {Pokemon.Electrico, new PokemonChart(Pokemon.Agua, Pokemon.Planta)}
        };

        double efficiancy = 1;
        if (attacker == defender || defender == effectiveChart[attacker].WeakAgainst)
        {
            Console.WriteLine($"pokemon tipo {attacker} no es muy eficiente contra " +
                $"un pokemon tipo {defender}");
            efficiancy = 0.5;
        }
        else if (defender == effectiveChart[attacker].StrongAgainst)
        {
            Console.WriteLine($"pokemon tipo {attacker} es muy eficiente contra " +
                $"un pokemon tipo {defender}");
            efficiancy = 2;
        }
        else
            Console.WriteLine($"La eficiencia de los pokemones {attacker} y {defender}" +
                $" son neutras");

        return 50 * (damage_level / defense_level) * efficiancy;
    }

}