using System;

namespace Epam.Task01.AnotherTriangle
{
    public class Program
    {
        public static void AnotherTriangle(int row)
        {
            Console.WriteLine("Here's your picture, enjoy!");

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j <= row * 2; j++)
                {
                    if (j < row - i - 1)
                    {
                        Console.Write(" ");
                    }

                    if (j > row - i - 1 && j < row + i + 1)
                    {
                        Console.Write("*");
                    }
                }

                Console.WriteLine();
            }
        }

        public static void Main()
        {
            int num;
            do
            {
                Console.WriteLine("Please, enter a natural number:");
                num = int.TryParse(Console.ReadLine(), out num)
                    ? num
                    : 0;
            }
            while (num < 1);

            AnotherTriangle(num);
        }
    }
}
