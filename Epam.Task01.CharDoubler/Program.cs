using System;
using System.Text;

namespace Epam.Task01.CharDoubler
{
    class Program
    {
        static string CharDoubler(string str1, string str2)
        {
            var str = new StringBuilder();

            for (int i = 0; i < str1.Length; i++)
            {
                bool check = true;
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        str.Append(str2[j], 2);
                        check = false;
                    }
                }
                if (check)
                {
                    str.Append(str1[i]);
                }
            }
            return str.ToString();
        }

        static void Main()
        {
            Console.Write("Please, enter a first string: ");
            string str1 = Console.ReadLine();

            Console.Write("Please, enter a second string: ");
            string str2 = Console.ReadLine();

            Console.WriteLine($"Result string: {CharDoubler(str1, str2)}");
        }
    }
}
