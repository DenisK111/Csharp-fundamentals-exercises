using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MVCFramework.MVCViewEngine
{
    public class ViewEngine : IViewEngine
    {
        private const string Replace = "{{REPLACE}}";
        public string GenerateView(string templateCode, object? viewModel = null, (string? user, int role)? userData = null)
        {
            var csharpCode = GenerateCsharpCode(templateCode,viewModel!);
            var assembly = GenerateExecutableObject(csharpCode, viewModel!);

            var role = (int)IdentityRole.NotLoggedIn;
            string? user = null!;

            if (userData.HasValue)
            {
                role = userData.Value.role;
                user = userData.Value.user;
            }

            var html = assembly.GetHtml((IdentityRole)role, viewModel, user);

            return html;


        }

        private IView GenerateExecutableObject(string csharpCode, object viewModel)
        {
            var cSharpExecutableObject = CSharpCompilation.Create("ViewAssembly")
                 .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                 .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                 .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location));
            var namespacesToAdd = new List<string>();

            if (viewModel != null)
            {
                cSharpExecutableObject = cSharpExecutableObject.AddReferences(MetadataReference.CreateFromFile(viewModel.GetType().Assembly.Location));

                if (viewModel.GetType().IsGenericType)
                {
                    var types = viewModel.GetType().GetGenericArguments();

                    

                    foreach (var type in types)
                    {
                        namespacesToAdd.Add(type.Namespace!);
                        cSharpExecutableObject = cSharpExecutableObject.AddReferences(MetadataReference.CreateFromFile(type.Assembly.Location));
                    }
                }

            }

            csharpCode = csharpCode.Replace(Replace, string.Join("\r\n", namespacesToAdd.Select(x => $"using {x};")));

            var libraries = Assembly.Load(new AssemblyName("netstandard")).GetReferencedAssemblies();

            foreach (var library in libraries)
            {
                cSharpExecutableObject = cSharpExecutableObject.AddReferences(MetadataReference.CreateFromFile(Assembly.Load(library).Location));
            }

            cSharpExecutableObject = cSharpExecutableObject.AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(csharpCode));

            using MemoryStream memoryStream = new MemoryStream();
            var emitResult = cSharpExecutableObject.Emit(memoryStream);
            if (!emitResult.Success)
            {
                //CompileErrors
                return new ErrorView(emitResult.Diagnostics.Where(x => x.Severity == DiagnosticSeverity.Error).Select(xx => xx.GetMessage()), csharpCode);
            }

            memoryStream.Seek(0, SeekOrigin.Begin);
            var byteAssembly = memoryStream.ToArray();
            var assembly = Assembly.Load(byteAssembly);
            var viewType = assembly.GetType("ViewNamespace.ViewClass");
            object? viewTypeInstance = Activator.CreateInstance(viewType!);


            return (viewTypeInstance as IView)!;
        }

        private string GenerateCsharpCode(string templateCode,object viewModel)
        {
            string typeOfModel = "object";

            if (viewModel!=null)
            {
                if (viewModel.GetType().IsGenericType)
                {
                    var modelName = viewModel.GetType().FullName;
                    var genericArguments = viewModel.GetType().GenericTypeArguments;
                    typeOfModel = modelName!.Substring(0,modelName.IndexOf("`")) + "<" + String.Join(",",genericArguments.Select(x=>x.Name)) +  ">";

                }

                else
                {
                    typeOfModel = viewModel.GetType().FullName!;
                }
            }

           
            string methodBody = GetMethodBody(templateCode);
            string cSharpCode = @"
using System.Text;
using System;
using System.Linq;
using System.Collections.Generic;
using MVCFramework.MVCViewEngine;
using MVCFramework;
{{REPLACE}}

namespace ViewNamespace
{
public class ViewClass : IView
    {
        public string GetHtml(IdentityRole role,object? viewModel,string? user)
        {
            var Role = role;
            var User = user;
            var Model = viewModel as " + typeOfModel + @";
            var html = new StringBuilder();

            " + methodBody + @"

            return html.ToString();
        }
    }
}

";

            return cSharpCode;
        }

        private string GetMethodBody(string templateCode)
        {
            Regex regex = new Regex(@"[^\""\s&\'<]+");
            var supportedOperators = new List<string> { "for", "while", "if", "else", "foreach" };
            var html = new StringBuilder();
            using StringReader reader = new StringReader(templateCode);
            var line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.TrimStart().StartsWith("@"))
                {
                    var atSignLocation = line.IndexOf("@");
                    line = line.Remove(atSignLocation, 1);
                    html.AppendLine(line);

                }

                else if (line.TrimStart().StartsWith("{") || line.TrimStart().StartsWith("}"))
                {
                    html.AppendLine(line);
                }
                else
                {

                    html.Append($"html.AppendLine(@\"");

                    while (line.Contains("@"))
                    {
                        var atSignLocation = line.IndexOf("@");
                        html.Append(line.Substring(0,atSignLocation).Replace("\"", "\"\"") + "\" + ");
                        var lineAfterAtSign = line.Substring(atSignLocation + 1);
                        var code = regex.Match(lineAfterAtSign).Value;
                        html.Append(code + " + @\"");
                        line = lineAfterAtSign.Substring(code.Length);


                    }
                 

                    html.AppendLine(line.Replace("\"", "\"\"") + "\");");
                }
            }

            return html.ToString();
        }
    }
}
