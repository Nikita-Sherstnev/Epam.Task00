using System;

namespace Epam.Task00.Square
{
    class Program
    {
        static void Square(int num)
        {
            Console.WriteLine("Here is your square:");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (i == num / 2 && j == num / 2)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }

                Console.WriteLine();
            }
        }
        static void Main()
        {
            int num = 0;
            do
            {
                Console.WriteLine("Please, enter a positive odd integer: ");

                num = int.TryParse(Console.ReadLine(), out num)
                    ? num
                    : 0;
            }
            while (num < 1 || num % 2 != 1);

            Square(num);
        }
    }
}
