using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementing_Stack_and_Queue
{
    class CustomStack
    {

        public CustomStack()
        {
            items = new int[initialCapacity];
        }
        private int[] items;

        const int initialCapacity = 4;
        private int count;
        public int Count { get; }

        public void Push(int num)
        {
            Resize();
            items[count] = num;
            count++;

        }

        public int Pop()
        {
            IsEmpty();
            var returned = items[count - 1];

            count--;
            Shrink();
            return returned;
        }

        public int Peek() { IsEmpty(); return items[count-1]; }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
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

        private void IsEmpty()
        {

            if (count == 0)
            {
                throw new InvalidOperationException("Stack is Empty");
            }


        }


    }
}
