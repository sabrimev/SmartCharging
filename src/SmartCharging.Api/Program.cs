using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//builder.Services.Register();

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "GreenFlux",
        Description = "GreenFlux Smart Charging",
        TermsOfService = new Uri("http://www.greenflux.com"),
    });
});
#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API V1");
    c.RoutePrefix = "";
});

app.MapControllers();

app.Run();