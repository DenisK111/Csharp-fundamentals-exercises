using CollectionHeirearchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHeirearchy
{
    public abstract class AbstractCollection : IAddable
    {
        

        public AbstractCollection()
        {
            this.Collection = new List<string>();
        }
        protected List<string> Collection { get; private set; }
        public abstract int Add(string item);
        
    }
}
