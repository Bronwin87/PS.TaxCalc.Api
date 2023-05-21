using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PS.TaxCalc.Application.Context;
using PS.TaxCalc.Infrastructure.Context;

namespace PS.TaxCalc.Infrastructure
{
    public static class RegisterService
    {
        public static void ConfigureInfraStructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TaxCalculatorDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TaxCalculatorDbConnection"));
            });

            services.AddScoped<ITaxCalculatorDbContext>(option =>
            {
                return option.GetService<TaxCalculatorDbContext>();
            });
        }

    }
}