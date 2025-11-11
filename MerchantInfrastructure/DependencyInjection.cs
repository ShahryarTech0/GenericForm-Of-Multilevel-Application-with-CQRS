using MerchantInfrastructure.Data;
using MerchantInfrastructure.MerchantRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantInfrastructure
{
    public class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // 🔹 Configure EF Core
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppDb")));

            // 🔹 Register Merchant Repository
            services.AddScoped<IMerchantRepository, MerchantRepository>();

            // 🔹 Register MerchantLocation Repository
            services.AddScoped<IMerchantLocationRepository, MerchantLocationRepository>();
            return services;
        }
    }
}
