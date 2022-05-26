using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace Tuples
{
   public class Box<T>
    {

        
        int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        List<T> list;
        private int count;
        public Box()
        {
            this.list = new List<T>();
        }

        public T this[int index] { get { return list[index]; } set {

                list[index] = value;
            } }

        public int Count { get { return count; } }
        public void Add(T element)
        {
            count++;
            list.Add(element);
        }

        
    }
}
