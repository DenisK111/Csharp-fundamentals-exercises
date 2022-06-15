namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> list;

        public MaxHeap()
        {
            list = new List<T>();
        }
        public int Size => list.Count;

        public void Add(T element)
        {
            list.Add(element);
            HeapifyUp(list.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = (index - 1) / 2;
            if (parentIndex < 0)
            {
                return;
            }
            if (list[index].CompareTo(list[parentIndex]) > 0)
            {
                var temp = list[index];
                list[index] = list[parentIndex];
                list[parentIndex] = temp;
                HeapifyUp(parentIndex);
            }
        }

        public T Peek()
        {
            return list[0];
        }
    }
}
