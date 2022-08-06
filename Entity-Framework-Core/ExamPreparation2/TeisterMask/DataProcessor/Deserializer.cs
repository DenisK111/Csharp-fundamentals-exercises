namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static TDest GenerateDTO<TDest>(string rootName, string path)
        {

            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(TDest), root);


            using (StringReader reader = new StringReader(path))
            {
                return (TDest)serializer.Deserialize(reader);
            }
        }



        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var dtoArray = GenerateDTO<ImportProjectsDto[]>("Projects", xmlString);
            var sb = new StringBuilder();
            var mapper = Mapper.Configuration.CreateMapper();

            foreach (var dto in dtoArray)
            {
                var openDate = DateTime.TryParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, 0, out DateTime resultOd);
                var dueDate = DateTime.TryParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, 0, out DateTime resultDd);


                

                if (IsValid(dto) && openDate)
                {

                   


                    var validTasks = new List<TaskDto>();
                    foreach (var task in dto.Tasks)
                    {
                        var openDateTask = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, 0, out DateTime resultOTask);
                        var dueDateTask = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, 0, out DateTime resultDTask);


                        if (!IsValid(task) || resultOTask == default || resultDTask == default || resultOTask<resultOd || resultDTask < resultOd || (resultDd != default && (resultOTask > resultDd || resultDTask > resultDd)))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        validTasks.Add(task);
                    }

                    dto.Tasks = validTasks.ToArray();
                    var project = new Project()
                    {
                        Name = dto.Name,
                        OpenDate = resultOd,
                        DueDate = resultDd == default ? (DateTime?)null : resultDd,
                        Tasks = dto.Tasks.Select(x => new Task
                        {
                            Name = x.Name,
                            OpenDate = DateTime.ParseExact(x.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            DueDate = DateTime.ParseExact(x.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            ExecutionType = Enum.Parse<ExecutionType>(x.ExecutionType,true),
                            LabelType = Enum.Parse<LabelType>(x.LabelType, true)
                        })
                        .ToList()
                    };
                    context.Add(project);
                    context.SaveChanges();
                   sb.AppendLine($"Successfully imported project - {dto.Name} with {dto.Tasks.Count()} tasks.");
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            return sb.ToString().Trim();

        }

        public static ICollection<TSource> GenerateEntities<TSource>(string inputJson)
        {
            var TDto = JsonConvert.DeserializeObject<ICollection<TSource>>(inputJson);

            return TDto;
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var dtoArray = GenerateEntities<ImportEmployeeDto>(jsonString);

            var contextTasks = context.Tasks.Select(x => x.Id).ToList();
            foreach (var dto in dtoArray)
            {
                if (IsValid(dto))
                {
                    var validTasks = new HashSet<int>();
                    foreach (var task in dto.Tasks)
                    {
                        if (!contextTasks.Contains(task))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        validTasks.Add(task);
                    }

                    dto.Tasks = validTasks;

                    var employee = new Employee()
                    {
                        Username = dto.Username,
                        Email = dto.Email,
                        Phone = dto.Phone,



                    };

                    context.Add(employee);
                    context.SaveChanges();

                    foreach (var task in dto.Tasks)
                    {
                        var et = new EmployeeTask
                        {

                            Employee = employee,
                            Task = context.Tasks.Find(task)
                        };

                        context.EmployeesTasks.Add(et);
                        context.SaveChanges();
                    }
                    var line = $"{string.Format(SuccessfullyImportedEmployee, dto.Username,dto.Tasks.Count)}";

                    sb.AppendLine(line);
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}