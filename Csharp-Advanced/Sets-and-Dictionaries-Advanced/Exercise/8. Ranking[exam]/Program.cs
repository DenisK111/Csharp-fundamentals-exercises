using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Ranking
{
    class Program
    {

        /*Here comes the final and the most interesting part – the Final ranking of the candidate-interns. The final ranking is determined by the points of the interview tasks and from the exams in SoftUni. Here is your final task. You will receive some lines of input in the format "{contest}:{password for contest}" until you receive "end of contests". Save that data because you will need it later. After that, you will receive another type of inputs in the format "{contest}=>{password}=>{username}=>{points}" until you receive "end of submissions". Here is what you need to do. 
•	Check if the contest is valid (if you received it in the first type of input)
•	Check if the password is correct for the given contest
•	Save the user with the contest they take part in (a user can take part in many contests) and the points the user has in the given contest. If you receive the same contest and the same user updates the points only if the new ones are more than the older ones.
In the end, you have to print the info for the user with the most points in the format "Best candidate is {user} with total {total points} points.". After that print all students ordered by their names. For each user print each contest with the points in descending order. See the examples.
Input
•	Strings in format "{contest}:{password for contest}" until the "end of contests" command. There will be no case with two equal contests
•	Strings in format "{contest}=>{password}=>{username}=>{points}" until the "end of submissions" command.
•	There will be no case with 2 or more users with the same total points!
Output
•	On the first line print, the best user in format "Best candidate is {user} with total {total points} points.". 
•	Then print all students ordered as mentioned above in format:
"{user1 name}"
"#  {contest1} -> {points}"
"#  {contest2} -> {points}"
Constraints
•	the strings may contain any ASCII character except from (:, =, >)
•	the numbers will be in range [0 - 10000]
•	second input is always valid
*/
        static void Main(string[] args)
        {
            var contestDictionary = new Dictionary<string, string>();
            var userDictionary = new Dictionary<string, User>();

            string[] inputContests = Console.ReadLine().Split(":");
            while (inputContests[0] != "end of contests")
            {
                contestDictionary.Add(inputContests[0], inputContests[1]);
                inputContests = Console.ReadLine().Split(":");
            }

            while (true)
            {
                string[] inputSubmissions = Console.ReadLine().Split("=>");

                if (inputSubmissions[0] == "end of submissions")
                {
                    break;
                }
                string contestName = inputSubmissions[0];
                string password = inputSubmissions[1];
                string userName = inputSubmissions[2];
                int score = int.Parse(inputSubmissions[3]);

                if (contestDictionary.FirstOrDefault(x => x.Key == contestName && x.Value == password).Key == null)
                {
                    continue; // check if contest name and password match and if not continue;
                }

                if (userDictionary.ContainsKey(userName))
                {
                    if (userDictionary[userName].ContestScore.ContainsKey(contestName))
                    {
                        var oldScore = userDictionary[userName].ContestScore[contestName];
                        userDictionary[userName].ContestScore[contestName] = score > oldScore ? score : oldScore;
                        continue; // check if user has been in that contest and if yes check the score and change it if necessary, then continuel;
                    }

                    else
                    {
                        userDictionary[userName].ContestScore.Add(contestName, score);
                        continue;
                    }
                }
                userDictionary.Add(userName, new User(score, contestName));


            }



            int totalScore = 0;
            string bestUser = string.Empty;
            foreach (var item in userDictionary) // item = <string,User>
            {
                int currentScore = 0;
                foreach (var entry in item.Value.ContestScore)
                {
                    currentScore += entry.Value;
                }

                if (currentScore > totalScore)
                {
                    totalScore = currentScore;
                    bestUser = item.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {totalScore} points.\nRanking: ");
            foreach (var item in userDictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var entry in item.Value.ContestScore.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {entry.Key} -> {entry.Value}");
                }

                //
                /* "{user1 name}"
                "#  {contest1} -> {points}"
                "#  {contest2} -> {points}"*/
            }

        }
    }

    class User
    {
        public User(int score, string contestName)
        {
            ContestScore = new Dictionary<string, int> { [contestName] = score };
        }
        public Dictionary<string, int> ContestScore { get; set; }


    }
}
