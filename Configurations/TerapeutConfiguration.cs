using DAWPROIECTR.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Configurations
{
    public class TerapeutConfiguration : IEntityTypeConfiguration<Terapeut>
    {
        public void Configure(EntityTypeBuilder<Terapeut> builder)
        {
            builder.Property(x => x.Nume)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
            builder.Property(x => x.Prenume)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);


        }
    }
}