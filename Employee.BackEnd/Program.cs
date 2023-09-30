using Employee.IoC.Configuration;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.MapCore(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//add redoc
builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1",
    new OpenApiInfo
    {
        Title = "Employee",
        Version = "v1",
        Description = "This is a Employee Project to see how documentation can easily for generated for ASP.NET Core Web APIs using Swagger and ReDoc",
        Contact = new OpenApiContact
        {
            Name="Rahat Ahmed Tanjim",
            Email="rahatahmedtanjim1234@gmail.com"
        }
    });
        
});
//end redoc

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    //add it
    app.UseSwaggerUI(options =>
    options.SwaggerEndpoint("/swagger/v1/swagger.json","Demo Documentation v1"));
    app.UseReDoc(options =>
    {
        options.DocumentTitle = "Demo Documentaion";
        options.SpecUrl = "/swagger/v1/swagger.json";
    });
    //
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
