using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using SmartCharging.Service.Extensions;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.RegisterDependencies();

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Smart Charging",
        Description = "GreenFlux smart charging api",
        TermsOfService = new Uri("http://www.greenflux.com"),
    });
});

builder.Services.AddFluentValidation(ValidationExtension.Register);
builder.Services.AddFluentValidationRulesToSwagger();

#endregion

var app = builder.Build();

app.ConfigureExceptionHandler();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API V1");
    c.RoutePrefix = "";
});

app.MapControllers();

app.Run();