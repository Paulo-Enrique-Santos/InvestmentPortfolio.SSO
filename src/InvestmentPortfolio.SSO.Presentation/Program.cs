using Asp.Versioning.ApiExplorer;
using InvestmentPortfolio.SSO.API.Filter;
using InvestmentPortfolio.SSO.Presentation.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
var assemblies = Assembly.Load("InvestmentPortfolio.SSO.Application");

builder.Services.AddControllers(option => option.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddConfiguration(builder.Configuration);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var version = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in version.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"InvestmentPortfolio.SSO.API - {description.GroupName.ToUpper()}");
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
