using AutoMapper;
using ConsultorioLegal.api.Domain.Entities;
using ConsultorioLegal.api.UI.ModelViews.Especialidade;
using ConsultorioLegal.api.UI.ModelViews.Medico;

namespace ConsultorioLegal.api.Application.Services.Mappings.Medicos
{
    public class NovoMedicoMappingProfile : Profile
    {
        public NovoMedicoMappingProfile()
        {
            CreateMap<NovoMedico, Medico>()
                .ForMember(x => x.Criacao, y => y.MapFrom(z => DateTime.Now));
            CreateMap<Medico, MedicoView>();
            CreateMap<Especialidade, ReferenciaEspecialidade>().ReverseMap();
            CreateMap<Especialidade, EspecialidadeView>().ReverseMap();
            CreateMap<Especialidade, NovaEspecialidade>().ReverseMap();
            CreateMap<AlteraMedico, Medico>().ReverseMap();
        }
    }
}
