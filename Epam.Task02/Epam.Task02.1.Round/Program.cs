using System;
using Epam.Task02.Round;

namespace Epam.Task02.Round
{
    public class Program
    {
        public static int Enter(string msg)
        {
            int n = 0;
            bool check = false;
            do
            {
                Console.Write(msg);
                check = int.TryParse(Console.ReadLine(), out n);
                if (check == false)
                {
                    Console.WriteLine("Please, enter a number!");
                }
            }
            while (!check);

            return n;
        }

        public static void Main()
        {
            Console.WriteLine("Please, enter coordinates and radius of the circle: ");

            int x = Enter("x: ");
            int y = Enter("y: ");

            int radius = 0;
            do
            {
                Console.Write("radius: ");
                radius = int.TryParse(Console.ReadLine(), out radius) 
                    ? radius 
                    : -1;
                if (radius == -1)
                {
                    Console.WriteLine("Radius must be non-negative number!");
                }
            }
            while (radius < 0);

            Round circle = null;

            try
            {
                circle = new Round(x, y, radius);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            double circumference = 0;
            double area = 0;

            if (circle != null)
            {
                circumference = circle.GetСircumference();
                area = circle.GetArea();
            }

            Console.WriteLine($"Сircumference of this circle: {circumference}");
            Console.WriteLine($"Area of this circle: {area}");
        }
    }
}
