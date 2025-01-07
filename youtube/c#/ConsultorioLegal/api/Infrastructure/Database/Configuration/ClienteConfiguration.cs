using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.api.Domain.Entities;

namespace ConsultorioLegal.api.Infrastructure.Database.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(150);
            builder.Property(c => c.DataNascimento).IsRequired();
            builder.Property(c => c.Documento).IsRequired().HasColumnType("varchar").HasMaxLength(14);
            builder.Property(c => c.Sexo).IsRequired();

            builder.HasIndex(c => new { c.Id, c.Nome });
        }
    }
}
