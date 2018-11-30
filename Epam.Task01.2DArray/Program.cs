using System;

namespace Epam.Task01._2DArray
{
    public class Program
    {
        public static void Main()
        {
            int sum = 0;
            int[,] arr = new int[3, 3];

            Random r = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(10);
                    Console.Write("{0,3}", arr[i, j]);
                }

                Console.WriteLine();
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                    }
                }
            }

            Console.WriteLine($"Sum of even elements: {sum}");
        }
    }
}
