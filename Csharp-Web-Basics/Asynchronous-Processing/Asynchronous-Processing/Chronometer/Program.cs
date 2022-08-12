namespace Chronometer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Chronometer();
            while (true)
            {
                var input = Console.ReadLine();

                switch (input)
                {
                    case "start":
                        
                        Task.Run(()=> stopwatch.Start());
                        
                        break;
                    case "stop":

                        stopwatch.Stop();
                        break;
                    case "lap":

                        Console.WriteLine(stopwatch.Lap());
                        break;
                    case "laps":
                        var count = 0;
                        if (stopwatch.Laps.Any())
                        {
                            Console.WriteLine(string.Join(Environment.NewLine, stopwatch.Laps.Select(x => $"{count++}. {x}")));
                        }
                        else
                        {
                            Console.WriteLine("Laps: no laps");
                        }
                        break;
                    case "reset":

                        stopwatch.Reset();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    case "time":
                        Console.WriteLine(stopwatch.GetTime);
                        break;
                    default:
                        Console.WriteLine("Invalid Command!");
                        break;
                }

            }

        }
    }
}