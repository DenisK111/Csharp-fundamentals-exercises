namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ImportDto;
    using AutoMapper;
    using Theatre.Data.Models;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var root = new XmlRootAttribute("Plays");
            var importer = new XmlSerializer(typeof(ImportPlaysRealXmlDto[]), root);

            var results = (ImportPlaysRealXmlDto[])importer.Deserialize(new StringReader(xmlString));

            foreach (var item in results)
            {
                var enumHashSet = new HashSet<string>() { "Drama",
        "Comedy",
        "Romance",
        "Musical" };
                var validateEnum = enumHashSet.Contains(item.Genre);
                var mapper = Mapper.Configuration.CreateMapper();
                if (string.IsNullOrEmpty(item.Screenwriter) || string.IsNullOrEmpty(item.Title) || string.IsNullOrEmpty(item.Description) || !TimeSpan.TryParseExact(item.Duration,"c",CultureInfo.InvariantCulture,out TimeSpan resultTS) || resultTS.Hours <1 || (item.Rating <0 || item.Rating > 10) || !validateEnum)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                context.Add(mapper.Map<Play>(item));
                context.SaveChanges();


                sb.AppendLine($"Successfully imported {item.Title} with genre {item.Genre} and a rating of {item.Rating}!");
            }

            return sb.ToString();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var root = new XmlRootAttribute("Casts");
            var importer = new XmlSerializer(typeof(ImportPlaysXmlDto[]), root);

            var mapper = Mapper.Configuration.CreateMapper();
            var results = (ImportPlaysXmlDto[])importer.Deserialize(new StringReader(xmlString));
         
            foreach (var item in results)
            {
                if (item.FullName.Length<4 || item.FullName.Length > 30 || !Regex.IsMatch(item.PhoneNumber, @"^\+44-\d{2}-\d{3}-\d{4}$"))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                context.Add(mapper.Map<Cast>(item));
                context.SaveChanges();

                string record = item.IsMainCharacter ? "main" : "lesser";
                sb.AppendLine($"Successfully imported actor {item.FullName} as a {record} character!");
            }

            return sb.ToString();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {

            var entries = JsonConvert.DeserializeObject<Theatre[]>(jsonString);
            var sb = new StringBuilder();
            foreach (var entry in entries)
            {
                if (entry.Name.Length<4 || entry.Name.Length > 30 || entry.Director.Length < 4 || entry.Director.Length > 30 || entry.NumberOfHalls <0 || entry.NumberOfHalls > 10)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var ticketsToAdd = new List<Ticket>();
                foreach (var ticket in entry.Tickets)
                {
                    
                    if (ticket.Price<1 || ticket.Price >100 || ticket.RowNumber < 1 || ticket.RowNumber > 10)
                    {
                        
                        sb.AppendLine("Invalid data!");



                        continue;
                    }

                    ticketsToAdd.Add(ticket);
                }

                entry.Tickets = ticketsToAdd;

                context.Add(entry);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported theatre {entry.Name} with #{entry.Tickets.Count} tickets!");
            }

            return sb.ToString();

            /*"Name": "",
    "NumberOfHalls": 7,
    "Director": "Ulwin Mabosty",
    "Tickets": [
      {
        "Price": 7.63,
        "RowNumber": 5,
        "PlayId": 4
      },
      {
        "Price": 47.96,
        "RowNumber": 9,
        "PlayId": 3
      }
    ]
*/
        }


        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
