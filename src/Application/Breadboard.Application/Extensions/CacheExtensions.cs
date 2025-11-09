using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breadboard.Application.Extensions
{
 public static class CacheExtensions
    {
        public static IServiceCollection AddCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            return services;
        }
    }
}