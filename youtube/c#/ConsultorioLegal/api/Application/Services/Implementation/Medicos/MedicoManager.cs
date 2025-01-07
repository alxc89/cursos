using AutoMapper;
using ConsultorioLegal.api.Application.Services.Interfaces.Managers;
using ConsultorioLegal.api.Application.Services.Interfaces.Medicos;
using ConsultorioLegal.api.Domain.Entities;
using ConsultorioLegal.api.UI.ModelViews.Medico;

namespace ConsultorioLegal.api.Application.Services.Implementation.Medicos
{
    public class MedicoManager : IMedicoManager
    {
        private readonly IMedicoRepository medicoRepository;
        private readonly IMapper mapper;

        public MedicoManager(IMedicoRepository medicoRepository, IMapper mapper)
        {
            this.medicoRepository = medicoRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MedicoView>> GetMedicosAsync()
        {
            return mapper.Map<IEnumerable<Medico>, IEnumerable<MedicoView>>(await medicoRepository.GetMedicosAsync());
        }

        public async Task<MedicoView> GetMedicoByIdAsync(int id)
        {
            return mapper.Map<MedicoView>(await medicoRepository.GetMedicoByIdAsync(id));
        }

        public async Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico)
        {
            var medico = mapper.Map<Medico>(novoMedico);
            return mapper.Map<MedicoView>(await medicoRepository.InsertMedicoAsync(medico));
        }

        public async Task<MedicoView> UpdateMedicoAsync(AlteraMedico alteraMedico)
        {
            var medico = mapper.Map<Medico>(alteraMedico);
            return mapper.Map<MedicoView>(await medicoRepository.UpdateMedicoAsync(medico));
        }

        public async Task DeleteMedicoAsync(int id)
        {
            await medicoRepository.DeleteMedicoAsync(id);
        }
    }
}
