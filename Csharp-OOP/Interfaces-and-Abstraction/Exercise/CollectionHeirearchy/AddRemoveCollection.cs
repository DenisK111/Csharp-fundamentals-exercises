using CollectionHeirearchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHeirearchy
{
    public class AddRemoveCollection : AddCollection, IRemovable
    {
       

     
        public override int Add(string item)
        {
            this.Collection.Insert(0, item);
            return 0;
        }
        public virtual string Remove()
        {
            var lastItem = Collection[Collection.Count - 1];
            Collection.RemoveAt(Collection.Count - 1);
            return lastItem;
        }
    }
}
