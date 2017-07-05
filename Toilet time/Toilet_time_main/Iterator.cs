using System;

namespace Toilet_time_main
{
    public interface Iterator<T> // interface for iterator
    {
        iOption<T> GetNext();
        iOption<T> GetCurrent();
        void Reset();
        void Add(T item);
        int Count();
    }

    public class List<T> : Iterator<T> // our iterator
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
        public void Add(T item) // add item to list
        {
            size++;
            T[] new_array = new T[size];
            Array.Copy(array, new_array, amount_of_items);

            new_array[amount_of_items] = item;
            amount_of_items++;

            array = new_array;
        }        

        public iOption<T> GetNext() // get next in line object
        {
            current++;
            return GetCurrent();
        }

        public void Reset() // resets the iterator
        {
            current = -1;
        }

        public iOption<T> GetCurrent() // returns some when still variable included, none when empty
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

        public int Count() // returns amount of items in iterator
        {
            return amount_of_items;
        }
    }
}