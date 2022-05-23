using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Predicate_Party
{
    class Program
    {

        /* Ivan’s parents are on a vacation for the holidays and he is planning an epic party at home. Unfortunately, his organizational skills are next to non-existent, so you are given the task to help him with the reservations.
On the first line, you receive a list of all the people that are coming. On the next lines, until you get the "Party!" command, you may be asked to double or remove all the people that apply to the given criteria. There are three different criteria: 
•	Everyone that has his name starting with a given string
•	Everyone that has a name ending with a given string
•	Everyone that has a name with a given length.
Finally, print all the guests who are going to the party separated by ", " and then add the ending "are going to the party!". If no guests are going to the party print "Nobody is going to the party!". See the examples below:
*/
        static void Main(string[] args)
        {
            List<string> listOfNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();


            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Party!")
                {
                    break;
                }
                string action = command[0];
                string parameter = command[1];
                string argument = command[2];


                Action<List<string>> modify = Modify(action, parameter, argument);
                modify(listOfNames);

            }

            if (listOfNames.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");

            }

            else
            {
                Console.Write(String.Join(", ", listOfNames));
                Console.WriteLine(" are going to the party!");
            }
        }

        private static Action<List<string>> Modify(string action, string parameter, string argument)
        {
            Predicate<string> startsEndsWith = x => parameter == "StartsWith" ? (x.StartsWith(argument) ? true : false) : (x.EndsWith(argument) ? true : false);
            
            switch (action)
            {
                case "Double":
                    if (parameter == "StartsWith" || parameter == "EndsWith")
                    {
                        return namesList =>
                        {
                            for (int i = 0; i < namesList.Count; i++)
                            {
                                if (startsEndsWith(namesList[i]))
                                {
                                    namesList.Insert(i, namesList[i]);
                                    i++;
                                }
                            }

                        };
                    }



                    if (parameter == "Length")
                    {
                        return namesList =>
                        {
                            for (int i = 0; i < namesList.Count; i++)
                            {
                                if (namesList[i].Length == int.Parse(argument))
                                {
                                    namesList.Insert(i, namesList[i]);
                                    i++;
                                }


                            }

                        };
                    }

                    break;

                case "Remove":
                    if (parameter == "StartsWith" || parameter == "EndsWith")
                    {
                        return y => y.RemoveAll(x => startsEndsWith(x));

                    }
                    if (parameter == "Length")
                    {
                        return x => x.RemoveAll(y => y.Length == int.Parse(argument));
                    }

                    break;




            }

            return null;
        }
    }
}
