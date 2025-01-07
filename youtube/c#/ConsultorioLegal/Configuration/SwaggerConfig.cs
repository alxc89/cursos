using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace ConsultorioLegal.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Consultório",
                        Version = "v1",
                        Description = "API da aplicação Consultório Legal.",
                        Contact = new OpenApiContact
                        {
                            Name = "Alex Cardoso",
                            Email = "alex.caardoso@hotmail.com",
                            Url = new Uri("https://github.com/alxc89")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "OSD",
                            Url = new Uri("https://opensource.org/osd")
                        },
                        TermsOfService = new Uri("https://opensource.org/osd")
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddFluentValidationRulesToSwagger();
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Consultório V1");
            });
        }
    }
}