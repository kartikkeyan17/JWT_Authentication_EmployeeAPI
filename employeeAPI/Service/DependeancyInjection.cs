using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using employeeAPI.Service;
using employeeAPI.Interface;

namespace employeeAPI
{
    public static class DependeancyInjection
    {
        public static IServiceCollection ServiceCollection(this IServiceCollection services)
        {
            services.AddSingleton<IAdminService, adminService>();

            services.AddSingleton<IEmployeeService, employeeService>();

            services.AddSingleton<ILoginService, loginService>();

            return services;
        }
    }

}
