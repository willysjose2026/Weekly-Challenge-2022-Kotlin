/*ENUNCIADO
 * Reto #33: CICLO SEXAGENARIO CHINO
 * MEDIA | Publicación: 15 / 08 / 22 | Resolución: 22 / 08 / 22
 *
 * Enunciado: Crea un función, que dado un año, indique el elemento 
 * y animal correspondiente en el ciclo sexagenario del zodíaco chino.
 * - Info: https://www.travelchinaguide.com/intro/astrology/60year-cycle.htm
 * - El ciclo sexagenario se corresponde con la combinación de los elementos
 *   madera, fuego, tierra, metal, agua y los animales rata, buey, tigre,
 *   conejo, dragón, serpiente, caballo, oveja, mono, gallo, perro, cerdo
 *   (en este orden).
 * - Cada elemento se repite dos años seguidos.
 * - El último ciclo sexagenario comenzó en 1984 (Madera Rata).
 * 
 * MI SOLUCION:
 * usando un diccionario para almacenar los elementos y uno para los animales, calculando la rama del elemento y el 
 * animal con las formulas:
 *          rama    = 1 + (year + 6) % 10
 *          animal  = 1 + (year + 8) % 12
 * y una condicional para saber cuando aplicar cual elemento.
 * 
 * 
 * MEJOR SOLUCION:
 * Esto se pudo simplificar, usando arrays en vez de diccionarios, y encontrando el numero del ciclo sexagecimal usando
 * la formula:
 *      indice_sexa =   (year - 4) % 60  --- quitandole 3 años al año sexagecimal
 * 
 * y luego conseguir el elemento y el animal con ese año:
 *      elemento    =   ((indice_sexa) % 10 / 2)    ---- se divide entre dos porque los elementos se repiten 2 por año
 *      animal      =   (indice_sexa % 12)
 * 
 * luego buscar con esos indices el elemento y el animal en el array y usarlos.
 */
internal class Program
{
    private static void Main(string[] args)
    {
        PrintChineseYear(1924);
        PrintChineseYear(1946);
        PrintChineseYear(1984);
        PrintChineseYear(604);
        PrintChineseYear(603);
        PrintChineseYear(1987);
        PrintChineseYear(2022);
        PrintChineseYear(2023);
    }

    private static void PrintChineseYear(int year)
    {
        /*NOTAS
         * Como lo hice
        Dictionary<int, string> Elements = new()
        {
            {1, "madera" },
            {2, "fuego" },
            {3, "tierra" },
            {4, "metal" },
            {5, "agua" }
        };

        Dictionary<int, string> Animals = new()
        {
            {1, "Rata" },
            {2, "Buey" },
            {3, "Tigre" },
            {4, "Conejo" },
            {5, "Dragon" },
            {6, "Serpiente" },
            {7, "Caballo" },
            {8, "Cabra" },
            {9, "Mono" },
            {10, "Pollo" },
            {11, "Perro" },
            {12, "Cerdo" },
        };*/

        string[] Elements = { "Madera", "Fuego", "Tierra", "Metal", "Agua" };
        string[] Animals = {"Rata", "Buey", "Tigre", "Conejo", "Dragon", "Serpiente", "Caballo", "Cabra", "Mono", "Pollo",
        "Perro", "Cerdo"};

        /*NOTAS
         * Como lo hice
        int stemElementNumber = (1 + ((year + 6) % 10)) / 2;
        int branchNumber = 1 + ((year + 8) % 12);*/

        int sexagecimalYear = (year - 4) % 60;
        int stemElementNumber = (sexagecimalYear % 10) / 2;
        int branchNumber = sexagecimalYear % 12;

        if (year < 604)
            Console.WriteLine("El zodiaco comenzo en el año 604");
        else
            Console.WriteLine($"El año {year} en chino, es el año del " +
                $"{Animals[branchNumber].ToUpper()} con el elemento {Elements[stemElementNumber].ToUpper()}");
    }
}