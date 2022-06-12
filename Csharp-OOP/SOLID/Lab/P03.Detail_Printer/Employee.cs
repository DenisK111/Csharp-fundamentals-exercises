using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace P03.DetailPrinter
{
    public class Employee : IEmployee
    {
        public Employee(string name) 
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public virtual string GetDetails()
        {
            return this.Name;
        }

        public bool IsMatch(IEmployee employee)
        {
            
            if (this.GetType().Name == employee.GetType().Name) 
            {
                return true;
            }

            return false;
        }
    }
}
