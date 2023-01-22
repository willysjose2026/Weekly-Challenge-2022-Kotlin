using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cuadrado_y_triangulo_2D
{
    internal class Triangle : Shape
    {
        public Triangle(int side) { this.Side = side; }
        public int Side { get; }

        public void Draw()
        {
            const int INCREASE_INDEX = 2;
            const char FILLER = ' ';
            
            string space = FILLER.ToString();
            string firstLine = new string(FILLER, Side) + "*";
            string finalLine = string.Concat(Enumerable.Repeat("* ", Side)) + "*";
            int spaces_before_star = Side - 1;
            
            Console.WriteLine(firstLine);
            for(int i = 0; i < Side-1; i++)
            {
                string innerTriangleTemp = new(FILLER, INCREASE_INDEX);
                string outerTriangleTemp = new(FILLER, spaces_before_star);
                
                Console.WriteLine(outerTriangleTemp + "*" + space + "*");
            
                space += innerTriangleTemp;
                spaces_before_star -= 1;
            }
            Console.WriteLine(finalLine);
        }
    }
}
