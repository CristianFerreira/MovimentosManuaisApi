using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovimentosManuais.API.Configurations;
using System.IO;

namespace MovimentosManuais.API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }


        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDataBaseConfiguration(Configuration);

            services.AddSwaggerConfiguration();

            services.AddDependencyInjectionConfiguration();

            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(CustomExceptionFilterConfiguration));

            });
        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseSwaggerSetup();
            app.UseMvc();
        }
    }
}
