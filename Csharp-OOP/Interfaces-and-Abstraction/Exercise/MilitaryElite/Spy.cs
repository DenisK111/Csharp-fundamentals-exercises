using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName,int codeNumber) : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.firstName} {this.lastName} Id: {this.Id}");
            sb.AppendLine($"Code Number: {this.CodeNumber}");
            return sb.ToString().TrimEnd();
        }
    }
}
