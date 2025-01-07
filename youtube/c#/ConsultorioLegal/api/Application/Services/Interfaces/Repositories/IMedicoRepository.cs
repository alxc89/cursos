using ConsultorioLegal.api.Domain.Entities;
using src.api.Domain.Entities;

namespace ConsultorioLegal.api.Application.Services.Interfaces.Medicos
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetMedicosAsync();
        Task<Medico> GetMedicoByIdAsync(int id);
        Task<Medico> InsertMedicoAsync(Medico medico);
        Task<Medico> UpdateMedicoAsync(Medico medico);
        Task DeleteMedicoAsync(int id);
    }
}
