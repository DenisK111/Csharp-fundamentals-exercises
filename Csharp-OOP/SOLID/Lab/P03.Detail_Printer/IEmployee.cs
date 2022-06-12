using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
    public interface IEmployee
    {
        public string Name { get; }

        string GetDetails();

        bool IsMatch(IEmployee employee);
    }
}
