using System;

namespace Epam.Task02.Round
{
    public class Round
    {
        private int x;
        private int y;
        private int radius;

        public Round() 
            : this(1, 1, 1)
        {
        }

        public Round(int x, int y, int radius)
        {
            this.x = x;
            this.y = y;
            if (radius >= 0)
            {
                this.radius = radius;
            }
            else
            {
                throw new ArgumentException("Radius can't be less than zero!");
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Radius
        {
            get => this.radius;
            set
            {
                if (value >= 0)
                {
                    this.radius = value;
                }
                else
                {
                    throw new ArgumentException("Radius can't be less than zero!");
                }
            }
        }

        public double GetArea()
        {
            return Math.PI * this.radius * this.radius;
        }

        public double GetСircumference()
        {
            return 2 * Math.PI * this.radius;
        }
    }
}
