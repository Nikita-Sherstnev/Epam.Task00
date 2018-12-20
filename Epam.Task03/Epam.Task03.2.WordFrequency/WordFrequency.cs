using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam.Task03._2.WordFrequency
{
    public class WordFrequency
    {
        private char[] delimiterChars = { ' ', '.' };
        private List<string> splitedText = new List<string>();
        private int count = 1;
        private int i;

        public void GetText()
        {
            Console.WriteLine("Please, enter your english text:");
            splitedText = Console.ReadLine().Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public void ShowList()
        {
            Console.WriteLine("List of words:");
            for (int i = 0; i < splitedText.Count; i++)
            {
                Console.WriteLine(splitedText[i]);
            }

            Console.WriteLine();
        }

        public List<string> ClearingElements()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < splitedText.Count; i++)
            {
                var word = splitedText[i].ToLower();

                for (int a = 0; a < word.Length; a++)
                {
                    var c = word[a];
                    if (c >= 'a' && c <= 'z')
                    {
                        sb.Append(c);
                    }
                }

                splitedText[splitedText.IndexOf(splitedText[i])] = sb.ToString();
                sb.Clear();
            }

            return splitedText;
        }

        public void CountWords()
        {
            for (i = 1; splitedText.Count > 0; i++)
            {
                if (splitedText[0] == splitedText[i])
                {
                    count++;
                    splitedText.RemoveAt(i);
                    i--;
                }

                if (i >= (splitedText.Count - 1))
                {
                    Console.WriteLine($"Word \"{splitedText[0]}\" appeared in the text {count} time/times.");
                    splitedText.RemoveAt(0);
                    i = 0;
                    count = 1;
                }
            }
        }
    }
}
