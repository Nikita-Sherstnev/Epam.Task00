using System;
using Epam.Task4._2.CustomSortDemo;

namespace Epam.Task4._2.CustomSortDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter the string that will be converted to array:");
            string txt = Console.ReadLine();
            char[] separators = { ' ', ',', '.' };
            string[] array = txt.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Comparison compare = new Comparison();

            compare.BubbleSort(array, compare.Sort);

            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
