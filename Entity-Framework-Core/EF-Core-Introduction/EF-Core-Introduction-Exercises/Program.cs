using System;
using SoftUni.Data;
using SoftUni.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Collections.Generic;

namespace SoftUni
{
    public class StartUp
    {
        //ALWAYS CHECK CONNECTION STRING
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            // Console.WriteLine(GetEmployeesFullInformation(db));
            // Console.WriteLine(GetEmployeesWithSalaryOver50000(db));
            // Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));
            // Console.WriteLine(AddNewAddressToEmployee(db));
            // Console.WriteLine(GetEmployeesInPeriod(db));
            // Console.WriteLine(GetAddressesByTown(db));
            // Console.WriteLine(GetEmployee147(db));
            // Console.WriteLine(GetDepartmentsWithMoreThan5Employees(db));
            // Console.WriteLine(GetLatestProjects(db));
            // Console.WriteLine(IncreaseSalaries(db));
            // Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(db));
            // Console.WriteLine(RemoveTown(db));
            // Console.WriteLine(DeleteProjectById(db));


        }

        public static string DeleteProjectById(SoftUniContext context)
        {

            var projects = context.EmployeesProjects.Where(x => x.ProjectId == 2);
            context.RemoveRange(projects);
            context.Remove(context.Projects.Find(2));
            context.SaveChanges();
            return String.Join(Environment.NewLine,context.Projects.Select(x=>x.Name).Take(10));
        }



        public static string RemoveTown(SoftUniContext context)
        {

            /*Write a program that deletes a town with name „Seattle”. Also, delete all addresses that are in those towns. Return the number of addresses that were deleted in format “{count} addresses in Seattle were deleted”. There will be employees living at those addresses, which will be a problem when trying to delete the addresses. So, start by setting the AddressId of each employee for the given address to null. After all of them are set to null, you may safely remove all the addresses from the context.Addresses and finally remove the given town.
*/
            var employees = context.Employees.Where(x => x.Address.Town.Name == "Seattle");

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            var addresses = context.Addresses.Where(x => x.Town.Name == "Seattle");
            var count = addresses.Count();
            context.RemoveRange(addresses);
            context.Remove(context.Towns.First(x => x.Name == "Seattle"));

            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            /*Write a program that finds all employees whose first name starts with "Sa". Return their first, last name, their job title and salary, rounded to 2 symbols after the decimal separator in the format given in the example below. Order them by first name, then by last name (ascending).*/

            return string.Join(Environment.NewLine, context.Employees.Where(x => x.FirstName.StartsWith("Sa")).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).Select(x => $"{x.FirstName} {x.LastName} - {x.JobTitle} - (${x.Salary:f2})"));




        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            //Write a program that increase salaries of all employees that are in the Engineering, Tool Design, Marketing or Information Services department by 12%. Then return first name, last name and salary (2 symbols after the decimal separator) for those employees whose salary was increased. Order them by first name (ascending), then by last name (ascending). Format of the output.
            HashSet<string> departments = new HashSet<string> { "Engineering",
                                                                "Tool Design", "Marketing", "Information Services" };
            var employees = context.Employees.Where(x => departments.Contains(x.Department.Name));

            foreach (var employee in employees)
            {

                  employee.Salary *= 1.12m;
            }

            context.SaveChanges();


