using System;

namespace Epam.Task04._1.CustomSort
{
    public delegate bool Comparison<T>(T first, T second);

    public class Comparison
    {
        public void BubbleSort<T>(T[] array, Comparison<T> compare)
        {
            if (compare == null)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (compare(array[j], array[i]))
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public bool Sort(string first, string second)
        {
            if (first.Length == second.Length)
            {
                return this.AlphabetSort(first, second);
            }
            else
            {
                return first.Length > second.Length;
            }
        }

        public bool AlphabetSort(string first, string second)
        {
            int i = 0;

            while (i < first.Length - 1 && first[i] == second[i])
            {
                i++;
            }

            return first[i] > second[i];
        }

        public bool Sort(int first, int second)
        {
            return first > second;
        }

        public bool Sort(double first, double second)
        {
            return first > second;
        }
    }
}
