using P01.Stream_Progress.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class Jpeg : IFile
    {
        private string name;

        public Jpeg(string name,int length, int bytesSent)
        {
            this.name = name;
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; }

        public int BytesSent { get; }
    
    }
}
