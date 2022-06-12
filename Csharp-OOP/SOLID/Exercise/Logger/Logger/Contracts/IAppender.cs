using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
   public interface IAppender
    {
        void Append(string date, string level, string message);

        public ILayout Layout { get;}

        public int AppendedCount { get; }

        ReportLevels ReportThreshhold { get; set; }
    }
}
