namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _end;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            if (IsEmpty())
            {
                _head = new Node<T>(item);
                _end = _head;
            }

            else // .-.-.-.
            {
                var previousHead = _head;
                _head.Previous = new Node<T>(item);
                _head = _head.Previous;
                _head.Next = previousHead;

            }
            Count++;
        }

        public void AddLast(T item)
        {

            if (IsEmpty())
            {

                _head = new Node<T>(item);
                _end = _head;

            }
            else
            {
                var temp = _end;
                _end.Next = new Node<T>(item);
                _end = _end.Next;
                _end.Previous = temp;

            }
            Count++;

        }

        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _head.Item;
        }

        public T GetLast()
        {

            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _end.Item;
        }

        public T RemoveFirst()
        {

            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var removed = _head;
            if (Count == 1)
            {
                _head = null;
                _end = null;
                Count--;
                return removed.Item;
            }

            Count--;
            _head = _head.Next;
            _head.Previous = null;
            return removed.Item;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var removed = _head;
            if (Count == 1)
            {
                _head = null;
                _end = null;
                Count--;
                return removed.Item;
            }

            var toBeReturned = _end;

            _end = _end.Previous;
            _end.Next = null;

            Count--;
            return toBeReturned.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var returned = _head;

            while (returned != null)
            {
                yield return returned.Item;
                returned = returned.Next;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

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