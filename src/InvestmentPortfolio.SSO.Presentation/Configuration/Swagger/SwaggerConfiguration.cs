namespace InvestmentPortfolio.SSO.Presentation.Configuration.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.OperationFilter<SwaggerDefaultValues>();
            });

            services.AddApiVersioning()
                .AddMvc()
                .AddApiExplorer(setup =>
                {
                    setup.GroupNameFormat = "'v'VVV";
                    setup.SubstituteApiVersionInUrl = true;
                });

            services.ConfigureOptions<ConfigureSwaggerGenOptions>();
        }
    }
}
