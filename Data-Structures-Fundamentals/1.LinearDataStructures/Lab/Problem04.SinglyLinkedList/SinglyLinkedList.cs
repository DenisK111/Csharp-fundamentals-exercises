namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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
                _head = new Node<T>(item);
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
                _end.Next = new Node<T>(item);
                _end = _end.Next;

            }
            Count++;

        }

        public T GetFirst()
        {
            if (Count==0)
            {
                throw new InvalidOperationException();
            }
            return _head.Value;
        }

        public T GetLast()
        {

            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _end.Value;
        }

        public T RemoveFirst()
        {

            if (Count==0)
            {
                throw new InvalidOperationException();
            }

            var removed = _head;
            if (Count == 1)
            {
                _head = null;
                _end = null;
                Count--;
                return removed.Value;
            }

            Count--;
            _head = _head.Next;
            return removed.Value;
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
                return removed.Value;
            }

            var toBeReturned = _end;
            while (true)
            {

                if (removed.Next == _end)
                {
                    _end = removed;
                    _end.Next = null;
                    break;

                }
                removed = removed.Next;

            }

            Count--;
            return toBeReturned.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var returned = _head;

            while (returned!=null)
            {
                yield return returned.Value;
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