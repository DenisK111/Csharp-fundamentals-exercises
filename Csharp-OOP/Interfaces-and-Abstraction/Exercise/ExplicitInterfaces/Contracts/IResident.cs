using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Contracts
{
    interface IResident
    {
        public string Name { get; set; }
        public string Country { get; }

        string GetName() => $"Mr/Ms/Mrs {Name}";
    }
}
