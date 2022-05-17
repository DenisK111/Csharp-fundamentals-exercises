using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.The_V_Logger
{
    class Program
    {

        /* Create a program that keeps the information about vloggers and their followers. The input will come as a sequence of strings, where each string will represent a valid command. The commands will be presented in the following format:
•	"{vloggername}" joined The V-Logger – keep the vlogger in your records.
o	Vloggernames consist of only one word.
o	If the given vloggername already exists, ignore that command.

•	"{vloggername} followed {vloggername}" – The first vlogger followed the second vlogger.
o	If any of the given vlogernames does not exist in your collection, ignore that command.
o	Vlogger cannot follow himself
o	Vloggers cannot follow someone he is already a follower of

•	"Statistics" - Upon receiving this command, you have to print a statistic about the vloggers.
Each vlogger has a unique vloggername. Vloggers can follow other vloggers and a vlogger can follow as many other vloggers as he wants, but he cannot follow himself or follow someone he is already a follower of. You need to print the total count of vloggers in your collection. Then you have to print the most famous vlogger – the one with the most followers, with his followers. If more than one vloggers have the same number of followers, print the one following fewer people, and his followers should be printed in lexicographical order (in case the vlogger has no followers, print just the first line, which is described below). Lastly, print the rest vloggers, ordered by the count of followers in descending order, then by the number of vloggers he follows in ascending order. The whole output must be in the following format:
"The V-Logger has a total of {registered vloggers} vloggers in its logs.
1. {mostFamousVlogger} : {followers} followers, {followings} following
*  {follower1}
*  {follower2} … 
{No}. {vlogger} : {followers} followers, {followings} following
{No}. {vlogger} : {followers} followers, {followings} following…"
Input
•	The input will come in the format described above.
Output
•	On the first line, print the total count of vloggers in the format described above.
•	On the second line, print the most famous vlogger in the format described above.
•	On the next lines, print all of the rest vloggers in the format described above.
Constraints
•	There will be no invalid input.
•	There will be no situation where two vloggers have an equal count of followers and equal count of followings
•	Allowed time/memory: 100ms/16MB.
*/
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<HashSet<string>, int>> vloggers = new Dictionary<string, Dictionary<HashSet<string>, int>>();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Statistics")
                {
                    break;
                }

                string name = command[0];
                string action = command[1];
                if (action == "joined")
                {
                    if (!vloggers.ContainsKey(name))
                    {
                        vloggers[name] = new Dictionary<HashSet<string>, int>();
                        vloggers[name].Add(new HashSet<string>(), 0);
                    }

                    
                }

                else
                {
                    string followed = command[2];

                    if (!vloggers.ContainsKey(name) || !vloggers.ContainsKey(followed) || name == followed)
                    {
                        continue;
                    }

                    vloggers[name][vloggers[name].Keys.First()] += vloggers[followed].Keys.First().Contains(name) ? 0 : 1;
                    vloggers[followed].Keys.First().Add(name); // check!

                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int num = 0;
            foreach (var vlogger in vloggers.OrderByDescending(x=>x.Value.Keys.First().Count).ThenBy(x=> x.Value.Values.First()))
            {
                num++;
                Console.WriteLine($"{num}. {vlogger.Key} : {vlogger.Value.Keys.First().Count} followers, {vlogger.Value[vlogger.Value.Keys.First()]} following");
                if (num == 1 && vlogger.Value.Keys.First().Count > 0)
                {
                    foreach (var follower in vlogger.Value.Keys.First().OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }

            
        }

       
    }
}
