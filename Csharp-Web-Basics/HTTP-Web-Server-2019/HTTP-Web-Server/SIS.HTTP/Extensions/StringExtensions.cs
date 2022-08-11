using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {

        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("There is no first letter");

            char[] a = str.ToLower().ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
