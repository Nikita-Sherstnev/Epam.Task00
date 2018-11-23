using System;

namespace Epam.Task01.AverageStringLength
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please, enter a string:");
            string str = Console.ReadLine();

            int end = 0;

            for (int i = str.Length - 1; i > 0; i--)
            {
                if (char.IsLetter(str[i]))
                {
                    end = i;
                    break;
                }
            }

            int countLetters = 0;
            int countWords = 0;

            for (int i = 0; i <= end; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    countLetters++;
                }
                else
                {
                    countWords++;
                    while (!char.IsLetter(str[i]))
                    {
                        if (i < end - 1)
                        {
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    countLetters++;
                }
            }
            countWords++;

            double average = (double)countLetters / countWords;
            Console.WriteLine($"Average word length: {average}");
        }
    }
}
