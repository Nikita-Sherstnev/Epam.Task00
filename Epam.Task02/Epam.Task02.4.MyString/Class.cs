using System;

namespace Epam.Task02._4.MyString
{
    public class MyString
    {
        private char[] array;

        public MyString()
        {
            this.array[0] = ' ';
        }

        public MyString(string str)
        {
            this.array = str.ToCharArray();
        }

        public char this[int index]
        {
            get
            {
                return this.array[index];
            }

            set
            {
                this.array[index] = value;
            }
        }

        public static MyString operator +(MyString str1, MyString str2)
        {
            return new MyString(str1.ToString() + str2.ToString());
        }

        public int Length()
        {
            return this.array.Length;
        }

        public int Compare(MyString str)
        {
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] < str[i])
                {
                    return -1;
                }

                if (this.array[i] > str[i])
                {
                    return 1;
                }
            }

            return 0;
        }

        public int IndexOf(char ch)
        {
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        public MyString ToMyString(char[] arr)
        {
            arr.ToString();
            return new MyString();
        }

        public char[] ToCharArray()
        {
            char[] arr = new char[this.array.Length];
            for (int i = 0; i < this.array.Length; i++)
            {
                arr[i] = this.array[i];
            }

            return arr;
        }
    }
}
