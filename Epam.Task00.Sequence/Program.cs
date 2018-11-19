using System;
using System.Text;

namespace Epam.Task00.Sequence
{
    public class Program
    {
        static void Sequence(int num)
        {
            Console.WriteLine("Here is your sequence:");
            for (int i = 1; i <= num; i++)
            {
                if (i != num)
                {
                    Console.Write(i + ", ");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void Main()
        {
            int num = 0;
            do
            {
                Console.WriteLine("Please, enter a positive integer: ");

                num = int.TryParse(Console.ReadLine(), out num)
                    ? num
                    : 0;
            }
            while (num < 1);

            Sequence(num);
        }
    }
}
