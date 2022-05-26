
using System;
using System.Collections.Generic;

namespace GenericBoxOfStrings
{
    public class Box<T> where T : IComparable
    {
        public Box(T input)
        {
            Input = input;
        }

        public Box()
        {
            List = new List<T>();
        }

        public List<T> List { get; set; }
        public T Input { get; set; }

        public override string ToString()
        {
            return $"{Input.GetType()}: {Input.ToString()}";     
        }

        public int Compare(T element) 
        {
            int count = 0;
            foreach (var item in List)
            {
                count += item.CompareTo(element) > 0 ? 1 : 0;
            }

            return count;
        }

        public void Add(T element)
        {

            List.Add(element);
        }

    }
}