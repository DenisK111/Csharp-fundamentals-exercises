using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public interface  IGiftOperations
    {

        public void AddGift(BaseGift gift);
        public void RemoveGift(BaseGift gift);
    }
}
