using System;

namespace Epam.Task01.X_masTree
{
    public class Program
    {
        public static void Tree(int amountOfTriangles)
        {
            Console.WriteLine("Here's your picture, enjoy!");

            for (int i = 0; i < amountOfTriangles; i++)
            {
                for (int row = 0; row <= i; row++)
                {
                    for (int k = 0; k < amountOfTriangles * 2; k++)
                    {
                        if (k < amountOfTriangles - row - 1)
                        {
                            Console.Write(" ");
                        }

                        if (k > amountOfTriangles - row - 1 && k < amountOfTriangles + row + 1)
                        {
                            Console.Write("*");
                        }
                    }

                    Console.WriteLine();
                }
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

            Tree(num);
        }
    }
}
