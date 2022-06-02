using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        Dictionary<string, int> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps,Dictionary<string,int> repairs) : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new Dictionary<string, int>(repairs);
        }

        public IReadOnlyDictionary<string, int> Repairs => repairs;

        public override string ToString()
        {
            /* •	Engineer:
Name: <firstName> <lastName> Id: <id> Salary: <salary>
Corps: <corps>
*/

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(privateFunc.Invoke(this));
            sb.AppendLine(corpsStringFunc(this));
            sb.AppendLine("Repairs:");
            foreach (var item in Repairs)
            {
                sb.AppendLine($"  Part Name: {item.Key} Hours Worked: {item.Value}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
