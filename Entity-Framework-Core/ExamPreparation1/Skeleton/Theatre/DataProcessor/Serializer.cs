namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var result = context.Theatres.Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                  .Include(x=>x.Tickets)
                  .ToList()
                 .Select(x => new
                 {
                     Name = x.Name,
                     Halls = x.NumberOfHalls,
                     TotalIncome = x.Tickets.Where(y => y.RowNumber >= 1 && y.RowNumber <= 5)
                     .Sum(p => p.Price),
                     Tickets = x.Tickets.Where((y) => y.RowNumber >= 1 && y.RowNumber <= 5)
                     .Select(t => new
                     {
                         Price = t.Price,
                         RowNumber = t.RowNumber

                     })
                     .OrderByDescending(t => t.Price)
                     .ToList()

                 })
                 .OrderByDescending(
                        t => t.Halls)
                 .ThenBy(t => t.Name)
                 .ToList();

            return JsonConvert.SerializeObject(result,Formatting.Indented);

/*The given method in the project’s skeleton receives a number representing the number of halls. Export all theaters where the hall's count is bigger or equal to the given and have 20 or more tickets available. For each theater, export its Name, Halls, TotalIncome of tickets which are between the first and fifth row inclusively, and Tickets. For each ticket (between first and fifth row inclusively), export its price, and the row number. Order the theaters by the number of halls descending, then by name (ascending). Order the tickets by price descending.
*/
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var sb = new StringBuilder();
            /*  var result = context.Plays

                  .ToList()
                  .Where(x => x.Rating <= rating)
                  .Select(p => new XmlExportDto
                  {

                      Title = p.Title,
                      Rating = p.Rating == 0f ? "Preimer" : p.Rating.ToString(CultureInfo.InvariantCulture),
                      Duration = p.Duration.ToString("c"),
                      Genre = Enum.GetName(typeof(Genre),p.Genre),

                      Actors = p.Casts.Where(s => s.IsMainCharacter)
                          .Select(r => new Actors
                          {
                              FullName = r.FullName,
                              MainCharacter = $"Plays main character in '{p.Title}'.",
                          })
                          .OrderByDescending(r => r.FullName)
                          .ToArray()




                  })
                  .OrderBy(x=>x.Title)
                  .ThenByDescending(x=>x.Genre)
                  .ToArray();*/

            var plays = context.Plays
               .ToList()
               .Where(p => p.Rating <= rating)
               .Select(p => new XmlExportDto()
               {
                   Title = p.Title,
                   Rating = p.Rating == 0f ? "Premier" : p.Rating.ToString(CultureInfo.InvariantCulture),
                   Duration = p.Duration.ToString("c"),
                   Genre = Enum.GetName(typeof(Genre), p.Genre),
                   Actors = p.Casts
                       .Where(c => c.IsMainCharacter)
                       .Select(c => new Actors()
                       {
                           FullName = c.FullName,
                           MainCharacter = $"Plays main character in '{p.Title}'."
                       })
                       .OrderByDescending(a => a.FullName)
                       .ToArray()
               })
               .OrderBy(p => p.Title)
               .ThenByDescending(p => p.Genre)
               .ToArray();


            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            var root = new XmlRootAttribute("Plays");
            var importer = new XmlSerializer(typeof(XmlExportDto[]), root);
            
            var returned = string.Empty;
                importer.Serialize(new StringWriter(sb), plays,ns);
            return sb.ToString();

/*Use the method provided in the project skeleton, which receives a rating. Export all plays with a rating equal or smaller to the given. For each play, export Title, Duration (in the format: "c"), Rating, Genre, and Actors which play the main character only. 
Keep in mind:
⦁	If the rating is 0, you should print "Premier". 
⦁	For each actor display:
⦁	FullName 
⦁	MainCharacter in the format: "Plays main character in '{playTitle}'."
Order the result by play title (ascending), then by genre (descending). Order actors by their full name descending.
*/
        }
    }
}
