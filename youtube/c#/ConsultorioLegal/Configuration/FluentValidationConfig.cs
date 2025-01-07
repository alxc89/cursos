using ConsultorioLegal.api.Application.Services.Validator;
using FluentValidation.AspNetCore;
using src.api.Application.Services.Validator;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace ConsultorioLegal.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddFluentValidation(p =>
                {
                    p.RegisterValidatorsFromAssemblyContaining<Program>();
                    /*p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<NovoTelefoneValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<NovoMedicoValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<AlteraMedicoValidator>();*/
                    p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
        }
    }
}
