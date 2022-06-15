namespace _03.PriorityQueue
{
    using _02.MaxHeap;
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        List<T> list;
        public PriorityQueue()
        {
            list = new List<T>();
        }
        public int Size
        {
            get
            {
                
                
                return list.Count; } }

        public T Dequeue()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var returned = list[0];
            list[0] = list[Size - 1];
            list.RemoveAt(Size - 1);
            HeapifyDown(0);
            return returned;


        }

        private void HeapifyDown(int index)
        {
            if ((2*index) + 1 >= this.Size )
            {
                return;
            }
            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = 2 * index + 2;
            var maxChildIndex = leftChildIndex;
            if (rightChildIndex < this.Size && list[leftChildIndex].CompareTo(list[rightChildIndex])<0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (list[index].CompareTo(list[maxChildIndex]) < 0)
            {
                var temp = list[index];
                list[index] = list[maxChildIndex];
                list[maxChildIndex] = temp;
                HeapifyDown(maxChildIndex);

            }
        }



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
            if (list.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return list[0];
        }
    }
}
