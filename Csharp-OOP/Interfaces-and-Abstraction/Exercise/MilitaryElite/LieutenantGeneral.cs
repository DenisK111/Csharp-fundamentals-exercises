using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        Dictionary<string, ISoldier> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, Dictionary<string, ISoldier> privates) : base(id, firstName, lastName, salary)
        {
            this.privates = new Dictionary<string, ISoldier>(privates);
        }

        public IReadOnlyDictionary<string, ISoldier> Privates => privates;

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(privateFunc.Invoke(this));
            sb.AppendLine("Privates:");
            foreach (var item in Privates)
            {
                sb.AppendLine($"  {item.Value.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
