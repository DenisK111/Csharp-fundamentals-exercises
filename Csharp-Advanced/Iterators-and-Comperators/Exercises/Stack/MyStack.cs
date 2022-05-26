using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class MyStack<T> : IEnumerable<LinkedListNode<T>>
    {
        LinkedList<T> list = new LinkedList<T>();

        public MyStack(params T[] items)
        {
            list = new LinkedList<T>(items);
        }
        public IReadOnlyCollection<T> List => this.list;

            public void Push(params T[] element)
        {
            foreach (var item in element)
            {
            list.AddLast(new LinkedListNode<T>(item));

            }

        }

        public LinkedListNode<T> Pop()
        {
            if (list.Count == 0)
            {
                System.Console.WriteLine("No elements");
                return null;
            }
            var last = list.Last;
            list.RemoveLast();
            return last;
        }

        public IEnumerator<LinkedListNode<T>> GetEnumerator()
        {
            var templist = new LinkedList<T>(list);
            for (int i = 0; i < list.Count; i++)
            {
                yield return templist.Last;
                templist.RemoveLast();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}