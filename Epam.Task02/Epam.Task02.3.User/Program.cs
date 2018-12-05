using System;
using System.Text;
using Epam.Task02._3.User;

namespace Epam.Task02._3.User
{
    public class Program
    {
        public static int EnterDate()
        {
            int date = 0;
            do
            {
                Console.Write("Date: ");
                date = int.TryParse(Console.ReadLine(), out date)
                    ? date
                    : 0;
                if (date < 1 || date > 31)
                {
                    Console.WriteLine("Please enter correct date!");
                }
            }
            while (date < 1 || date > 31);

            return date;
        }

        public static int EnterMonth()
        {
            int month = 0;
            do
            {
                Console.Write("Month: ");
                month = int.TryParse(Console.ReadLine(), out month)
                    ? month
                    : 0;
                if (month < 1 || month > 12)
                {
                    Console.WriteLine("Please enter correct month!");
                }
            }
            while (month < 1 || month > 12);

            return month;
        }

        public static int EnterYear()
        {
            int year = 0;
            do
            {
                Console.Write("Year: ");
                year = int.TryParse(Console.ReadLine(), out year)
                    ? year
                    : 0;
                if (year < 1800 || year > DateTime.Now.Year)
                {
                    Console.WriteLine("Please enter correct year!");
                }
            }
            while (year < 1800 || year > DateTime.Now.Year);

            return year;
        }

        public static string CreateDate(int date, int month, int year)
        {
            StringBuilder str = new StringBuilder();

            if (date < 10)
            {
                str.Append('0');
                str.Append(date);
                str.Append('.');
            }
            else
            {
                str.Append(date);
                str.Append('.');
            }

            if (month < 10)
            {
                str.Append('0');
                str.Append(month);
                str.Append('.');
            }
            else
            {
                str.Append(month);
                str.Append('.');
            }

            str.Append(year);

            return str.ToString();
        }

        public static int EnterAge()
        {
            int age = 0;
            do
            {
                Console.Write("Please, enter user's age: ");
                age = int.TryParse(Console.ReadLine(), out age)
                    ? age
                    : 0;
                if (age < 1 || age > 200)
                {
                    Console.WriteLine("Please enter correct age!");
                }
            }
            while (age < 1 || age > 200);

            return age;
        }

        public static void Main()
        {
            Console.WriteLine("Please, enter user's name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Please, enter user's surname: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Please, enter user's patronymic: ");
            string patronymic = Console.ReadLine();

            Console.WriteLine("Please, enter user's birthday:");
            
            int date = EnterDate();
            int month = EnterMonth();
            int year = EnterYear();

            string birthday = CreateDate(date, month, year);

            int age = EnterAge();

            User user = null;

            try
            {
                user = new User(surname, name, patronymic, birthday, age);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            if (user != null)
            {
                Console.WriteLine("You entered the user");
                Console.WriteLine($"Surname: {user.Surname} {Environment.NewLine}" +
                    $"Name: {user.Name} {Environment.NewLine}" +
                    $"Patronymic: {user.Patronymic} {Environment.NewLine}" +
                    $"Birthday: {user.Birthday} {Environment.NewLine}" +
                    $"Age: {user.Age}"); 
            }
        }
    }
}
