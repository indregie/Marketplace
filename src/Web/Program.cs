using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Data;
using System.Reflection;
using Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Marketplace API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Add your application and infrastructure services
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddHttpClient();

var connectionString = builder.Configuration.GetConnectionString("PostgreConnection");
builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarketplaceAPI v1");
    });
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();