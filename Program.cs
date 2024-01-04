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
}
else {
    app.UseHttpsRedirection();
}
app.UseRateLimiting();
app.UseAuthorization();

app.MapControllers();

app.Run();
