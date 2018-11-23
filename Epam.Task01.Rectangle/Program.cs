using System;

namespace Epam.Task01.Rectangle
{
    class Program
    {
        static int Enter(out int num)
        {
            int check = int.TryParse(Console.ReadLine(), out num)
                      ? num
                      : 1;
            if (check < 1) Console.WriteLine("Entered incorrect number!");
            return num;
        }
        static int RectangleArea(int a, int b) => a * b;

        static void Main()
        {
            Console.WriteLine("Please, enter sides of rectangle");
            int a;
            do
            {
                Console.Write("a: ");
                Enter(out a);
            }
            while (a < 1);

            int b;
            do
            {
                Console.Write("b: ");
                Enter(out b);
            }
            while (b < 1);

            Console.WriteLine($"Rectangle area = {RectangleArea(a, b)}");
        }
    }
}
