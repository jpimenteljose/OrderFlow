using OrderFlow.Application.Interfaces;
using OrderFlow.Application.Services;
using OrderFlow.Domain.Interfaces;
using OrderFlow.Infrastructure.Repositories;

namespace OrderFlow.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
