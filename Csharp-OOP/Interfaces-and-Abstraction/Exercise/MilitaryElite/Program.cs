using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> staffList = new Dictionary<string, ISoldier>();

            // Enum.IsDefined(typeof(SpecialisedSoldier.CorpsEnum), input);
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "End")
                {
                    break;
                }

                string type = command[0];
                string id = command[1];
                string firstName = command[2];
                string lastName = command[3];

                if (type == "Spy")
                {
                    int codeNumber = int.Parse(command[4]);

                    staffList[id] = new Spy(id, firstName, lastName, codeNumber);
                }

                else
                {
                    decimal salary = decimal.Parse(command[4]);

                    if (type == "Private")
                    {
                        staffList[id] = new Private(id, firstName, lastName, salary);
                    }

                    else if (type == "LieutenantGeneral")
                    {
                        Dictionary<string, ISoldier> privateList = new Dictionary<string, ISoldier>();
                        for (int i = 5; i < command.Length; i++)
                        {
                            privateList[command[i]] = staffList[command[i]];
                        }
                        staffList[id] = new LieutenantGeneral(id, firstName, lastName, salary, privateList);
                    }

                    else
                    {
                        string corps = command[5];

                        if (!Enum.IsDefined(typeof(CorpsEnum), corps))
                        {
                            continue;
                        }

                        else if (type == "Engineer")
                        {
                            Dictionary<string, int> repairs = new Dictionary<string, int>();

                            for (int i = 6; i < command.Length; i += 2)
                            {
                                repairs[command[i]] = int.Parse(command[i + 1]);
                            }

                            staffList[id] = new Engineer(id, firstName, lastName, salary, corps, repairs);

                        }

                        else if (type == "Commando")
                        {

                            Dictionary<string, StateEnum> missions = new Dictionary<string, StateEnum>();
                           // var enumtype = typeof(StateEnum);

                            
                            for (int i = 6; i < command.Length; i += 2)
                            {
                                if (!Enum.IsDefined(typeof(StateEnum),command[i+1]))
                                {
                                    continue;
                                }
                                missions[command[i]] = Enum.Parse<StateEnum>(command[i + 1]);
                            }

                            staffList[id] = new Commando(id, firstName, lastName, salary, corps, missions);

                            

                        }

                    }

                }



            }

            foreach (var (id,officer) in staffList)
            {
                Console.WriteLine(officer);
            }

        }
    }
}
