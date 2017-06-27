using System;

namespace Toilet_time
{
    public interface Iterator<T>
    {
        iOption<T> GetNext();
        iOption<T> GetCurrent();
        void Reset();
        void Add(T item);
        int Count();
    }

    public class List<T> : Iterator<T>
    {
        private int size;
        private T[] array;
        private int current;
        private int amount_of_items;

        public List()
        {
            size = 0;
            amount_of_items = 0;
            current = -1;
            array = new T[size];
        }
        public void Add(T item)
        {
            size++;
            T[] new_array = new T[size];
            Array.Copy(array, new_array, amount_of_items);

            new_array[amount_of_items] = item;
            amount_of_items++;

            array = new_array;
        }

        public iOption<T> GetNext()
        {
            current++;
            return GetCurrent();
        }

        public void Reset()
        {
            current = -1;
        }

        public iOption<T> GetCurrent()
        {
            if (current > -1 && current < amount_of_items && amount_of_items > 0)
            {
                return new Some<T>(array[current]);
            }
            else
            {
                return new None<T>();
            }
        }

        public int Count()
        {
            return amount_of_items;
        }
    }
}