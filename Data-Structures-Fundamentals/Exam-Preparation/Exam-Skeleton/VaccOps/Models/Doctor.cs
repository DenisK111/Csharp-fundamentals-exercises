using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

namespace VaccOps.Models
{
    public class Doctor
    {
        public Doctor(string name, int popularity)
        {
            this.Name = name;
            this.Popularity = popularity;
        }

        public string Name { get; set; }
        public int Popularity { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Doctor)
            {
                var entity = (Doctor)obj;
                return entity.Name == this.Name;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
