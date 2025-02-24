using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Infrastructure.Dal.EntityFramework.Configuration;

public class StudentHistoryConfig : IEntityTypeConfiguration<StudentHistory>
{
    public void Configure(EntityTypeBuilder<StudentHistory> builder)
    {
        builder.HasKey(sh => sh.Id);

        builder.Property(sh => sh.ChangeDate)
            .IsRequired();

        builder.Property(sh => sh.Comment)
            .HasMaxLength(500);
        
        builder.HasOne(sh => sh.Student)
            .WithMany(s => s.History)
            .HasForeignKey(sh => sh.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}