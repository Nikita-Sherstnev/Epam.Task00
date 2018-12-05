using System;

namespace Epam.Task02._3.User
{
    public class User
    {
        private string surname;
        private string name;
        private string patronymic;
        private string birthday;
        private int age;

        public User()
        {
            this.surname = "Unknown";
            this.name = "Unknown";
            this.patronymic = "Unknown";
            this.birthday = "Unknown";
            this.age = 0;
        }

        public User(string surname, string name, string patronymic, string birthday, int age)
        {
            if (!IsCorrectString(surname))
            {
                throw new ArgumentException("Entered incorrect surname!");
            }

            this.surname = surname;

            if (!IsCorrectString(name))
            {
                throw new ArgumentException("Entered incorrect name!");
            }

            this.name = name;

            if (!IsCorrectString(patronymic))
            {
                throw new ArgumentException("Entered incorrect patronymic!");
            }

            this.patronymic = patronymic;

            if (!IsCorrectBirthday(birthday))
            {
                throw new ArgumentException("Entered incorrect birthday!");
            }

            this.birthday = birthday;

            if (age < 1 || age > 200)
            {
                throw new ArgumentException("Entered incorrect age!");
            }

            this.age = age;
        }

        public string Surname => this.surname;

        public string Name => this.name;

        public string Patronymic => this.patronymic;

        public string Birthday => this.birthday;

        public int Age => this.age;

        private static bool IsCorrectString(string str)
        {
            char[] arr = str.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!char.IsLetter(arr[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsCorrectBirthday(string birthday)
        {
            char[] arr = birthday.ToCharArray();

            int date = (int.Parse(arr[0].ToString()) * 10) + int.Parse(arr[1].ToString());
            if (date > 31)
            {
                return false;
            }

            int month = (int.Parse(arr[3].ToString()) * 10) + int.Parse(arr[4].ToString());
            if (month > 12)
            {
                return false;
            }

            int year = (int.Parse(arr[6].ToString()) * 1000) + (int.Parse(arr[7].ToString()) * 100) 
                + (int.Parse(arr[8].ToString()) * 10) + int.Parse(arr[9].ToString());

            if (year < 1800 || year > DateTime.Now.Year)
            {
                return false;
            }

            return true;
        }
    }
}
