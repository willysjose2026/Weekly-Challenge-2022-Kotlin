/*
 * Reto #24: ITERATION MASTER
 * FÁCIL | Publicación: 13 / 06 / 22 | Resolución: 20 / 06 / 22

 * Quiero contar del 1 al 100 de uno en uno (imprimiendo cada uno).
 * ¿De cuántas maneras eres capaz de hacerlo?
 * Crea el código para cada una de ellas.
 * 
 * Formas en las que pense:
 * - Forma hardcoded
 * - Con for loop
 * - Con lista (no implementada)
 * - Con while loop
 * - Con do while loop (no implementada)
 * 
 * Formas que vi que funcionarian con .Net:
 * - Recurcion utilizando condicionales
 * 
 * Otras Formas:
 * - Con colecciones, usando metodos como map y filter.
 */

using Iteration_master;

internal class Program
{
    private static void Main(string[] args)
    {
        Init();
    }

    private static void Init()
    {
        IteratorMaster iteratorMaster;

        Console.WriteLine("Primera Opcion");
        iteratorMaster = new IterateHardCore();
        iteratorMaster.IterateFromOneToHundred();

        Console.WriteLine("\nSegunda Opcion");
        iteratorMaster = new IteratorForLoop();
        iteratorMaster.IterateFromOneToHundred();

        Console.WriteLine("\nTercera Opcion");
        iteratorMaster = new IteratorWhileLoop();
        iteratorMaster.IterateFromOneToHundred();

    }
}