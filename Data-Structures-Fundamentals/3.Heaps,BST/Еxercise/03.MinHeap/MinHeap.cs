namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;



        public MinHeap()
        {
            this._elements = new List<T>();
        }

        public int Size => _elements.Count;

        public T Dequeue()
        {
            if (_elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            
            var returned = _elements[0];
            _elements[0] = _elements[Size - 1];
            _elements.RemoveAt(Size - 1);
            HeapifyDown(0);
            return returned;
        }
        private void HeapifyDown(int index)
        {
            if ((2 * index) + 1 >= this.Size)
            {
                return;
            }
            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = 2 * index + 2;
            var maxChildIndex = leftChildIndex;
            if (rightChildIndex < this.Size && _elements[leftChildIndex].CompareTo(_elements[rightChildIndex]) > 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (_elements[index].CompareTo(_elements[maxChildIndex]) > 0)
            {
                var temp = _elements[index];
                _elements[index] = _elements[maxChildIndex];
                _elements[maxChildIndex] = temp;
                HeapifyDown(maxChildIndex);

            }
        }
        public void Add(T element)
        {
            _elements.Add(element);
            HeapifyUp(_elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = (index - 1) / 2;
            if (parentIndex < 0)
            {
                return;
            }
            if (_elements[index].CompareTo(_elements[parentIndex]) < 0)
            {
                var temp = _elements[index];
                _elements[index] = _elements[parentIndex];
                _elements[parentIndex] = temp;
                HeapifyUp(parentIndex);
            }
        }

        public T Peek()
        {
            if (_elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _elements[0];
        }
    }
}
