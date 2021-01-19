using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using API_Masivian.Repositories;

namespace API_Masivian.Configurations
{
    public class MainInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddMvcCore().AddApiExplorer();

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
            });

            services.AddScoped<ValuesRepository>();
            services.AddScoped<IValuesRepository, CachedValuesRepository>();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "APIMasivian for Masivian test",
                    Version = "V1",
                    Description = "A net-core REST api for wheel of fortune game",
                    Contact = new OpenApiContact
                    {
                        Name = "Andrés Mauricio Quintero Correal",
                        Email = "and.quintero32@gmail.com",
                        Url = new Uri("https://github.com/aquintero10")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
        }
    }
}
