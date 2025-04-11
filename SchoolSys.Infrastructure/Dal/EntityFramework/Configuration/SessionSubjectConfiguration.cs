using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Infrastructure.Dal.EntityFramework.Configuration;

public class SessionSubjectConfiguration : IEntityTypeConfiguration<SessionSubject>
{
    public void Configure(EntityTypeBuilder<SessionSubject> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.ExaminationStatus)
            .IsRequired();
        
        builder.Property(s => s.IsIncludedInDiploma)
            .IsRequired();

        builder.HasOne(s => s.Session)
            .WithMany(s => s.Subjects)
            .HasForeignKey(ss => ss.SessionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Subject)
            .WithMany()
            .HasForeignKey(ss => ss.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(ss => ss.Students)
            .WithOne(st => st.SessionSubject)
            .HasForeignKey(sst => sst.SessionSubjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}