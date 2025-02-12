using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Infrastructure.Dal.EntityFramework.Configuration;

public class GroupConfig : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(g => g.Course)
            .IsRequired();

        builder.HasOne(g => g.Faculty)
            .WithMany(f => f.Groups)
            .HasForeignKey(g => g.FacultyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}