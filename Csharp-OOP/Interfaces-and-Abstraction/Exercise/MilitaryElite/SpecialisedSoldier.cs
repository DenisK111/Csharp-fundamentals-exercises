using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {


        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            Corps = Enum.Parse<CorpsEnum>(corps) == CorpsEnum.Airforces ? CorpsEnum.Airforces : CorpsEnum.Marines;
        }

        public CorpsEnum Corps { get; private set; }

        protected Func<SpecialisedSoldier, string> corpsStringFunc = x => $"Corps: {x.Corps}";

    }
}
