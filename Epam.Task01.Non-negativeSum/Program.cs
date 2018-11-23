using System;

namespace Epam.Task01.Non_negativeSum
{
    class Program
    {
        static void Main()
        {
            int sum = 0;
            int[] arr = new int[10];

            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-10, 10);
            }

            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0) sum += arr[i];
            }

            Console.WriteLine($"Sum of non-negative elements: {sum}");
        }
    }
}
