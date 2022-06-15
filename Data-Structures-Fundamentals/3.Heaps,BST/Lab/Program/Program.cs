using _01.BinaryTree;
using System;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BinaryTree<int> tree = new BinaryTree<int>(17,
                new BinaryTree<int>(9, new BinaryTree<int>(3, null, null),
                        new BinaryTree<int>(11, null, null)),
                new BinaryTree<int>(25, new BinaryTree<int>(20, null, null),
                        new BinaryTree<int>(31, null, null)));

            Console.WriteLine(tree.AsIndentedPreOrder(0));
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(String.Join(" ", tree.PreOrder().Select(x => x.Value)));
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(String.Join(" ", tree.InOrder().Select(x => x.Value)));
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(String.Join(" ", tree.PostOrder().Select(x => x.Value)));
            Console.WriteLine(new string('-', 50));
            tree.ForEachInOrder(x => Console.Write(x + " "));

        }
    }
}
