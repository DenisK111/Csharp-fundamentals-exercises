using CollectionHeirearchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHeirearchy
{
    class MyList : AddRemoveCollection, ICountable
    {
       

      
        public int Used => this.Collection.Count;

     
        public override string Remove()
        {
            var removed = this.Collection[0];
            this.Collection.RemoveAt(0);
            return removed;
        }
    }
}
