using SIS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFramework.Attributes
{
    public abstract class BaseAttribute : Attribute
    {
       
        public string Url { get; set; }
        public abstract HttpRequestMethod Method { get; }
    }
}
