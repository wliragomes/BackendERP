using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SharedKernel.SharedObjects;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SharedKernel.Configuration.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSwaggerConfigurationExtension(this IServiceCollection services, IConfigurationSection swaggerSection)
        {
            var swaggerConfiguration = swaggerSection.Get<SwaggerConfiguration>();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc(swaggerConfiguration?.Version ?? "v1", new OpenApiInfo
                {
                    Title = swaggerConfiguration?.Title ?? "API",
                    Description = swaggerConfiguration?.Description ?? "",
                    Contact = new OpenApiContact()
                    {
                        Name = swaggerConfiguration?.ContactName ?? "",
                        Email = swaggerConfiguration?.ContactEmail ?? ""
                    },
                    Version = swaggerConfiguration?.Version ?? "v1",
                });

                opt.EnableAnnotations();

                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },

                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app, IConfigurationSection swaggerSection)
        {
            var swaggerConfiguration = swaggerSection.Get<SwaggerConfiguration>();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.DocumentTitle = swaggerConfiguration?.Title ?? "Swagger UI";
                x.EnablePersistAuthorization();
                x.DocExpansion(DocExpansion.None);
            });
        }
    }
}
