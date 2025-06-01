using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTestApI.CoreLayer.Entity;

namespace WebTestApI.InfrastructureLayer.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasBaseType<User>();

            builder.Property(s => s.Level)
                   .HasConversion<int?>();

            builder.OwnsOne(s => s.ParentsPhoneNumber, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("ParentsPhoneNumber")
                 .HasMaxLength(15);
            });

            builder.HasOne(s => s.ApprovedByCoach)
                   .WithMany(c => c.ApprovedStudents)
                   .HasForeignKey(s => s.ApprovedByCoachId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Students");
        }
    }
}
