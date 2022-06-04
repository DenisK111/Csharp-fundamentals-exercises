namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            foreach (var node in this)
            {
                if (node.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _head.Value;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var removed = _head;
            if (Count == 1)
            {
                _head = null;
                
                Count--;
                return removed.Value;
            }

            Count--;
            _head = _head.Next;
            return removed.Value;
        }

        public void Push(T item)
        {
            if (IsEmpty())
            {
                _head = new Node<T>(item);
                
            }

            else // .-.-.-.
            {
                var previousHead = _head;
                _head = new Node<T>(item);
                _head.Next = previousHead;
            }
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var returned = _head;

            while (returned != null)
            {
                yield return returned.Value;
                returned = returned.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private bool IsEmpty()
        {
            if (_head == null)
            {
                return true;
            }

            return false;

        }
    }
}