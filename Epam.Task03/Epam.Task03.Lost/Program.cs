using System;
using System.Collections.Generic;

namespace Epam.Task03.Lost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int num = 0;
            do
            {
                Console.WriteLine("Please, enter the number of people:");
                num = int.TryParse(Console.ReadLine(), out num)
                    ? num
                    : 0;

                if (num < 1)
                {
                    Console.WriteLine("Number must be natural!");
                }
            }
            while (num < 1);

            var list = new List<int>();

            for (int i = 1; i <= num; i++)
            {
                list.Add(i);
            }

            bool delete = false;

            while (list.Count > 1)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (delete)
                    {
                        list.RemoveAt(i--);
                    }

                    delete = !delete;
                }

                foreach (var item in list)
                {
                    Console.Write($"{item} ");
                }

                Console.WriteLine();
            }
        }
    }
}
