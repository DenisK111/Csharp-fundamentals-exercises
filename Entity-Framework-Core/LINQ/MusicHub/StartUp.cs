namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

        // DbInitializer.ResetDatabase(context);

           // Console.WriteLine(ExportAlbumsInfo(context, 9));
           // Console.WriteLine(ExportSongsAboveDuration(context,4));


        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {


            /*You need to write method string ExportAlbumsInfo(MusicHubDbContext context, int producerId) in the StartUp class that receives a Producer Id. 
             * --Export all albums which are produced by the provided Producer Id. 
             * --For each Album, get the Name, Release date in format the "MM/dd/yyyy", 
             * --Producer Name,
             * --the Album Songs with each Song Name, Price (formatted to the second digit) and the Song Writer Name.
             * --Sort the Songs by Song Name (descending) and by Writer (ascending).
             * --At the end export the Total Album Price with exactly two digits after the decimal place. 
             * --Sort the Albums by their Total Price (descending).
*/
            var sb = new StringBuilder();
            var result = context.Albums
                .Where(pid => pid.ProducerId == producerId)
                .Select(a =>
                new
                {
                    Name = a.Name,
                    RealeaseDate = a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(x => new
                    {
                        Name = x.Name,
                        Price = x.Price,
                        Writer = x.Writer.Name

                    })
                    ,

                    TotalPrice = a.Price


                })
                .OrderByDescending(x => x.TotalPrice)
                
                .ToList();


            
          foreach (var item in result)
              {
                var songItem = item.Songs
                    .OrderByDescending(s => s.Name).ThenBy(s => s.Writer)
                    .Select((s, i) => new
                    {
                        Index = $"---#{i + 1}",
                        SongName = $"---SongName: {s.Name}",
                        Price = $"---Price: {s.Price:f2}",
                        Writer = $"---Writer: {s.Writer}",

                    });

                sb.AppendLine($"-AlbumName: {item.Name}");
                sb.AppendLine($"-ReleaseDate: {item.RealeaseDate.ToString("MM/dd/yyyy")}");
                sb.AppendLine($"-ProducerName: {item.ProducerName}");
                sb.AppendLine($"-Songs:");
                foreach (var song in songItem)
                {
                    sb.AppendLine(song.Index);
                    sb.AppendLine(song.SongName);
                    sb.AppendLine(song.Price);
                    sb.AppendLine(song.Writer);
                }
                                
                sb.AppendLine($"-AlbumPrice: {item.TotalPrice:f2}");
            }

              /*-AlbumName: Devil's advocate
  -ReleaseDate: 07/21/2018
  -ProducerName: Evgeni Dimitrov
  -Songs:
  ---#1
  ---SongName: Numb
  ---Price: 13.99
  ---Writer: Kara-lynn Sharpous
  ---#2
  ---SongName: Ibuprofen
  ---Price: 26.50
  ---Writer: Stanford Daykin
  -AlbumPrice: 40.49
  */

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            /*You need to write method string ExportSongsAboveDuration(MusicHubDbContext context, int duration) in the StartUp class that receives Song duration (integer, in seconds). 
             * --Export the songs which are above the given duration. 
             * --For each Song, export its Name, Performer Full Name, Writer Name, Album Producer and Duration (in format("c")).
             * --Sort the Songs by their Name (ascending), by Writer (ascending) and by Performer (ascending).*/

            var result = context.Songs

                .Where(s => s.Duration > TimeSpan.FromSeconds(duration))
                .Select(s => new
                {
                    Name = s.Name,
                    PerformerName = s.SongPerformers.Select(performerName => $"{performerName.Performer.FirstName} {performerName.Performer.LastName}").FirstOrDefault(),
                    Writer = s.Writer.Name,
                    Producer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")

                })
                .OrderBy(s=>s.Name)
                .ThenBy(s=>s.Writer)
                .ToList();

            /*   var performerNameStrings = result.SelectMany((result,i)=> result.PerformerName.OrderBy(x=>x),
                     (r,performerName) => @$"-Song #{result.IndexOf(r) + 1}
     ---SongName: {r.Name}
     ---Writer: {r.Writer}
     ---Performer: {performerName}
     ---AlbumProducer: {r.Producer}
     ---Duration: {r.Duration}");*/
            //*/

            var resultAsString = result
                .Select((r, i) => new
                {
                    Index = $"-Song #{i + 1}",
                   Name= $"---SongName: {r.Name}",
                   Writer =  $"---Writer: {r.Writer}",
                   Performer = $"---Performer: {r.PerformerName}",
                    Producer = $"---AlbumProducer: {r.Producer}",
                    Duration = $"---Duration: {r.Duration}",
                });

            var sb = new StringBuilder();

            foreach (var item in resultAsString)
            {
                sb.AppendLine(item.Index);
                sb.AppendLine(item.Name);
                sb.AppendLine(item.Writer);
                sb.AppendLine(item.Performer);
                sb.AppendLine(item.Producer);
                sb.AppendLine(item.Duration);
            }

            /*-Song #1
---SongName: Away
---Writer: Norina Renihan
---Performer: Lula Zuan
---AlbumProducer: Georgi Milkov
---Duration: 00:05:35
-Song #2
---SongName: Bentasil
---Writer: Mik Jonathan
---Performer: Zabrina Amor
---AlbumProducer: Dobromir Slavchev
---Duration: 00:04:03
…
*/
            return sb.ToString().TrimEnd();
        }
    }
}
