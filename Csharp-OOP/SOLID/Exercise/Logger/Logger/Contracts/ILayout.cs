using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
   public interface ILayout
    {
        public string Format(string date, string level, string message);
    }
}
