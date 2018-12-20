using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Task03._3.DynamicArray
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, IEnumerator
    {
        private T[] array;
        private int cursor = -1;
        private int size;
        private int count;

        public int Length => array.Length;

        public int Capacity => size;

        public object Current => array[cursor];

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= array.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return array[index];
            }
        }
        public DynamicArray()
        {
            array = new T[8];
            size = array.Length;
        }

        public DynamicArray(int i)
        {
            array = new T[i];
            size = array.Length;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            array = new T[collection.Count()];
            foreach (var element in collection)
            {
                for (var i = 0; i < array.Length; i++)
                {
                    array[i] = element;
                }
            }
            size = array.Length;
        }

        public void Add(T new_element)
        {
            if (count + 1 < Capacity)
            {
                if (count == 0)
                {
                    array[0] = new_element;
                }
                else
                {
                    array[count] = new_element;
                }

                count++;
            }
            else
            {
                T[] buffer = new T[2 * Capacity];
                size = 2 * Capacity;
                for (int i = 0; i < count; i++)
                {
                    buffer[i] = array[i];
                }
                buffer[count] = new_element;
                array = buffer;

                count++;
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (Capacity < (count + collection.Count()))
            {
                size = count + collection.Count();
                T[] buffer = new T[Capacity];

                for (int i = 0; i < count; i++)
                {
                    buffer[i] = array[i];
                }
                for (int i = count; i < Capacity; i++)
                {
                    buffer[i] = ((T[])collection)[i - count];
                }

                array = buffer;
                count = Capacity;
            }
            else
            {
                T[] buffer = new T[Capacity];


                for (int i = 0; i < count; i++)
                {
                    buffer[i] = array[i];
                }
                for (int i = count; i < count + collection.Count(); i++)
                {
                    buffer[i] = ((T[])collection)[i - count];
                }

                array = buffer;
                count = count + collection.Count();
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in array)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            if (cursor < array.Length)
            {
                cursor++;
            }

            return cursor != array.Length;
        }

        public void Reset()
        {
            cursor = -1;
        }

        public bool Remove(int index)
        {
            if (index < 0 || index > array.Length)
            {
                array = array.Except(new[] { array[index] }).ToArray();
                return true;
            }

            return false;
        }

        public bool Insert(T new_element, int index)
        {
            bool success = false;

            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException($"index:{index}", "Index is out of _array's range");
            }
            else if (index == count & count < Capacity)
            {
                array[index] = new_element;
                count++;
            }
            else if (index == Capacity - 1 & index == count - 1)
            {
                T[] buffer = new T[Capacity + 1];
                for (int i = 0; i < count - 1; i++)
                {
                    buffer[i] = array[i];
                }
                buffer[index] = new_element;
                buffer[index + 1] = array[index];
                array = buffer;
                size++;
                count++;
                success = true;
            }
            else if (index < count & count == Capacity)
            {
                T[] buffer = new T[Capacity + 1];
                for (int i = 0; i < index; i++)
                {
                    buffer[i] = array[i];
                }

                buffer[index] = new_element;
                for (int i = index + 1; i < count + 1; i++)
                {
                    buffer[i] = array[i - 1];
                }

                array = buffer;
                size++;
                count++;
                success = true;
            }
            else if (index < count & count < Capacity)
            {
                T[] buffer = new T[Capacity];
                for (int i = 0; i < index; i++)
                {
                    buffer[i] = array[i];
                }

                buffer[index] = new_element;
                for (int i = index + 1; i < count + 1; i++)
                {
                    buffer[i] = array[i - 1];
                }

                array = buffer;

                count++;
                success = true;
            }

            return success;
        }
    }
}
