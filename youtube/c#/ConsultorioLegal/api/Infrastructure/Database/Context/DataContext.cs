using ConsultorioLegal.api.Domain.Entities;
using ConsultorioLegal.api.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using src.api.Domain.Entities;

namespace src.api.Infrastructure.Database.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Medico> Medicos{ get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
        }
    }
}