using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cuadrado_y_triangulo_2D
{
    internal class Square : Shape
    {
        public Square(int side) { this.Side = side; }

        public int Side { get; private set; }

        public void Draw()
        {
            string UpperAndLowerSide = string.Concat(Enumerable.Repeat("* ", Side));
            int multiplier = (Side - 2) * 2;
            string InnerPartOfSquare = new(' ', multiplier);
            
            Console.WriteLine(UpperAndLowerSide);            
            for(int i = 0; i < Side-2; i++)
            {
                Console.WriteLine("* " + InnerPartOfSquare + "*");
            }
            Console.WriteLine(UpperAndLowerSide);

        }
    }
}
