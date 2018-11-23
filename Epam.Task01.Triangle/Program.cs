using System;

namespace Epam.Task01.Triangle
{
    class Program
    {
        static void Triangle(int rows)
        {
            Console.WriteLine("Here's your picture, enjoy!");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
        static void Main()
        {
            int n;
            do
            {
                Console.WriteLine("Please, enter a natural number:");
                n = int.TryParse(Console.ReadLine(), out n)
                    ? n
                    : 0;
            }
            while (n < 1);

            Triangle(n);
        }
    }
}
