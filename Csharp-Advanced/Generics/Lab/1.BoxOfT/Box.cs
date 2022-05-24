using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            stack = new Stack<T>();
        }

        private Stack<T> stack;
        private int count;
        public int Count { get { return count; } }

        public void Add(T element)
        {
            stack.Push(element);
            count++;
        }

        public T Remove()
        {
            count--;
            return stack.Pop();

        }



    }
}