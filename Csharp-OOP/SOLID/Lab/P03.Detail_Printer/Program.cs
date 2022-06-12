using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            DetailsPrinter detailsPrinter = new DetailsPrinter(new List<IEmployee> { new Manager("Ivan",new List<string>()), new Employee("Peshno"),new Engineer("Gosho") });

            detailsPrinter.PrintDetails();

            Employee employee = new Manager("John", new List<string>());



            Console.WriteLine(employee.IsMatch(new Engineer("Ivan")));
        }
    }
}
