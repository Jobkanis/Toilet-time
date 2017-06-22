using System;

namespace Toilet_time
{
    public interface Iterator<T>
    {
        iOption<T> GetNext();
        iOption<T> GetCurrent();
        void Reset();
    }

    public class List<T> : Iterator<T>
    {
        private int size;
        private T[] array;
        private int current;
        private int amount_of_items;

        public List()
        {
            size = 1;
            amount_of_items = 0;
            current = 0;
            array = new T[10];
            Reset();
        }
        public void Add(T item)
        {
            size++;
            T[] new_array = new T[size];
            Array.Copy(array, new_array, amount_of_items);
            array[amount_of_items] = item;
            amount_of_items++;
            array = new_array;
        }

        public iOption<T> GetNext()
        {
            current++;
            if (current >= amount_of_items)
            {
                return new None<T>();
            }
            return new Some<T>(array[current]);
        }

        public void Reset()
        {
            current = -1;
        }

        public iOption<T> GetCurrent()
        {
            if (current == -1) return new None<T>();
            return new Some<T>(array[current]);
        }
    }
}