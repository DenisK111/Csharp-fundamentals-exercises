namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int DefaultCapacity = 4;
        private readonly int initialCapacity;
        private LinkedList<KeyValue<TKey, TValue>>[] slots;
        private const decimal FillFactor = 0.75m;
        public int Count { get; private set; }

        public int Capacity => this.slots.Length;

        public HashTable() : this(DefaultCapacity)
        { }

        public HashTable(int capacity)
        {
            this.initialCapacity = capacity;
            slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public void Add(TKey key, TValue value)
        {
            this.AddOrReplace(key, value, funcValue => throw new ArgumentException());            
        }

        private int Hash(TKey key, int capacity)
        {
            return Math.Abs(key.GetHashCode()) % capacity;
        }

        private void GrowIfNeeded()
        {
            if ((decimal)(Count + 1) / Capacity > FillFactor)
            {
                var newCapacity = Capacity * 2;
                var newTable = new LinkedList<KeyValue<TKey, TValue>>[newCapacity];

                foreach (var list in slots.Where(slot => slot != null))
                {
                    foreach (var item in list)
                    {
                        var index = this.Hash(item.Key, newCapacity);
                        if (newTable[index] == null)
                        {
                            newTable[index] = new LinkedList<KeyValue<TKey, TValue>>();
                        }
                        newTable[index].AddLast(item);
                    }
                }

                this.slots = newTable;
            }
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            return AddOrReplace(key, value, funcValue => value);            
        }

        public TValue Get(TKey key) => this[key];
        

        public TValue this[TKey key]
        {
            get
            {
                int index = this.Hash(key, Capacity);
                if (this.slots[index] != null)
                {
                    foreach (var item in this.slots[index])
                    {
                        if (item.Key.Equals(key))
                        {
                            return item.Value;
                        }                       
                    }

                    throw new KeyNotFoundException();
                }

                throw new KeyNotFoundException();
            }
            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);

            if (element != null)
            {
                value = element.Value;
                return true;
            }

            value = default;
            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int index = this.Hash(key, Capacity);

            if (this.slots[index] is null) return null;

            foreach (var kvp in slots[index])
            {
                if (kvp.Key.Equals(key))
                {
                    return kvp;
                }
            }

            return null;
        }
     
        public bool ContainsKey(TKey key)
        {
            int index = this.Hash(key, Capacity);

            if (this.slots[index] is null) return false;

            foreach (var kvp in slots[index])
            {
                if (kvp.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;

        }

        public bool Remove(TKey key)
        {
            int index = this.Hash(key, Capacity);

            if (this.slots[index] is null) return false;

            var itemToRemove = slots[index].FirstOrDefault(x => x.Key.Equals(key));

            if (itemToRemove == null) return false;

            Count--;
            return slots[index].Remove(itemToRemove);
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[initialCapacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys => this.Select(kvp => kvp.Key);

        public IEnumerable<TValue> Values => this.Select(kvp => kvp.Value);       

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var list in slots.Where(slot => slot != null))
            {
                foreach (var item in list)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private bool AddOrReplace(TKey key, TValue value, Func<TValue,TValue> function)
        {
            this.GrowIfNeeded();
            int index = this.Hash(key, Capacity);

            if (this.slots[index] == null)
            {
                this.slots[index] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var item in this.slots[index])
            {
                if (item.Key.Equals(key))
                {
                     item.Value =  function(item.Value);
                    return true;
                }
            }

            this.slots[index].AddLast(new KeyValue<TKey, TValue>(key, value));
            this.Count++;
            return false;

        }
    }
}
