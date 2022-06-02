using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
      
        protected Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string Id { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }

        
    }
}
