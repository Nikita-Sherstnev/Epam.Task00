using System;
using Epam.Task02._4.MyString;

namespace Epam.Task02._4.MyString
{
    public class Program
    {
        public static void Comparison(MyString myStr1, MyString myStr2)
        {
            int comp = myStr1.Compare(myStr2);
            if (comp == -1)
            {
                Console.WriteLine("myStr1 precides myStr2 in the sort order");
            }
            else if (comp == 1)
            {
                Console.WriteLine("myStr1 follow myStr2 in the sort order");
            }
            else
            {
                Console.WriteLine("myStr1 occurs at the same position as myStr2 in the sort order");
            }
        }

        public static void Main()
        {
            Console.WriteLine("Enter the first string:");
            string str1 = Console.ReadLine();
            Console.WriteLine("Enter the second string:");
            string str2 = Console.ReadLine();

            MyString myStr1 = new MyString(str1);
            MyString myStr2 = new MyString(str2);

            Comparison(myStr1, myStr2);

            Console.WriteLine("Concatenated strings: ");
            Console.WriteLine(myStr1 + myStr2);

            Console.Write("Enter the symbol that you want to find in the first string: ");
            char ch = Console.ReadKey().KeyChar;

            Console.WriteLine($"Index of char: {myStr1.IndexOf(ch)}");
        }
    }
}
