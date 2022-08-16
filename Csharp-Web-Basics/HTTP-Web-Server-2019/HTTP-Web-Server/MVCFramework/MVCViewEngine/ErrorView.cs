using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFramework.MVCViewEngine
{
    public class ErrorView : IView
    {
        private readonly IEnumerable<string> errors;
        private readonly string cSharpCode;

        public ErrorView(IEnumerable<string> errors,string cSharpCode)
        {
            this.errors = errors;
            this.cSharpCode = cSharpCode;
        }

        public string GetHtml(object? viewModel = null)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<h1>View compile errors: {errors.Count()}</h1><ul>");
            var count = 1;
            foreach (var error in errors)
            {
                sb.AppendLine($"<li>{count++}. {error}</li>");
            }
            sb.AppendLine($"</ul><pre>{cSharpCode}</pre>");

            return sb.ToString();

        }
    }
}
