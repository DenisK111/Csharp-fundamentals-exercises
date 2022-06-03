using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero : IHero
    {
        
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; }

        public int Power { get; }
        public abstract string CastAbility();
       
        
    }
}
