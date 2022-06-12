using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Logger
{
    public class LogFile : IFile

    {
        private const string path = "../../../log.txt";
        
        
        public LogFile()
        {
            Log = new StringBuilder();
        }
        public int Size => Log.ToString().Where(x => (x >= 'a' && x <= 'z') || (x >= 'A' && x <= 'Z')).ToArray().Sum(x=>x);

        public StringBuilder Log { get; set; }

        public string Path => path;

        public void Write(string message)
        {
            this.Log.AppendLine(message);

            using (StreamWriter writer = new StreamWriter(Path,true)
            {
                writer.WriteLine(message);

            }
           
        }
    }
}
