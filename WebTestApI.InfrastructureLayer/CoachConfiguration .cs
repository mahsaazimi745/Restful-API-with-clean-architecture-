using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Entity;

namespace WebTestApI.InfrastructureLayer
{
        public class CoachConfiguration : IEntityTypeConfiguration<Coach>
        {
            public void Configure(EntityTypeBuilder<Coach> builder)
            {
                builder.HasBaseType<User>(); // ارث‌بری از User

                builder.Property(c => c.Specialty)
                       .HasMaxLength(100)
                       .IsRequired();

                builder.Property(c => c.ExperienceYears)
                       .IsRequired();

                builder.Property(c => c.CertificationNumber)
                       .HasMaxLength(50);

                builder.ToTable("Coaches");
            }
        }

    }

