using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> listOfTeams = new List<Team>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(";");

                if (command[0] == "END")
                {
                    break;
                }

                string action = command[0];

                try
                {

              
                switch (action)
                {
                    case "Team":
                        Team team = new Team(command[1]);
                            
                        listOfTeams.Add(team);
                        break;
                    case "Add":

                        if (listOfTeams.Any(x=>x.Name == command[1]))
                        {
                            listOfTeams.First(x => x.Name == command[1]).AddPlayer(new Player(command[2], int.Parse(command[3]), int.Parse(command[4]), int.Parse(command[5]), int.Parse(command[6]), int.Parse(command[7])));
                        }

                        else
                        {
                            Console.WriteLine($"Team {command[1]} does not exist.");
                        }
                        break;
                    case "Remove":

                        if (listOfTeams.Any(x => x.Name == command[1]))
                        {
                            listOfTeams.First(x => x.Name == command[1]).RemovePlayer(command[2]);
                        }

                        else
                        {
                            Console.WriteLine($"Team {command[1]} does not exist.");
                        }

                        break;
                    case "Rating":

                            try
                            {

                                Console.WriteLine(listOfTeams.First(x => x.Name == command[1]));
                            }

                            catch
                            {
                                Console.WriteLine($"Team {command[1]} does not exist.");
                            }
                        break;
                    
                    default:
                        break;
                }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
