using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class ConsoleAppender : BaseAppender
    {
        

        public ConsoleAppender(ILayout layout, ReportLevels reportThreshhold = default) : base( layout,reportThreshhold)
        {
           
        }

        public override void Append(string date,string level,string info)
        {
            string message = this.Layout.Format(date, level, info);
            Console.WriteLine(message);
            AppendedCount++;
        }
    }
}
