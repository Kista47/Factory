using Microsoft.Extensions.DependencyInjection;
using PraktikaGamma.Repositories;
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
            services.AddScoped<AccountService>();
            services.AddScoped<DepartmentRepository>();
            services.AddScoped<DepartmentTaskRepository>();
            services.AddScoped<AssembliesRepository>();
            services.AddScoped<DepartmentRepository>();
            services.AddScoped<DetailsRepository>();
            services.AddScoped<DirectorService>();
            services.AddScoped<AdminService>();
            //services.AddTransient<DepChiefService>();
            //services.AddTransient<WorkerService>();

            return services;
        }


    }
}
