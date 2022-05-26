using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" ").ToList();

            input.RemoveAt(0);

            var iterator = new ListyIterator<string>(input.ToArray());
            try
            {
                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    switch (command)
                    {
                        case "Move":
                            Console.WriteLine(iterator.Move());
                            break;
                        case "Print":
                            iterator.Print();
                            break;
                        case "HasNext":
                            Console.WriteLine(iterator.HasNext());
                            break;
                        case "PrintAll":

                            iterator.PrintAll();

                            break;

                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
                        
        }
    }
}
