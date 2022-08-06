namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {

        public static string Serialize<T>(string rootName, T obj)
        {

            var sb = new StringBuilder();
            var root = new XmlRootAttribute(rootName);
            var nmspc = new XmlSerializerNamespaces();
            nmspc.Add(string.Empty, string.Empty);
            var serialiser = new XmlSerializer(typeof(T), root);
            serialiser.Serialize(new StringWriter(sb), obj, nmspc);
            return sb.ToString().TrimEnd();
        }
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var result = context.Projects
                .Include(p => p.Tasks)
                .ToList()
                .Where(p => p.Tasks.Any())
                .Select(p => new ExportDtoXml
                {
                    ProjectName = p.Name,
                    TasksCount = p.Tasks.Count(),
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks.Select(t => new TaskExportDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()

                    })
                    .OrderBy(t => t.Name)
                    .ToArray()

                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();



            /*Export all projects that have at least one task. For each project, export its name, tasks count, and if it has end (due) date which is represented like "Yes" and "No". For each task, export its name and label type. Order the tasks by name (ascending). Order the projects by tasks count (descending), then by name (ascending).
            NOTE: You may need to call .ToArray() function before the selection in order to detach entities from the database and avoid runtime errors (EF Core bug). 
            */

            var serialised = Serialize<ExportDtoXml[]>("Projects", result);
                return serialised;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {


            var result = context.Employees
                .Include(e=>e.EmployeesTasks)
                .ThenInclude(e=>e.Task)
                .ToList()
                .Where(d => d.EmployeesTasks.Any(x => x.Task.OpenDate.CompareTo(date) >=0))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks.Where(t => t.Task.OpenDate >= date)
                     .OrderByDescending(x => x.Task.DueDate)
                     .ThenBy(x => x.Task.Name)
                    .Select(et => new
                    {
                        TaskName = et.Task.Name,
                        OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = et.Task.LabelType.ToString(),
                        ExecutionType = et.Task.ExecutionType.ToString()
                    })


                })
                .OrderByDescending(e => e.Tasks.Count())
                .ThenBy(e => e.Username)
                .Take(10);

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return json;
            /*Select the top 10 employees who have at least one task that its open date is after or equal to the given date with their tasks that meet the same requirement (to have their open date after or equal to the giver date). For each employee, export their username and their tasks. For each task, export its name and open date (must be in format "d"), due date (must be in format "d"), label and execution type. Order the tasks by due date (descending), then by name (ascending). Order the employees by all tasks (meeting above condition) count (descending), then by username (ascending).
NOTE: Do not forget to use CultureInfo.InvariantCulture. You may need to call .ToArray() function before the selection in order to detach entities from the database and avoid runtime errors (EF Core bug). 
*/
        }
    }
}