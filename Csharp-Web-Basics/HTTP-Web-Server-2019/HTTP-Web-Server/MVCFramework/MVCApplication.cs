using SIS.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFramework
{
    public abstract class MVCApplication : IMVCApplication
    {
        public  abstract IServerRoutingTable ConfigureRoutingTable();


        public  abstract void ConfigureServices();
        
    }
}
