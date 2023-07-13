using System.Reflection;
using Microsoft.OpenApi.Models;
using NewService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Добавляем SwaggerGen для генерации Swagger JSON
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureApplicationServices();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Включаем генерацию Swagger JSON
    app.UseSwagger();

    // Включаем Swagger UI и настраиваем путь к JSON-документу Swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();