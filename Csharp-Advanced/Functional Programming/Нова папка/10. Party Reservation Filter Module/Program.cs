using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Party_Reservation_Filter_Module
{
    class Program
    {

        /* You need to implement a filtering module to a party reservation software. First, the Party Reservation Filter Module (PRFM for short) is passed a list with invitations. Next, the PRFM receives a sequence of commands that specify whether you need to add or remove a given filter.
Each PRFM command is in the given format:
"{command;filter type;filter parameter}"
You can receive the following PRFM commands: 
•	"Add filter"
•	"Remove filter"
•	"Print" 
The possible PRFM filter types are: 
•	"Starts with"
•	"Ends with"
•	"Length"
•	"Contains"
All PRFM filter parameters will be a string (or an integer only for the "Length" filter). Each command will be valid e.g. you won’t be asked to remove a non-existent filter. The input will end with a "Print" command, after which you should print all the party-goers that are left after the filtration. See the examples below:
*/
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();
            Dictionary<int, string> guestsDictionary = new Dictionary<int, string>();

            int index = 1;
            guests.ForEach(x =>
            {
                guestsDictionary.Add(index, x);
                index++;
            });

            Dictionary<int, string> filteredGuestsDictionary = new Dictionary<int, string>(guestsDictionary);

            while (true)
            {
                string[] commands = Console.ReadLine().Split(";");


                if (commands[0] == "Print")
                {
                    break;
                }

                string filterAction = commands[0];
                string filterType = commands[1];
                string filterParameter = commands[2];


                Func<Dictionary<int, string>, Dictionary<int, string>> filter = Filter(filterAction, guestsDictionary, filterType, filterParameter);
                filteredGuestsDictionary = filter(filteredGuestsDictionary);


            }

            foreach (var item in filteredGuestsDictionary.OrderBy(x => x.Key))
            {
                Console.Write($"{item.Value} ");
            }



        }




        private static Func<Dictionary<int, string>, Dictionary<int, string>> Filter(string filterAction, Dictionary<int, string> guestsDictionary, string filterType, string filterParameter)
        {
            if (filterAction == "Remove filter")
            {
                switch (filterType)
                {
                    case "Starts with":
                        return filteredDictionary => filteredDictionary.Union(guestsDictionary.Where(x => x.Value.StartsWith(filterParameter))).ToDictionary(x => x.Key, y => y.Value);
                    case "Ends with":
                        return filteredDictionary => filteredDictionary.Union(guestsDictionary.Where(x => x.Value.EndsWith(filterParameter))).ToDictionary(x => x.Key, y => y.Value);
                    case "Length":
                        return filteredDictionary => filteredDictionary.Union(guestsDictionary.Where(x => x.Value.Length == int.Parse(filterParameter))).ToDictionary(x => x.Key, y => y.Value);
                    case "Contains":
                        return filteredDictionary => filteredDictionary.Union(guestsDictionary.Where(x => x.Value.Contains(filterParameter))).ToDictionary(x => x.Key, y => y.Value);
                    default:
                        break;

                }
            }

            else if (filterAction == "Add filter")
            {
                switch (filterType)
                {
                    case "Starts with":
                        return filteredDictionary => filteredDictionary.Where(x => !x.Value.StartsWith(filterParameter)).ToDictionary(x => x.Key, y => y.Value);
                    case "Ends with":
                        return filteredDictionary => filteredDictionary.Where(x => !x.Value.EndsWith(filterParameter)).ToDictionary(x => x.Key, y => y.Value);
                    case "Length":
                        return filteredDictionary => filteredDictionary.Where(x => !(x.Value.Length == int.Parse(filterParameter))).ToDictionary(x => x.Key, y => y.Value);
                    case "Contains":
                        return filteredDictionary => filteredDictionary.Where(x => !x.Value.Contains(filterParameter)).ToDictionary(x => x.Key, y => y.Value);
                    default:
                        break;
                }
            }



            return x=>x;
        }


    }
}
