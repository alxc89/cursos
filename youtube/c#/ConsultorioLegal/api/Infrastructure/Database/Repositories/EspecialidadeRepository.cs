using ConsultorioLegal.api.Application.Services.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using src.api.Infrastructure.Database.Context;

namespace ConsultorioLegal.api.Infrastructure.Database.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly DataContext context;
        public EspecialidadeRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await context.Especialidades.AnyAsync(p => p.Id == id);
        }
    }
}
