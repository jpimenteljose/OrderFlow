using Microsoft.OpenApi;

namespace OrderFlow.API.Extensions
{
    public static class SwaggerConfigExtension
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            // configurar o Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Overflow - API para gerenciamento de pedidos",
                    Description = "Treinamento C# Arquiteto Formação DEVOPS - COTI Informática"
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            // executando o Swagger
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
