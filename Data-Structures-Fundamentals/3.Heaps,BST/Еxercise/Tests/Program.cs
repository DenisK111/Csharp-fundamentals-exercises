using _01.BSTOperations;
using _02.LowestCommonAncestor;
using System;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            IAbstractBinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Insert(12);
            tree.Insert(21);
            tree.Insert(5);
            tree.Insert(1);
            tree.Insert(8);
            tree.Insert(18);
            tree.Insert(23);

            tree.EachInOrder(Console.WriteLine);

            BinaryTree<int> bst = new BinaryTree<int>(12,
                new BinaryTree<int>(5,
                        new BinaryTree<int>(1,null,null),
                        new BinaryTree<int>(8,null,null)),
                new BinaryTree<int>(21,
                        new BinaryTree<int>(18,null,null),
                        new BinaryTree<int>(23,null,null)));
            Console.WriteLine(new string(' ',50));
            var lca = bst.FindLowestCommonAncestor(18, 23);
            Console.WriteLine(lca);

        }
    }
}
