using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LatvijasPasts.UseCases
{
    public static class Setup
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
