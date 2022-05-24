using System;

namespace GenericScale
{
    public class EqualityScale<T> 
        
    {
        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }

        public T Left { get;  }
        public T Right { get;  }

        public bool AreEqual()
        {
            
            return Left.Equals(Right);
        }
    }
}