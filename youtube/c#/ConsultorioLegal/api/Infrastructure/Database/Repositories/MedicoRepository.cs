using ConsultorioLegal.api.Application.Services.Interfaces.Medicos;
using ConsultorioLegal.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using src.api.Infrastructure.Database.Context;

namespace ConsultorioLegal.api.Infrastructure.Database.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly DataContext context;
        public MedicoRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await context
                .Medicos
                .Include(x => x.Especialidades)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Medico> GetMedicoByIdAsync(int id)
        {
            return await context
                .Medicos
                .Include(x => x.Especialidades)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Medico> InsertMedicoAsync(Medico medico)
        {
            await context
                .Medicos
                .AddAsync(medico);
            await InsertMedicoEspecialidades(medico);
            await context.SaveChangesAsync();
            return medico;
        }

        private async Task InsertMedicoEspecialidades(Medico medico)
        {
            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await context.Especialidades
                    .AsNoTracking().FirstAsync(x => x.Id == especialidade.Id);
                context.Entry(especialidade).CurrentValues.SetValues(especialidadeConsultada);
            }
        }

        public async Task<Medico> UpdateMedicoAsync(Medico medico)
        {
            var medicoConsultado = await context
                                        .Medicos
                                        .Include(x => x.Especialidades)
                                        .SingleOrDefaultAsync(x => x.Id == medico.Id);

            if (medicoConsultado == null)
            {
                return null;
            }

            context.Entry(medicoConsultado).CurrentValues.SetValues(medico);
            await UpdateMedicoEspecialidades(medico, medicoConsultado);

            await context.SaveChangesAsync();
            return medicoConsultado;
        }

        private async Task UpdateMedicoEspecialidades(Medico medico, Medico medicoConsultado)
        {
            medicoConsultado.Especialidades.Clear();

            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await context
                                                   .Especialidades
                                                   .FindAsync(especialidade.Id);
                medicoConsultado.Especialidades.Add(especialidadeConsultada);
            }
        }

        public async Task DeleteMedicoAsync(int id)
        {
            var medicoConsultado = await context.Medicos.FindAsync(id);
            context.Medicos.Remove(medicoConsultado);
            await context.SaveChangesAsync();

        }
    }
}
