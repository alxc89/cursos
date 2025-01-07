using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.api.Domain.Entities;

namespace ConsultorioLegal.api.Infrastructure.Database.Configuration
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(x => new { x.ClienteId, x.Numero });
            builder.HasOne(c => c.Cliente)
                .WithMany(c => c.Telefones)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
