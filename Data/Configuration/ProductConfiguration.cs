using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.Providers).WithMany(p => p.Products)
                .UsingEntity(i => i.ToTable("Providings"));

            builder.HasOne(c => c.MyCategory).WithMany(p => p.Products).HasForeignKey(f => f.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
