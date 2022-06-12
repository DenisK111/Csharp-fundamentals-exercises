using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using ValidationAttributes.Attributes;
using System.Linq;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            IEnumerable<string>
            Type t = obj.GetType();
            var properties = t.GetProperties((BindingFlags)60)
                .Where(x=>x.GetCustomAttributes<MyValidationAttribute>()
                .Any())
                .ToArray();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                var attributes = property.GetCustomAttributes<MyValidationAttribute>();

                foreach (var attribute in attributes)
                {

                    bool isValid = attribute.IsValid(value);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;



           






        }
    }
}
