using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        Dictionary<string, StateEnum> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps, Dictionary<string, StateEnum> missions) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new Dictionary<string, StateEnum>(missions);
        }

        public IReadOnlyDictionary<string, StateEnum> Missions { get=>missions; }

       

        public void CompleteMission(string codeName)
        {
            this.missions[codeName] = StateEnum.Finished;

        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(privateFunc.Invoke(this));
            sb.AppendLine(corpsStringFunc(this));
            sb.AppendLine("Missions:");
            foreach (var item in Missions)
            {
                sb.AppendLine($"  Code Name: {item.Key} State: {item.Value}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
