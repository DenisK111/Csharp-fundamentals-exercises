    using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Stealer
{
   public class Spy
    {
        public string StealFieldInfo(string classToInvestigate,params string[] field)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {classToInvestigate}");

            Type t = Type.GetType(classToInvestigate);
            FieldInfo[] fields = t.GetFields((BindingFlags)60).Where(x => field.Contains(x.Name)).ToArray();
            Hacker hacker = new Hacker();
            foreach (var item in fields)
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(hacker)}");

            }

            return sb.ToString().TrimEnd();



        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type t = Type.GetType($"Stealer.{className}");
            FieldInfo[] fields= t.GetFields((BindingFlags)28);

            foreach (var field in fields)
            {
               
                    sb.AppendLine($"{field.Name} must be Private!");
                
            }

            PropertyInfo[] properties = t.GetProperties((BindingFlags)60);

            foreach (var item in properties)
            {
                if (item.GetGetMethod() == null)
                {
                    sb.AppendLine($"{item.GetMethod.Name} have to be public!");
                }
                
                if (item.GetSetMethod() !=  null)
                {
                    sb.AppendLine($"{item.SetMethod.Name} have to be private!");
                }
            }
 
            return sb.ToString().TrimEnd();

        }

        public string RevealPrivateMethods(string className)
        {
            Type t = Type.GetType($"Stealer.{className}");
            var methods = t.GetMethods((BindingFlags)36);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {t.FullName}");

            sb.AppendLine($"Base Class: {t.BaseType.Name}");
            sb.AppendLine($"{String.Join(Environment.NewLine, methods.Select(x => x.Name))}");

            return sb.ToString().TrimEnd();

        }

        public string CollectGettersAndSetters(string className)
        {

            Type t = Type.GetType(className);

            var properties = t.GetProperties((BindingFlags)60);

            StringBuilder getters = new StringBuilder();
            StringBuilder setters = new StringBuilder();
            
            foreach (var property in properties)
            {
                if (property.GetGetMethod(true) != null)
                {

                getters.AppendLine($"{property.GetGetMethod(true).Name} will return {property.GetGetMethod(true).ReturnType}");
                }

                if (property.GetSetMethod(true) != null)
                {
                    setters.AppendLine($"{property.GetSetMethod(true).Name} will set field of {property.GetGetMethod(true).ReturnType}");
                }
                
            }

            return getters.ToString() + setters.ToString().TrimEnd();
        }
    }
}
