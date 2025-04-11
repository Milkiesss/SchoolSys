using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging.Abstractions;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Infrastructure.Dal.EntityFramework.Configuration;

public class SessionStudentConfiguration : IEntityTypeConfiguration<SessionStudent>
{
    public void Configure(EntityTypeBuilder<SessionStudent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.SessionSubject)
            .WithMany(ss => ss.Students) 
            .HasForeignKey(x => x.SessionSubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Student)
            .WithMany() 
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.Grade)
            .IsRequired();
    }
}