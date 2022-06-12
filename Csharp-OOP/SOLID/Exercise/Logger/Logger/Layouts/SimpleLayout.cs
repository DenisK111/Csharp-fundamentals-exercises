using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class SimpleLayout : ILayout
    {
        public string Format(string date, string level, string message)
        {
            return $"{date} - {level} - {message}";
        }
    }
}
