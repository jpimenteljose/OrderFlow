using Microsoft.EntityFrameworkCore;
using OrderFlow.Infrastructure.Contexts;

namespace OrderFlow.API.Extensions
{
    public static class DbContextsConfigExtension
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // pegando a connectionstring mapeada no arquivo appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

            // injeção de dependência na classe DataContext para inserir as configurações do banco de dados
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
