using System;

namespace Epam.Task01.ArrayProcessing
{
    class Program
    {
        static int Max(int[] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            return max;
        }

        static int Min(int[] arr)
        {
            int min = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
            }
            return min;
        }

        static void QuickSort(int[] arr, int left, int right)
        {
            if (left > right || left < 0 || right < 0) return;

            int index = Partition(arr, left, right);

            if (index != -1)
            {
                QuickSort(arr, left, index - 1);
                QuickSort(arr, index + 1, right);
            }
        }

        static int Partition(int[] arr, int left, int right)
        {
            if (left > right) return -1;

            int end = left;

            int pivot = arr[right];
            for (int i = left; i < right; i++)
            {
                if (arr[i] < pivot)
                {
                    Swap(arr, i, end);
                    end++;
                }
            }

            Swap(arr, end, right);

            return end;
        }

        static void Swap(int[] arr, int left, int right)
        {
            int tmp = arr[left];
            arr[left] = arr[right];
            arr[right] = tmp;
        }
        
        static void ShowArray(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write($"{item} ");
            }
        }

        static void Main()
        {
            int[] arr = new int[10];
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(100);
            }

            Console.WriteLine("Array:");
            ShowArray(arr);

            Console.WriteLine($"{Environment.NewLine}Max: {Max(arr)} {Environment.NewLine}Min: {Min(arr)}");

            QuickSort(arr, 0, arr.Length - 1);

            Console.WriteLine("Sorted array:");
            ShowArray(arr);

            Console.WriteLine();
        }
    }
}
