using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.api.Domain.Entities;

namespace ConsultorioLegal.api.Infrastructure.Database.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.ClienteId);
            builder.HasOne(p => p.Cliente)
                .WithOne(p => p.Endereco)
                .HasForeignKey<Endereco>(p => p.ClienteId);
        }
    }
}