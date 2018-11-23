using System;

namespace Epam.Task01.FontAdjustment
{
    class Program
    {
        [Flags]
        enum Fonts
        {
            None,
            Bold,
            Italic,
            Underline = 4,
        }
        static void Main()
        {
            int param = 0;
            while (true)
            {
                Console.WriteLine($"Parameters of title: {(Fonts)param}");
                Console.WriteLine($"Enter: {Environment.NewLine}{" ",5}1: bold" +
                    $"{Environment.NewLine}{" ",5}2: italic" +
                    $"{Environment.NewLine}{" ",5}3: underline");

                int check = int.TryParse(Console.ReadLine(), out check)
                          ? check
                          : 0;

                if (check < 1 || check > 3)
                {
                    Console.WriteLine("Entered invalid number/string!");
                }
                else
                {
                    if (check == 3) check++;
                    param ^= check;
                }
            }
        }
    }
}
