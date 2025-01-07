using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioLegal.api.UI.ModelViews.Cliente;
using src.api.Domain.Entities;

namespace ConsultorioLegal.api.Application.Services.Interfaces.Clientes
{
    public interface IClienteManager
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente> InsertClienteAsync(NovoCliente cliente);
        Task<Cliente> UpdateClienteAsync(AlteraCliente alteraCliente);
        Task DeleteClienteAsync(int id);
    }
}