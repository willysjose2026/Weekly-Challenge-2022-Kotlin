/*
 * Reto #27: VECTORES ORTOGONALES
 * FÁCIL | Publicación: 07 / 07 / 22 | Resolución: 11 / 07 / 22
 * 
 * Crea un programa que determine si dos vectores son ortogonales.
 * - Los dos array deben tener la misma longitud.
 * - Cada vector se podría representar como un array. Ejemplo: [1, -2]
 * 
 * Solucion: Dado que cuando el escalar de dos vectores es 0, el angulo entre ambos es de 90 grados y por ser de 
 * 90 grados, son ortogonales o perpendiculares, la solucion fue buscar el escalar de ambos vectores y validar si
 * este era igual a 0.
 */

internal class Program
{
    private static void Main(string[] args)
    {
        
        Console.WriteLine(AreOrtogonal(new double[] {1,2}, new double[] {2,1}));
        Console.WriteLine(AreOrtogonal(new double[] {2,1}, new double[] {-1,2}));
    }

    private static bool AreOrtogonal(double[] first_vector, double[] second_vector)
    {
        if (first_vector.Length != second_vector.Length
            || first_vector.Length > 2
            || second_vector.Length > 2)
        {
            Console.WriteLine("Los vectores deben ser un par(x,y) ambos");
            return false;
        }

        double x1 = first_vector[0];
        double x2 = second_vector[0];

        double y1 = first_vector[1];
        double y2 = second_vector[1];

        double escalar = (x1 * x2) + (y1 * y2);

        return escalar == 0;
    }
}