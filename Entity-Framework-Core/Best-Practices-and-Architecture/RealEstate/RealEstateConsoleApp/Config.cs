using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateConsoleApp
{
    public class Config
    {
       
            
            public IServiceProvider ConfigureServices(IServiceCollection services)
            {
            var configuration = new ConfigurationBuilder()
            .AddUserSecrets("85fa7549-778c-4fe0-9562-4a59a1d512fc")
            .Build();

            return services
                .AddDbContext<RealEstateContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("realEstateStr")))
                .AddTransient<IPropertyService, PropertyService>()
                .AddTransient<ITagService,TagService>()
                
                .BuildServiceProvider();
            }
        

    }

}
