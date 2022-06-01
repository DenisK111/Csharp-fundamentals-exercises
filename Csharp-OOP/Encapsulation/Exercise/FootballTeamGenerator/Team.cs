using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
  public  class Team
    {

        private List<Player> players;
        private string name;
        private Dictionary<string, Dictionary<string,int>> stats;

        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = name;
            stats = new Dictionary<string, Dictionary<string, int>>();
            players = new List<Player>();
        }

        public int Rating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                return (int)Math.Round(stats.Average(x=>x.Value.Values.Average()));
            }
        }
        public string Name => this.name;

        public void AddPlayer(Player player)
        {
            stats[player.Name] = new Dictionary<string, int> { ["Endurance"] = player.Endurance, ["Sprint"] = player.Sprint, ["Dribble"] = player.Dribble, ["Passing"] = player.Passing, ["Shooting"] = player.Shooting };
                      

            players.Add(player);

        }

        public void RemovePlayer(string playerName)
        {
            if (players.FirstOrDefault(x=>x.Name == playerName) == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            players.Remove(players.First(x => x.Name == playerName));
            stats.Remove(playerName);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
