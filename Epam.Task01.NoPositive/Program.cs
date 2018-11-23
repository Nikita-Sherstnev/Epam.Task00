using System;

namespace Epam.Task01.NoPositive
{
    class Program
    {
        static void Main()
        {
            int[,,] arr = new int[4,4,4];
            Random r = new Random();

            Console.WriteLine("Array: ");

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = r.Next(-50, 50);
                        Console.Write("{0,4}", arr[i,j,k]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            Console.WriteLine("Changed array: ");

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if (arr[i, j, k] > 0) arr[i, j, k] = 0;
                        Console.Write("{0,4}", arr[i, j, k]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }
}
