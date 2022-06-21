using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> items;
        public Bag(int capacity = 100)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get; set; }
        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public int Load => Items.Select(x=>x.Weight).Sum();

        public void AddItem(Item item)
        {
            if (Load+item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!Items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            else if (!Items.Any(x=>x.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            else
            {
                var removed = Items.First(x => x.GetType().Name == name);
                items.Remove(removed);
                return removed;
            }
        }
    }

    /* Capacity – an integer number. Default value: 100
Load – Calculated property. The sum of the weights of the items in the bag.
Items – Read-only collection of type Item
*/
}
