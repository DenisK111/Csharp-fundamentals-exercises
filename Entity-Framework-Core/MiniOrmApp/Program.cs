using MiniOrmApp.Data.Entities;
using System;
using System.Linq;

namespace MiniOrmApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ADD CONNECTION STRING BEFORE RUNNING
            var connectionString = "";// INSERT CONNECTION STRING
            var db = new SoftUniDbContext(connectionString);

            db.Employees.Add(new Employee
            {
                FirstName = "Doncho",
                LastName = "Papazov",
                DepartmentId = db.Departments.First().Id,
                IsEmployed = true


            });

            var employee = db.Employees.Last();
            employee.FirstName = "Modified";

            db.SaveChanges();
        }
    }
}
