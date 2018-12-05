using System;

namespace Epam.Task02.Triangle
{
    public class Triangle
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;

        public Triangle()
            : this(1, 1, 1)
        {
        }

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            if (c < a + b && a < b + c && b < a + c)
            {
                this.c = c;
            }
            else
            {
                throw new ArgumentException("One side can't be longer than others!");
            }
        }

        public int GetPerimeter()
        {
            return this.a + this.b + this.c;
        }

        public double GetArea()
        {
            double p = (double)this.GetPerimeter() / 2;
            return Math.Sqrt(p * (p - this.a) * (p - this.b) * (p - this.c));
        }
    }
}
