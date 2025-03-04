using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Infrastructure.Dal.EntityFramework.Configuration;

public class LessonConfig: IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.LessonDate)
            .HasColumnType("timestamp(0)")
            .IsRequired();

        builder.Property(l => l.Room)
            .HasMaxLength(50);

        builder.HasOne(l => l.Group)
            .WithMany()
            .HasForeignKey(l => l.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.Subject)
            .WithMany()
            .HasForeignKey(l => l.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.Teacher)
            .WithMany()
            .HasForeignKey(l => l.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}