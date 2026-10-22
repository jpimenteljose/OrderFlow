using OrderFlow.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSwaggerConfig(); // configurar o Swagger

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwaggerConfig(); // executar o Swagger

app.UseAuthorization();

app.MapControllers();

app.Run();
