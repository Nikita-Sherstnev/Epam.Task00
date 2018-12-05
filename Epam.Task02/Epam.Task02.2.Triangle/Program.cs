using System;
using Epam.Task02.Triangle;

namespace Epam.Task02.Triangle
{
    public class Program
    {
        public static int Enter(string msg)
        {
            int num = 0;
            do
            {
                Console.Write(msg);
                num = int.TryParse(Console.ReadLine(), out num) ? num : 0;
                if (num < 1)
                {
                    Console.WriteLine("Side must be positive!");
                }
            }
            while (num < 1);

            return num;
        }

        public static void Main()
        {
            Console.WriteLine("Please, enter sides of the triangle:");

            int a = Enter("a: ");
            int b = Enter("b: ");
            int c = Enter("c: ");

            Triangle triangle = null;

            try
            {
                triangle = new Triangle(a, b, c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            double area = 0;
            double perimeter = 0;

            if (triangle != null)
            {
                area = triangle.GetArea();
                perimeter = triangle.GetPerimeter();
            }

            Console.WriteLine($"Area: {area}");
            Console.WriteLine($"Perimeter: {perimeter}");
        }
    }
}
