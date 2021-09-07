using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcIdentity.Areas.Identity.Data;

[assembly: HostingStartup(typeof(MvcIdentity.Areas.Identity.IdentityHostingStartup))]
namespace MvcIdentity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MvcIdentityIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MvcIdentityIdentityDbContextConnection")));

                services.AddDefaultIdentity<Mvc1User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MvcIdentityIdentityDbContext>();
            });
        }
    }
}