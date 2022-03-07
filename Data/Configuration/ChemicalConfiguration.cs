using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Data.Configuration
{
    public class ChemicalConfiguration : IEntityTypeConfiguration<Chemical>
    {
        public void Configure(EntityTypeBuilder<Chemical> builder)
        {
            builder.OwnsOne(c => c.LabAddress, myAdd =>
            {
                myAdd.Property(a => a.StreetAdress).HasMaxLength(50).HasColumnName("MyStreet");
                myAdd.Property(c => c.City).IsRequired().HasColumnName("MyCity");
            });
            
             
        }
    }
}
