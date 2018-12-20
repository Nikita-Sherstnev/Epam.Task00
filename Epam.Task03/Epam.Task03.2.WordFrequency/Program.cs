using System;

namespace Epam.Task03._2.WordFrequency
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var wordFrequency = new WordFrequency();

            wordFrequency.GetText();
            wordFrequency.ClearingElements();
            wordFrequency.ShowList();
            wordFrequency.CountWords();
        }
    }
}
