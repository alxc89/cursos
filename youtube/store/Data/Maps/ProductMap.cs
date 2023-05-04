using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using store.Models;

namespace store.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1024).HasColumnType("varchar");
            builder.Property(x => x.Price).IsRequired().HasColumnType("money");
            builder.Property(x=> x.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar");
        }
    }
}