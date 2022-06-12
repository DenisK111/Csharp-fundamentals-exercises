using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tree;


namespace CreateTree
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            TreeFactory factory = new TreeFactory();
            Dictionary<int, List<int>> inputValues = new Dictionary<int, List<int>>();
            string[] input = new string[n];

            for (int i = 0; i < n; i++)
            {
                input[i] = Console.ReadLine();



            }

            Tree<int> myTree = factory.CreateTreeFromStrings(input);

            Console.WriteLine(string.Join(' ',myTree.BfsPrint()));

            Console.WriteLine(myTree.GetAsString());
            Console.WriteLine(string.Join(" ",myTree.GetLeafKeys()));
            Console.WriteLine(string.Join(" ",myTree.GetMiddleKeys()));
            Console.WriteLine(myTree.GetDeepestLeftomostNode().Key);
            Console.WriteLine(myTree.GetDeepestLeftomostNode().Key);
            

        }
    }
}

