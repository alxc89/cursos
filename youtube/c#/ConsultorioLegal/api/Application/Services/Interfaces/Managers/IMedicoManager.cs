using ConsultorioLegal.api.Domain.Entities;
using ConsultorioLegal.api.UI.ModelViews.Medico;
using src.api.Domain.Entities;

namespace ConsultorioLegal.api.Application.Services.Interfaces.Managers
{
    public interface IMedicoManager
    {
        Task<IEnumerable<MedicoView>> GetMedicosAsync();
        Task<MedicoView> GetMedicoByIdAsync(int id);
        Task<MedicoView> InsertMedicoAsync(NovoMedico medico);
        Task<MedicoView> UpdateMedicoAsync(AlteraMedico alteraMedico);
        Task DeleteMedicoAsync(int id);
    }
}
