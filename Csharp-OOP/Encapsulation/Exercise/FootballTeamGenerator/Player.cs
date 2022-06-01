using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
       
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private Dictionary<string,int> stats;

        public Player(string name,int endurance,int sprint,int dribble, int passing, int shooting)

        {
            stats = new Dictionary<string, int> { ["Endurance"] = endurance, ["Sprint"] = sprint, ["Dribble"] = dribble, ["Passing"] = passing, ["Shooting"] = shooting };
            if (stats.Values.Any(x => x > 100 || x < 0))
            {
                throw new ArgumentException($"{stats.Keys.First(x => stats[x] > 100 || stats[x] < 0)} should be between 0 and 100.");
            }



            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing= passing;
            this.shooting = shooting;
            

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = name;
        }

        public string Name => this.name;

        public int Endurance => endurance;
        public int Sprint => sprint;
        public int Dribble => dribble;
        public int Passing => passing;
        public int Shooting => shooting;
      
      
       


    }
}
