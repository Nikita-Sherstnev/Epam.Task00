using System;

namespace Epam.Task00.Simple
{
    class Program
    {
        static bool IsSimple(int num)
        {
            if (num == 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
        static void Main()
        {
            int num = 0;
            do
            {
                Console.WriteLine("Please, enter a positive integer:");

                num = int.TryParse(Console.ReadLine(), out num)
                    ? num
                    : 0;
            }
            while (num < 1);

            if (IsSimple(num))
            {
                Console.WriteLine("Number is prime.");
            }
            else
            {
                Console.WriteLine("Number is not prime.");
            }
        }
    }
}
