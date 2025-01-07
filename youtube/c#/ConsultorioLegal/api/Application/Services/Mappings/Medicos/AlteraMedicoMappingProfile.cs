using AutoMapper;
using ConsultorioLegal.api.Domain.Entities;
using ConsultorioLegal.api.UI.ModelViews.Medico;

namespace ConsultorioLegal.api.Application.Services.Mappings.Medicos
{
    public class AlteraMedicoMappingProfile : Profile
    {
        public AlteraMedicoMappingProfile()
        {
            CreateMap<AlteraMedico, Medico>()
                .ForMember(x => x.UltimaAlteracao, y => y.MapFrom(z => DateTime.Now));
        }
    }
}
