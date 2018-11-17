using System;
using System.Text;

namespace Epam.Task00.Sequence
{
    class Program
    {
        static string Sequence(int n)
        {
            StringBuilder str = new StringBuilder("1");
            for (int i = 2; i <= n; i++)
            {
                str.Append(", ");
                str.Append(i);
            }
            return str.ToString();

        }
        static void Main()
        {
            Console.WriteLine(Sequence(7));
        }
    }
}
