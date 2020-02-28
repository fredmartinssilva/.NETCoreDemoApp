using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FM.Identity.Config
{
    public static class DIConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Add Dependecies Injections here instead of declare on Startup.cs

            return services;
        }
    }
}
