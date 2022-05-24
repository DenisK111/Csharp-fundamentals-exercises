using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementing_Stack_and_Queue
{
    /* The CustomList class should have the properties listed below:
•	int[] items - An array that will hold all of our elements
•	int Count – This property will return the count of items in the collection
•	indexer – The Indexer will provide us with functionality to access the elements using integer indexes
The structure will have internal methods to make the managing of the internal collection easier.
•	Resize – this method will be used to increase the internal collection's length twice
•	Shrink – this method will help us to decrease the internal collection's length twice 
•	Shift – this method will help us to rearrange the internal collection's elements after removing one.
    •	void Add(int element) - Adds the given element to the end of the list
•	int RemoveAt(int index) - Removes the element at the given index
•	bool Contains(int element) - Checks if the list contains the given element returns (True or False)
•	void Swap(int firstIndex, int secondIndex) - Swaps the elements at the given indexes

*/
    class CustomList
    {
        public CustomList()
        {
            items = new int?[initialCapacity];
            count = 0;
            
        }
        private const int initialCapacity = 2;
        private int?[] items;
        private int count;
        public int Count { get;}

        
        public int this[int index]
        {
            get 
            {

                ValidateIndex(index);
               
                return (int)items[index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;

            }

        }

        public void Add(int element)
        {
            items[count] = element;
            
            count++;
            Resize();
        }

        public int RemoveAt(int index)
        {

            if (index>= count || index<0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var returned = items[index];

            count--;
            Shift(index);
            Shrink();
            return (int)returned;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }

            return false;

        }
        public void Swap(int index1, int index2)
        {

            ValidateIndex(index1);
            ValidateIndex(index2);
            var temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;

           


        }

        public void Insert(int index,int item)
        {
            ValidateIndex(index);
            Resize();
            ShiftToRight(index,item);
            count++;

        }

        private void ShiftToRight(int index,int item)
        {
            var tempValue = items[index];
            items[index] = item;                   /// 2 6 3 4 5   6 temp = 4
            for (int i = index; i < count; i++)
            {
                var temp = items[i + 1]; //5
                items[i+1] = tempValue;  //4
                tempValue = temp; // 5

            }

        }

        private void Shift(int index)
        {
            // 1 2 4 5
            
            for (int i = index; i < count; i++)
            {
                items[i] = items[i + 1];
               
            }
            
            items[count] = null;
        }

        private void Resize()
        {

            if (count > items.Length * 0.6)
            {
                var temp = items;
                items = new int?[temp.Length * 2];

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
                items = new int?[temp.Length / 2];

                for (int i = 0; i < count; i++)
                {
                    items[i] = temp[i];
                }
            }

        }

        private void ValidateIndex(int index)
        {

            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
