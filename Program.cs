using Microsoft.OpenApi.Models;
using System.Reflection;
using SandwichShop.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Savory Sandwiches",
        Description = "Eat well to code well",
        Version = "v1"
    });
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(cool =>
{
    cool.SwaggerEndpoint("/swagger/v1/swagger.json", "Savory Sandwiches v1");
});

app.MapGet("/sandwiches", () => SandwichDB.GetSandwiches());

app.MapGet("/sandwiches/{id}", (int id) => SandwichDB.GetSandwich(id));

app.MapPost("/sandwiches", (Sandwich sandwich) => SandwichDB.CreateSandwich(sandwich));

app.MapPut("/sandwiches", (Sandwich sandwich) => SandwichDB.UpdateSandwich(sandwich));

app.MapDelete("/sandwiches/{id}", (int id) => SandwichDB.RemoveSandwich(id));

app.Run();

//https://learn.microsoft.com/en-us/training/modules/build-web-api-minimal-api/2-what-is-minimal-api