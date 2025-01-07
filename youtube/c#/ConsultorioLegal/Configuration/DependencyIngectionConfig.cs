using src.api.Application.Services.Clientes.Implementation;
using src.api.Infrastructure.Database.Repositories;
using ConsultorioLegal.api.Infrastructure.Database.Repositories;
using ConsultorioLegal.api.Application.Services.Implementation.Medicos;
using ConsultorioLegal.api.Application.Services.Interfaces.Clientes;
using ConsultorioLegal.api.Application.Services.Interfaces.Medicos;
using ConsultorioLegal.api.Application.Services.Interfaces.Managers;
using ConsultorioLegal.api.Application.Services.Interfaces.Repositories;

namespace ConsultorioLegal.Configuration
{
    public static class DependencyIngectionConfig
    {
        public static void AddDependecyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();

            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IMedicoManager, MedicoManager>();

            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
        }
    }
}
