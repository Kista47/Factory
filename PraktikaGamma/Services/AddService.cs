using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Services
{
    public static class AddService
    {
        public static IServiceCollection AddFactoryService(this IServiceCollection services)
        {
            services.AddTransient<AccountService>();
            return services;

        }


    }
}
