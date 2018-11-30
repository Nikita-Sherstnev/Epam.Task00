using System;

namespace Epam.Task01.SumOfNumbers
{
    public class Program
    {
        public static void Main()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine($"Sum of numbers: {sum}");
        }
    }
}
