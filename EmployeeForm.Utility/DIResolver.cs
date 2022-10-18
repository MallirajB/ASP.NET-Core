using EmployeeForm.Core.IRepository;
using EmployeeForm.Core.IService;
using EmployeeForm.Repository;
using EmployeeForm.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Utility
{
   public class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //for accessing the http context by interface in view level
            #region Http context
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
            //for service accesssing
            #region Service

            services.AddScoped<IEmployeeService,EmployeeService>();
            #endregion
            //for Repository accessing 
            #region Repository

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            #endregion
        }
    }
}
