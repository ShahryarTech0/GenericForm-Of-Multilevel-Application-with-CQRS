using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            // ✅ Correct for MediatR 12+
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // ✅ AutoMapper registration
            services.AddAutoMapper(cfg =>
            {
                // You can configure mappings here globally if needed
            }, Assembly.GetExecutingAssembly());


            return services;
        }
    }
}
