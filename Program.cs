using ContosoPizza.Models;
using ContosoPizza.Services;
// using RateLimitingDemo.Common.Repositories;
using ContosoPizza.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
DotNetEnv.Env.Load();
// Add services to the container.

builder.Services.Configure<PizzaStoreDatabaseSettings>(
    builder.Configuration.GetSection("PizzaStoreDatabase"));

builder.Services.AddSingleton<PizzaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
         // CORS - Allow calling the API from WebBrowsers
    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyOrigin()
        .AllowAnyHeader()
        // .AllowCredentials()
        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins seperated with comma
        .SetIsOriginAllowed(origin => true));// Allow any origin  
}
else {
    app.UseHttpsRedirection();
}
app.UseRateLimiting();
app.UseAuthorization();

app.MapControllers();

app.Run();
