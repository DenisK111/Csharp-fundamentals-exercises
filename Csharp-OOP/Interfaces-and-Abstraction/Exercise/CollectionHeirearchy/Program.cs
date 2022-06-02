using CollectionHeirearchy.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CollectionHeirearchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            Dictionary<string, IAddable> dictionaryOfLists = new Dictionary<string, IAddable>();
            dictionaryOfLists["addCollection"] = addCollection;
            dictionaryOfLists["addRemoveCollection"] = addRemoveCollection;
            dictionaryOfLists["myList"] = myList;


            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[][] indexes = new int[3][];
            indexes[0] = new int[command.Length];
            indexes[1] = new int[command.Length];
            indexes[2] = new int[command.Length];

            int commandCount = 0;
            foreach (var item in command)
            {
                int count = 0;
                foreach (var (name, list) in dictionaryOfLists)
                {
                    indexes[count][commandCount] = list.Add(item);
                    count++;

                }
                commandCount++;
            }

            int n = int.Parse(Console.ReadLine());
            string[][] strings = new string[2][];
            strings[0] = new string[n];
            strings[1] = new string[n];


            for (int i = 0; i < n; i++)
            {
                int count = 0;

                foreach (var (name, list) in dictionaryOfLists.Where(x => x.Value is IRemovable))
                {
                    strings[count][i] = ((IRemovable)list).Remove();
                    count++;
                }
            }
              

               
           

            foreach (var item in indexes)
            {
                Console.WriteLine(String.Join(" ",item));
            }

            foreach (var item in strings)
            {
                Console.WriteLine(String.Join(" ", item));
            }

        }
    }
}
