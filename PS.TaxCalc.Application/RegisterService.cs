using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PS.TaxCalc.Application.Common;
using PS.TaxCalc.Application.Services.TaxCalculatorService.Implementation;

namespace PS.TaxCalc.Application
{
    public static class RegisterService
    {
        public static void ConfigureApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddSingleton<TaxCalculatorFactory>();
        }
    }
}