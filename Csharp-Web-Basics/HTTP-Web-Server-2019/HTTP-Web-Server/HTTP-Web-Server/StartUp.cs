using HTTP_Web_Server.Controllers;
using HTTP_Web_Server.Data;
using Microsoft.EntityFrameworkCore;
using MVCFramework;
using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using SIS.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server
{
    public class StartUp :IMVCApplication
    {
        public StartUp()
        {
            
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            
        }
        public  void Configure(IServerRoutingTable serverRoutingTable)
        {
            new ApplicationDbContext().Database.Migrate();
                                  
        }

       


    }
}
