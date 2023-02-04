/* Reto #36: LOS ANILLOS DE PODER
 * MEDIA | Publicación: 06 / 09 / 22 | Resolución: 14 / 09 / 22
 * 
 * Enunciado: ¡La Tierra Media está en guerra! En ella lucharán razas leales
 * a Sauron contra otras bondadosas que no quieren que el mal reine
 * sobre sus tierras.
 * Cada raza tiene asociado un "valor" entre 1 y 5:
 * - Razas bondadosas: Pelosos (1), Sureños buenos (2), Enanos (3),
 *   Númenóreanos (4), Elfos (5)
 * - Razas malvadas: Sureños malos (2), Orcos (2), Goblins (2),
 *   Huargos (3), Trolls (5)
 * Crea un programa que calcule el resultado de la batalla entre
 * los 2 tipos de ejércitos:
 * - El resultado puede ser que gane el bien, el mal, o exista un empate.
 *   Dependiendo de la suma del valor del ejército y el número de integrantes.
 * - Cada ejército puede estar compuesto por un número de integrantes variable
 *   de cada raza.
 * - Tienes total libertad para modelar los datos del ejercicio.
 * Ej: 1 Peloso pierde contra 1 Orco
 *     2 Pelosos empatan contra 1 Orco
 *     3 Pelosos ganan a 1 Orco
 */

/*SOLUCION: 
 * Se crearon dos enumerables que contubieran los valores de cada personaje, uno para bondadosos y otro para malvados.
 * Al inicio se usaron arrays de enteros (los cuales estan bien y se entienden), pero luego se cambio a KeyValuePairs, que 
 * se entienden mucho mejor y al usar arrays el performance es mejor.
 * 
 * Se corrieron dos foreach, uno por cada ejercito, para calcular los puntos en total de numero * fuerza de cada ejercito.
 * Luego se compararon los puntos para determinar el ganador.
 */

using System.ComponentModel;
internal class Program
{
    private static void Main(string[] args)
    {
        KeyValuePair<Kinds, int>[] kindArmy =
        {
            new KeyValuePair<Kinds, int>(Kinds.Numeroneans, 5),
            new KeyValuePair<Kinds, int>(Kinds.Elves, 20),
            new KeyValuePair<Kinds, int>(Kinds.Dwarves, 40),
            new KeyValuePair<Kinds, int>(Kinds.GoodSoutherns, 6),
            new KeyValuePair<Kinds, int>(Kinds.Hairies, 3)

        };

        KeyValuePair<Evils, int>[] evilArmy =
        {
            new KeyValuePair<Evils, int>(Evils.BadSoutherns, 9),
            new KeyValuePair<Evils, int>(Evils.Goblins, 15),
            new KeyValuePair<Evils, int>(Evils.Trolls, 20),
            new KeyValuePair<Evils, int>(Evils.Wargs, 3),
            new KeyValuePair<Evils, int>(Evils.Orcs, 5),
        };

        /*NOTAS
         * int[][] kindArmy =
        {
            new int[]{ (int)Kinds.Numeroneans, 5 },
            new int[]{ (int)Kinds.Elves, 20 },
            new int[]{ (int)Kinds.Dwarves, 40 },
            new int[]{ (int)Kinds.GoodSoutherns, 6 },
            new int[]{ (int)Kinds.Hairies, 3 }
        };

        int[][] evilArmy =
        {
            new int[]{(int)Evils.BadSoutherns, 9},
            new int[]{(int)Evils.Goblins, 15},
            new int[]{(int)Evils.Trolls, 20},
            new int[]{(int)Evils.Wargs, 3},
            new int[]{(int)Evils.Orcs, 5},
        };*/

        BattleOfTheRings(kindArmy, evilArmy);
    }

    public enum Kinds
    {
        Hairies = 1,
        GoodSoutherns = 2,
        Dwarves = 3,
        Numeroneans = 4,
        Elves = 5
    }

    public enum Evils
    {
        BadSoutherns = 2,
        Orcs = 2,
        Goblins = 2,
        Wargs = 3,
        Trolls = 5
    }

    private static void BattleOfTheRings(KeyValuePair<Kinds, int>[] kinds, KeyValuePair<Evils, int>[] evils)
    {
        int kindPoints = 0;
        int evilsPoints = 0;

        foreach(var kind in kinds)
        {
            kindPoints += ((int)kind.Key) * kind.Value;
        }

        foreach(var evil in evils)
        {
            evilsPoints += ((int)evil.Key) * evil.Value;
        }

        if (kindPoints == evilsPoints)
            Console.WriteLine("Es un empate");
        else if (kindPoints > evilsPoints)
            Console.WriteLine("Los Bondadosos Ganan");
        else
            Console.WriteLine("Los Malvados Ganan");
    }
}