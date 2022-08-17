using SIS.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFramework
{
    public interface IMVCApplication
    {
        void ConfigureServices();

        IServerRoutingTable Configure(IServerRoutingTable serverRoutingTable);
    }
}
