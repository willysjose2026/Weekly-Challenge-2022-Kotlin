/*
 * Reto #26: CUADRADO Y TRIÁNGULO 2D
 * FÁCIL | Publicación: 27 / 06 / 22 | Resolución: 07 / 07 / 22
 * 
 * Crea un programa que dibuje un cuadrado o un triángulo con asteriscos "*".
 * - Indicaremos el tamaño del lado y si la figura a dibujar es una u otra.
 * - EXTRA: ¿Eres capaz de dibujar más figuras?
 */
using cuadrado_y_triangulo_2D;

internal class Program
{
    private static void Main(string[] args)
    {
        int side = 0;
        Console.WriteLine("Indique el tamaño de los lados: ");

        try
        {
            side = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Debe introducir un numero entre {0} y {1}. Presione cualquier tecla"
                , int.MinValue, int.MaxValue);
            Console.ReadKey();
            Console.Clear();
            Main(args);
        }

        List<Shape> shapes = new()
        {
            new Triangle(side),
            new Square(side)
        };
        
        foreach (Shape shape in shapes)
        {
            shape.Draw();
        }
    }

}