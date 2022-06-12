using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
   public class Program
    {
        public static void Main(string[] args)
        {

            Tree<int> tree = new Tree<int>(5,
                new Tree<int>(5,new Tree<int>(10),new Tree<int>(12,new Tree<int>(190), new Tree<int>(200))),
                new Tree<int>(10, new Tree<int>(180), new Tree<int>(4)),
                new Tree<int>(12, new Tree<int>(13), new Tree<int>(16))
                );

            Console.WriteLine(String.Join(", ",tree.OrderDfs()));
        }
    }
}
