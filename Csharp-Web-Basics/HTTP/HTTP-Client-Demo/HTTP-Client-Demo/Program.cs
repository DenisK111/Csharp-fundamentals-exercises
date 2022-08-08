using HTTP_Client_Demo;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const string NewLine = "\r\n";
            TcpListener tcpListener = new TcpListener(
                IPAddress.Loopback, 80);
            tcpListener.Start();
            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[1000000];
                    var lenght = stream.Read(buffer, 0, buffer.Length);

                    string requestString =
                        Encoding.UTF8.GetString(buffer, 0, lenght);
                    Console.WriteLine(requestString);

                    var matches = Regex.Matches(requestString, @"username=(?<username>[\w]+)&password=(?<tweet>[\w]+)");
                    string html = String.Empty;
                    string response = String.Empty;
                    if (matches.Any())
                    {

                        var userName = matches.First().Groups["username"].Value;
                        var tweet = matches.First().Groups["tweet"].Value;

                        using (var context = new TweetContext())
                        {
                            var sb = new StringBuilder();
                            context.Database.EnsureCreated();
                            context.Add(new TweetModel()
                            {
                                Name = userName,
                                Tweet = tweet
                            });

                            context.SaveChanges();
                            var count = 1;
                            var tweets = context.Tweets.ToList();

                            foreach (var entry in tweets)
                            {
                                sb.AppendLine($"{count++}. Name :{entry.Name}<br/>Tweet:{entry.Tweet}<br/><br/>");
                            }

                            html = $"<div>{sb.ToString()}</div>";
                          

                        }





                    }
                    else
                    {
                        html = $"<h1>Hello from DenisServer {DateTime.Now}</h1>" +
                      $"<form action=/tweet method=post><input name=username /><input name=password />" +
                      $"<input type=submit /></form>";

                      
                    }

                    response = "HTTP/1.1 200 OK" + NewLine +
                          "Server: DenisServer" + NewLine +
                          // "Location: https://www.google.com" + NewLine +
                          "Content-Type: text/html; charset=utf-8" + NewLine +
                          "Content-Disposition: attachment; filename=niki.txt" + NewLine +
                          "Content-Lenght: " + html.Length + NewLine +
                          NewLine +
                          html + NewLine;


                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);

                    Console.WriteLine(new string('=', 70));
                }
            }
        }

        public static async Task ReadData()
        {
            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            // var html = await httpClient.GetStringAsync(url);
            // Console.WriteLine(html);
        }
    }
}