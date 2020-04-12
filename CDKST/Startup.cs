using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using CDKST.Areas.Identity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MyData.Data;
using MyRepo.DependencyInjection;
using CDKST.Middleware;
using Microsoft.AspNetCore.HttpOverrides;

namespace CDKST
{
    public class Startup
    {

        IWebHostEnvironment Environment{ get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDistributedMemoryCache();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddRazorPages();

            //add database and add UnitOfWork using Wizard Context
            services.AddDbContext<IdentityContext>(options =>
               options.UseMySql(Configuration.GetConnectionString("IdentityContextSQLServer"), mySqlOptions =>
                    mySqlOptions.ServerVersion(new Version(5, 7, 29), ServerType.MySql)))
                       .AddUnitOfWork<IdentityContext>();
            services.AddDbContext<CDKSTContext>(options =>
               options.UseMySql(Configuration.GetConnectionString("CDKSTContextSQLServer"), mySqlOptions =>
                    mySqlOptions.ServerVersion(new Version(5, 7, 29), ServerType.MySql)))
                       .AddUnitOfWork<CDKSTContext>();

            // if(Environment.IsDevelopment())
            // {
            //     //add database and add UnitOfWork using Wizard Context
            //     services.AddDbContext<WizardContext>(options => 
            //         options.UseSqlite(Configuration.GetConnectionString("WizardContextLocal")))
            //             .AddUnitOfWork<WizardContext>();
            // }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //get the database to migrate/update
            using(var servicescope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                servicescope.ServiceProvider.GetService<CDKSTContext>().Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();                
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //this can cause headaches when testing locally.
            //uncomment for deploy
              app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            //for session variables
            app.UseHttpContextItemsMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
