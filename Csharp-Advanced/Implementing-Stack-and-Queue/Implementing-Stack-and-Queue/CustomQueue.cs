using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementing_Stack_and_Queue
{
    class CustomQueue
    {

        public CustomQueue()
        {
            items = new int[initialCapacity];
        }
        private int[] items;
        private int initialCapacity = 4;
        private int count = 0;

        public int Count { get; }

        public void Enqueue(int item)
        {

            Resize();
            items[count] = item;
            count++;
        }

        public int Dequeue()
        {
            IsEmpty();
            var returned = items[0];

            for (int i = 0; i < count-1; i++) // 4 6 7
            {
                items[i] = items[i + 1];

            }
            items[count - 1] = default;
            Shrink();
            count--;
            return returned;


        }

        public int Peek() { IsEmpty(); return items[0]; }



        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }

        }

        public void Clear()
        {
            IsEmpty();

            items = new int[initialCapacity];
            count = 0;

        }
        private void Shrink()
        {
            if (count < items.Length * 0.25)
            {
                var temp = items;
                items = new int[temp.Length / 2];

                for (int i = 0; i < count; i++)
                {
                    items[i] = temp[i];
                }
            }

        }

        private void Resize()
        {
            if (count > items.Length * 0.6)
            {
                var temp = items;
                items = new int[temp.Length * 2];

                for (int i = 0; i < count; i++)
                {
                    items[i] = temp[i];
                }
            }
        }

        private void IsEmpty()
        {

            if (count == 0)
            {
                throw new InvalidOperationException("Queue is Empty");
            }


        }
    }
}
