using System;

namespace Epam.Task00.Square
{
    class Program
    {
        static void Square(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == n / 2 && j == n / 2) Console.Write(" ");
                    else Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            Square(7);
        }
    }
}
