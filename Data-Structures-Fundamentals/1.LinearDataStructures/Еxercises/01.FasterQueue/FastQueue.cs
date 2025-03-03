﻿namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _end;

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

        public T Dequeue()
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
            return removed.Item;
        }

        public void Enqueue(T item)
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

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _head.Item;
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