            return String.Join(Environment.NewLine, employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).Select(em => $"{em.FirstName} {em.LastName} (${em.Salary:f2})"));
        }

        public static string GetEmployee147(SoftUniContext context)
        {

            /*Get the employee with id 147. Return only his/her first name, last name, job title and projects (print only their names). The projects should be ordered by name (ascending). Format of the output.*/
            StringBuilder sb = new StringBuilder();
            var employee = context.Employees.Include(em => em.EmployeesProjects).ThenInclude(ep => ep.Project).First(x => x.EmployeeId == 147);
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.EmployeesProjects.OrderBy(x => x.Project.Name))
            {
                sb.AppendLine(project.Project.Name);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            /*Now we can use the SoftUniContext to extract data from our database. Your first task is to extract all employees and return their first, last and middle name, their job title and salary, rounded to 2 symbols after the decimal separator, all of those separated with a space. Order them by employee id.*/

            var extractedData = context.Employees
                .OrderBy(emp => emp.EmployeeId)
                .Select(emp => string.Join(' ', emp.FirstName, emp.LastName,
            emp.MiddleName,
            emp.JobTitle,
            $"{emp.Salary:f2}"))
                .ToHashSet();
            return String.Join(Environment.NewLine, extractedData);
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            /*Your task is to extract all employees with salary over 50000. Return their first names and salaries in format “{firstName} - {salary}”.Salary must be rounded to 2 symbols, after the decimal separator. Sort them alphabetically by first name.
*/

            return String.Join(Environment.NewLine, context.Employees.Where(emp => emp.Salary > 50000).OrderBy(emp => emp.FirstName).Select(emp => $"{emp.FirstName} - {emp.Salary:f2}"));
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            /*Extract all employees from the Research and Development department. Order them by salary (in ascending order), then by first name (in descending order). Return only their first name, last name, department name and salary rounded to 2 symbols, after the decimal separator in the format shown below:*/

            var extracted = context.Employees.Where(emp => emp.Department.Name == "Research and Development").OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName).Select(x => $"{x.FirstName} {x.LastName} from {x.Department.Name} - ${x.Salary:f2}");

            return String.Join(Environment.NewLine, extracted);
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            /*
             * Create a new address with text "Vitoshka 15" and TownId 4. Set that address to the employee with last name "Nakov".
Then order by descending all the employees by their Address’ Id, take 10 rows and from them, take the AddressText. Return the results each on a new line:
*/
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4

            };
            context.Addresses.Add(newAddress);

            var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            nakov.Address = newAddress;
           
           context.SaveChanges();
            var firstTenRows = context.Employees.OrderByDescending(x => x.Address.AddressId).Take(10).Select(x => x.Address.AddressText);

            return String.Join(Environment.NewLine, firstTenRows);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            /*Find the first 10 employees who have projects started in the period 2001 - 2003 (inclusive). Print each employee's first name, last name, manager’s first name and last name. Then return all of their projects in the format "--<ProjectName> - <StartDate> - <EndDate>", each on a new row. If a project has no end date, print "not finished" instead.
*/
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.Include(x => x.Manager).Include(em => em.EmployeesProjects).ThenInclude(em => em.Project).Where(emp => emp.EmployeesProjects.Any(pr => pr.Project.StartDate.Year >= 2001 && pr.Project.StartDate.Year <= 2003)).Select(em => new
            {
                FirstName = em.FirstName,
                LastName = em.LastName,
                ManagerFirstName = em.Manager.FirstName,
                ManagerLastName = em.Manager.LastName,
                Project = em.EmployeesProjects.Select(ep => ep.Project)

            }).Take(10);



            foreach (var em in employees)
            {
                sb.AppendLine($"{em.FirstName} {em.LastName} - Manager: {em.ManagerFirstName} {em.ManagerLastName}");
                foreach (var project in em.Project)
                {
                    
                    sb.AppendLine($"--{project.Name} - {project.StartDate} - {(project.EndDate.HasValue ? project.EndDate.ToString() : "not finished")}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            /*Find all addresses, ordered by the number of employees who live there (descending), then by town name (ascending), and finally by address text (ascending). Take only the first 10 addresses. For each address return it in the format "<AddressText>, <TownName> - <EmployeeCount> employees"
*/
            var addresses = context.Addresses.Include(ad => ad.Town).Include(ad => ad.Employees).OrderByDescending(x => x.Employees.Count()).ThenBy(x => x.Town.Name).ThenBy(x => x.AddressText).Select(ad => $"{ad.AddressText}, {ad.Town.Name} - {ad.Employees.Count()} employees").Take(10);


            return String.Join(Environment.NewLine, addresses);

        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            /*Find all departments with more than 5 employees. Order them by employee count (ascending), then by department name (alphabetically). 
For each department, print the department name and the manager’s first and last name on the first row. 
Then print the first name, the last name and the job title of every employee on a new row. 
Order the employees by first name (ascending), then by last name (ascending).
Format of the output: For each department print it in the format "<DepartmentName> - <ManagerFirstName>  <ManagerLastName>" and for each employee print it in the format "<EmployeeFirstName> <EmployeeLastName> - <JobTitle>".
*/
            StringBuilder sb = new StringBuilder();
            var departments = context.Departments.Include(x => x.Manager).Where(x => x.Employees.Count > 5).OrderBy(x => x.Employees.Count).ThenBy(x => x.Name);

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            //Write a program that return information about the last 10 started projects. Sort them by name lexicographically and return their name, description and start date, each on a new row. Format of the output

            var last10Projects = context.Projects.OrderByDescending(pr => pr.StartDate).Take(10).OrderBy(x=>x.Name).Select(pr => $"{pr.Name}{Environment.NewLine}{pr.Description}{Environment.NewLine}{pr.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");

            return string.Join(Environment.NewLine, last10Projects);
        }

    }
}
