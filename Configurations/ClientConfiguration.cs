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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(x => x.Nume)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
            builder.Property(x => x.Prenume)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
            builder.HasOne(x => x.User)
                    .WithOne(x => x.Client)
                    .HasForeignKey<Client>(x => x.UserId);
        }
    }
}