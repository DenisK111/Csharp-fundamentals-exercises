using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFramework.MVCViewEngine
{
    public interface IViewEngine
    {
        string GenerateView(string templateCode, object? ViewModel = default,(string? user,int role)? userData = null);
    }
}
