using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class Logger : ILogger
    {
        IEnumerable<IAppender> appenders;
        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }
        public void Log(string date, string level, string data)
        {
            
            foreach (var appender in appenders)
            {
                if ((int)Enum.Parse<ReportLevels>(level,true) < (int)appender.ReportThreshhold)
                {
                    continue;
                }
                appender.Append(date, level, data);
            }
        }
    }
}
