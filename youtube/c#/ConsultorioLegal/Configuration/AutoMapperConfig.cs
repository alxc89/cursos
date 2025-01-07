using ConsultorioLegal.api.Application.Services.Mappings.Clientes;
using ConsultorioLegal.api.Application.Services.Mappings.Medicos;

namespace ConsultorioLegal.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(NovoClienteMappingProfile), 
                typeof(AlteraClienteMappingProfile),
                typeof(NovoMedicoMappingProfile));
        }
    }
}
