using System;

namespace Epam.Task01.AverageStringLength
{
    public class Program
    {
        public static double AverageStringLength(string str)
        {
            int endOfString = 0;

            for (int i = str.Length - 1; i > 0; i--)
            {
                if (char.IsLetter(str[i]))
                {
                    endOfString = i;
                    break;
                }
            }

            int countLetters = 0;
            int countWords = 0;

            for (int i = 0; i <= endOfString; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    countLetters++;
                }
                else
                {
                    countWords++;
                    while (!char.IsLetter(str[i + 1]))
                    {
                        if (i < endOfString - 1)
                        {
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            countWords++;

            return (double)countLetters / countWords;
        }

        public static void Main()
        {
            Console.WriteLine("Please, enter a string:");
            string str = Console.ReadLine();

            Console.WriteLine($"Average string length: {AverageStringLength(str)}");
        }
    }
}
