using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTestApI.CoreLayer.Entity;
using WebTestApI.CoreLayer.ValueObjects;
using WebTestApI.CoreLayer.Enums;

namespace WebTestApI.InfrastructureLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table per type
            builder.UseTptMappingStrategy();
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(u => u.LastName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(u => u.FatherName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(u => u.Age)
                   .IsRequired();

            builder.Property(u => u.Status)
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(u => u.ApprovedDate);

            builder.Property(u => u.ApprovedById);

            builder.HasOne(u => u.ApprovedBy)
                   .WithMany()
                   .HasForeignKey(u => u.ApprovedById)
                   .OnDelete(DeleteBehavior.NoAction);

            // Value Objects:
            builder.OwnsOne(u => u.NationalCode, nc =>
            {
                nc.Property(n => n.Value)
                  .HasColumnName("NationalCode")
                  .HasMaxLength(10)
                  .IsRequired();
            });

            builder.OwnsOne(u => u.PhoneNumber, pn =>
            {
                pn.Property(p => p.Value)
                  .HasColumnName("PhoneNumber")
                  .HasMaxLength(11)
                  .IsRequired();
            });

            builder.OwnsOne(u => u.Email, e =>
            {
                e.Property(ea => ea.Value)
                  .HasColumnName("Email")
                  .HasMaxLength(100)
                  .IsRequired();
            });

            builder.OwnsOne(u => u.PasswordHash, p =>
            {
                p.Property(ph => ph.Value)
                 .HasColumnName("PasswordHash")
                 .HasMaxLength(255)
                 .IsRequired();
            });

            // نقش‌ها
            builder.HasMany(u => u.UserRoles)
                   .WithOne()
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
