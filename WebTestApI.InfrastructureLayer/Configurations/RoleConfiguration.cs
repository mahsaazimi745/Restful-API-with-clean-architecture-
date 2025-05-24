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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>

    {/*
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // نام جدول در دیتابیس
            builder.ToTable("Roles");

            // کلید اصلی
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .IsRequired();

            // پیکربندی فیلد Name
            builder.Property(r => r.RuleName)
                .HasMaxLength(50)
                .IsRequired();

            // رابطه با جدول واسط UserRoles
            builder.HasMany(r => r.UserRoles)
                   .WithOne(ur => ur.Role)
                   .HasForeignKey(ur => ur.RoleId);
        }*/
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.RuleName)
                   .HasMaxLength(50)
                   .IsRequired();

            // ✅ نقش‌ها رو Seed می‌کنیم
            builder.HasData(
                new Role("Admin") { Id = Guid.Parse("f5a21fd5-3e4c-4a0f-bb6d-0f4206a7c79c") },
                new Role("Coach") { Id = Guid.Parse("bd3f7f57-c60d-4c91-8fd7-92f7f4ea10a6") },
                new Role("Writer") { Id = Guid.Parse("d31f6dc7-9426-44b8-bbb2-7f5a42c1139b") }
            );
        }
    }
}
