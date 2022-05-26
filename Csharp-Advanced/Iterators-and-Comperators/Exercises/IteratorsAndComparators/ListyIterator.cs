namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private const int defaultValue = 0;
        private List<T> list;
        private int index = defaultValue;
        public ListyIterator(params T[] items)
        {
            list = new List<T>(items);
        }

        public IReadOnlyCollection<T> List => this.list;

        public bool Move()
        {
            if (!HasNext())
            {
                return false;
            }

            else
            {
                index++;
                return true;
            }

        }

        public bool HasNext() => index != list.Count - 1;

        public void Print()
        {

            CheckCount();

            Console.WriteLine(list[index]);
        }

        public void PrintAll()
        {
            CheckCount();


            foreach (var item in this)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


        }



        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void CheckCount()
        {
            if (list.Count == 0)
            {

                throw new Exception("Invalid operation!");
                
            }

        }
    }
}