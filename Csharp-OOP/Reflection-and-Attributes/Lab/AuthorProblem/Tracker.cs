using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace AuthorProblem
{
   public class Tracker
    {
        [Author("Az")]
        public void PrintMethodsByAuthor()
        {
            Type t = typeof(StartUp);

            var methods = t.GetMethods((BindingFlags)60);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(x=>x.AttributeType==typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }

        }
    }
}
