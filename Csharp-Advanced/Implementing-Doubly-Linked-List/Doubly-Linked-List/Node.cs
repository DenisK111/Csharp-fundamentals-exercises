using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubly_Linked_List
{
    class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
    }
}
