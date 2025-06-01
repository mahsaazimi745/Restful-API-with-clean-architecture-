using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTestApI.CoreLayer.Entity;

namespace WebTestApI.InfrastructureLayer.Configurations
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasBaseType<User>();

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
