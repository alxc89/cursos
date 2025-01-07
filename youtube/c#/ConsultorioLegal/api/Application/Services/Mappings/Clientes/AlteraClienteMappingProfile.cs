using AutoMapper;
using ConsultorioLegal.api.UI.ModelViews.Cliente;
using src.api.Domain.Entities;

namespace ConsultorioLegal.api.Application.Services.Mappings.Clientes
{
    public class AlteraClienteMappingProfile : Profile
    {
        public AlteraClienteMappingProfile()
        {
            CreateMap<AlteraCliente, Cliente>()
                .ForMember(d => d.UltimaAlteracao, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
        }
    }
}
