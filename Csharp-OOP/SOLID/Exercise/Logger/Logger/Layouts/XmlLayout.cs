using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class XmlLayout : ILayout
    {
        public string Format(string date, string level, string message)
        {

            /* <log>
<date>3/31/2015 5:33:07 PM</date>
<level>ERROR</level>
<message>Error parsing request</message>
</log>
*/
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<log>");
            sb.AppendLine($"  <date>{date}</date>");
            sb.AppendLine($"  <level>{level}</level>");
            sb.AppendLine($"  <message>{message}</message>");
            sb.AppendLine("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}
