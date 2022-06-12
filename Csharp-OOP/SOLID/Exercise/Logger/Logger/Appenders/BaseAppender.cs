using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
   public abstract class BaseAppender : IAppender
    {
       
        public BaseAppender(ILayout layout, ReportLevels reportThreshhold = default)
        {
            Layout = layout;
            ReportThreshhold = reportThreshhold;
        }
        public ReportLevels ReportThreshhold { get; set; }
        public ILayout Layout { get; }

        public int AppendedCount { get; protected set; }

        public abstract void Append(string date, string level, string message);

        public override string ToString()
        {
            // "Appender type: ConsoleAppender, Layout type: SimpleLayout, Report level: //  //CRITICAL, Messages appended: 2";

            return $"Appender type: {GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportThreshhold}, Messages appended: {this.AppendedCount}";
        }



    }
}
