using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHeirearchy
{
    public class AddCollection : AbstractCollection
    {
        

     
        public override int Add(string item)
        {
            this.Collection.Add(item);
            return Collection.Count - 1;
        }
    }
}
