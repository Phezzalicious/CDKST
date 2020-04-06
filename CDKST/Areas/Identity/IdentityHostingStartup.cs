using System;
using CDKST.Areas.Identity.Data;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;

[assembly: HostingStartup(typeof(CDKST.Areas.Identity.IdentityHostingStartup))]
namespace CDKST.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public IdentityHostingStartup()
        {
           
        }
        public void Configure(IWebHostBuilder builder)
        {



            builder.ConfigureServices((context, services) =>
            {
                
                    
               


                services.AddDefaultIdentity<Member>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityContext>();
            });
        }
    }
}