using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Logger.Contracts;

namespace Logger
{
    class FileAppender : BaseAppender
    {
       
        private IFile file;

        public FileAppender(ILayout layout, IFile file,ReportLevels reportThreshhold = default) : base(layout,reportThreshhold)
        {
            this.file = file;
           
        }
               

        public override void Append(string date, string level, string data)
        {
            string message = this.Layout.Format(date, level, data);
            file.Write(message);
            AppendedCount++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {file.Size}";
        }

    }
}
