using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {

            CommandInterpreter interpreter = new CommandInterpreter();
            int n = int.Parse(Console.ReadLine());
            List<IAppender> appenders = new List<IAppender>();
            IFile file = new LogFile();
            List<ILayout> layouts = new List<ILayout>()
            {
                new SimpleLayout(),
            new XmlLayout()

        };
            for (int i = 0; i < n; i++)
            {
                var appenderData = interpreter.InterpretAppender(Console.ReadLine());
                var type = appenderData[0];
                var layout = appenderData[1];
                ReportLevels threshhold = 0;
                if (appenderData.Length == 3)
                {
                    threshhold = Enum.Parse<ReportLevels>(appenderData[2], true);
                }
                Type t = Type.GetType($"Logger.{type}");
                Type l = Type.GetType($"Logger.{layout}");


                IAppender appender = appenderData[0] == "FileAppender" ? (IAppender)Activator.CreateInstance(t, layouts.First(x => x.GetType() == l), file, threshhold) : (IAppender)Activator.CreateInstance(t, layouts.First(x => x.GetType() == l), threshhold);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);
            while (true)
            {
                var commands = interpreter.InterpretMessage(Console.ReadLine());

                if (commands[0] == "END")
                {
                    break;
                }
                var level = commands[0];
                var date = commands[1];
                var data = commands[2];

                logger.Log(date, level, data);
            }
            Console.WriteLine("Logger info");
            appenders.ForEach(Console.WriteLine);


        }
    }
}
