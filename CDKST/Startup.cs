using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using CDKST.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using MyData.Data;
using MyRepo.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
namespace CDKST
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRazorPages();
            if (Environment.IsDevelopment())
            {

                services.AddDbContext<IdentityContext>(options =>
                                   options.UseSqlite(Configuration.GetConnectionString("IdentityContext")));
                services.AddDbContext<CDKSTContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("CDKSTContext")))
                .AddUnitOfWork<CDKSTContext>();
            }
            if(Environment.IsProduction())
            {
                 services.AddDbContext<IdentityContext>(
                    options => options.UseMySql(Configuration.GetConnectionString("IdentityContextSQLServer"),
                                                mySqlOptions => mySqlOptions.ServerVersion(new Version(5, 7, 29), ServerType.MySql)
                    )).AddUnitOfWork<IdentityContext>();

                 services.AddDbContext<CDKSTContext>(
                    options => options.UseMySql(Configuration.GetConnectionString("CDKSTContextSQLServer"),
                                                mySqlOptions => mySqlOptions.ServerVersion(new Version(5, 7, 29), ServerType.MySql)
                    )).AddUnitOfWork<CDKSTContext>();
            }
 
            //https://phezzalicious@bitbucket.org/phezzalicious/cdkst-dotnet.git 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}


//options.UseSqlServer(connection, b => b.MigrationsAssembly("CDKST"))