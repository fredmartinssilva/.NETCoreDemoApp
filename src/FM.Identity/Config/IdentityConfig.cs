using FM.Identity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FM.Identity.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddAuthorizationConfig(this IServiceCollection services)
        {
            // Add Configs Authorization of Identity here instead of declare on Startup.cs
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Exclude", policy => policy.RequireClaim("Exclude"));
            });

            return services;
        }

        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Configs of Identity here instead of declare on Startup.cs
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<RegisterContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("RegisterContextConnection")));

            // FrameworkStores decide wich kind of database. In this case is MSSQL
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddDefaultUI(Microsoft.AspNetCore.Identity.UI.UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<RegisterContext>();

            return services;
        }
    }
}
