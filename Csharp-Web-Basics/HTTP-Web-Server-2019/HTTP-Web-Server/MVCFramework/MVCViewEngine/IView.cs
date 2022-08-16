using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFramework.MVCViewEngine
{
    public interface IView
    {

        string GetHtml(object? viewModel = default);
    }
}
