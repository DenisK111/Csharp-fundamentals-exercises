namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity<0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _items = new T[capacity];
        }

        public T this[int index]
        {
            get { IndexRangeCheck(index);  return _items[index]; }
            set { IndexRangeCheck(index); _items[index] = value; }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == _items.Length )
            {
                Resize();
            }

            _items[Count] = item;
            Count++;
        }

       

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return true;
                }

            }
                return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }

            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            IndexRangeCheck(index);
            for (int i = Count - 1; i >= index; i--)
            {
                _items[i + 1] = _items[i];
            }

            _items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            var index= -1;
            for (int i = 0; i < Count ; i++)
            {
                if (_items[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return false;

            for (int i = index; i < Count-1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _items[Count - 1] = default;
            Count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            IndexRangeCheck(index);
            
                for (int i = index; i < Count-1 ; i++)
                {
                    _items[i] = _items[i + 1];
                }
            _items[Count - 1] = default;
            Count--;
            

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return _items[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
        private void Resize()
        {
            var array = new T[_items.Length * 2];
            Array.Copy(_items, array, _items.Length);
            _items = array;
        }

        private void IndexRangeCheck(int index)
        {

            if (index < 0 || index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

        }
    }

 
}