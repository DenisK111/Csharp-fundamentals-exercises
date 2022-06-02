using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName,decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        protected Func<IPrivate, string> privateFunc = a => $"Name: {a.firstName} {a.lastName} Id: {a.Id} Salary: {a.Salary:f2}";

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(privateFunc.Invoke(this));
           
            return sb.ToString().TrimEnd();
        }
    }
}
