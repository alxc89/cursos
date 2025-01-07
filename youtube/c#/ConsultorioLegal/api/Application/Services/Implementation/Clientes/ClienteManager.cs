using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConsultorioLegal.api.Application.Services.Interfaces.Clientes;
using ConsultorioLegal.api.Application.Services.Interfaces.Repositories;
using ConsultorioLegal.api.UI.ModelViews.Cliente;
using src.api.Domain.Entities;

namespace src.api.Application.Services.Clientes.Implementation
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ClienteManager(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await clienteRepository.GetClientesAsync();
        }
        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await clienteRepository.GetClienteByIdAsync(id);
        }
        public async Task<Cliente> InsertClienteAsync(NovoCliente novoCliente)
        {
            var cliente = mapper.Map<Cliente>(novoCliente);
            return await clienteRepository.InsertClienteAsync(cliente);
        }

        public async Task<Cliente> UpdateClienteAsync(AlteraCliente alteraCliente)
        {
            var cliente = mapper.Map<Cliente>(alteraCliente);
            return await clienteRepository.UpdateClienteAsync(cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await clienteRepository.DeleteClienteAsync(id);
        }
    }
}