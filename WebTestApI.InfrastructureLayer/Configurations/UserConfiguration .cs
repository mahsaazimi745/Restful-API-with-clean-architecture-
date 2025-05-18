using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Entity;

namespace WebTestApI.InfrastructureLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.LatstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.FatherName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Age)
                .IsRequired();

            // NationalCode ValueObject mapping
            builder.OwnsOne(u => u.NationalCode, nc =>
            {
                nc.Property(n => n.Value)
                  .HasColumnName("NationalCode")
                  .HasMaxLength(10)
                  .IsRequired();
            });

            // PhoneNumber ValueObject mapping
            builder.OwnsOne(u => u.PhoneNumber, ph =>
            {
                ph.Property(p => p.Value)
                  .HasColumnName("PhoneNumber")
                  .HasMaxLength(15)
                  .IsRequired();
            });

            // Email ValueObject mapping
            builder.OwnsOne(u => u.Email, em =>
            {
                em.Property(e => e.Value)
                  .HasColumnName("Email")
                  .HasMaxLength(100)
                  .IsRequired();
            });

            // Password ValueObject mapping
            builder.OwnsOne(u => u.passwordHash, pw =>
            {
                pw.Property(p => p.HashedValue)
                  .HasColumnName("PasswordHash")
                  .HasMaxLength(256)
                  .IsRequired();
            });

            // Ignore computed properties
            builder.Ignore(u => u.FullName);
        }
    }
}
  
  
