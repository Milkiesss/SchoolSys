using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Infrastructure.Dal.EntityFramework.Configuration;

public class TeacherConfig: IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.FullName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(t => t.PhoneNumber)
            .HasMaxLength(20);
    }
}