using ExplicitInterfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    class Citizen : IPerson, IResident
    {
        private string name;
        public Citizen(string name, string country, int age)
        {
            this.name = name;
            Country = country;
            Age = age;
        }

        string IResident.Name  { get { return name; } set { name = value; } }

         string IPerson.Name { get { return name; } set { name = value; } }

        public string Country { get; private set; }

        public int Age { get; private set; }
               

      
    }
}
