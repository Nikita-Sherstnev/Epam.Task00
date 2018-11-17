using System;

namespace Epam.Task00.Simple
{
    class Program
    {
        static bool IsSimple(int n)
        {
            if (n < 1) return false;
            if (n < 3) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i < n; i+=2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static void Main()
        {
            Console.WriteLine(IsSimple(13));
            Console.WriteLine(IsSimple(15));
            Console.WriteLine(IsSimple(128));
            Console.WriteLine(IsSimple(997));
        }
    }
}
