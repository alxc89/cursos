using src.api.Domain.Entities;

namespace ConsultorioLegal.api.Application.Services.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente> InsertClienteAsync(Cliente cliente);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}