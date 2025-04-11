using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Infrastructure.Dal.EntityFramework.Configuration;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(s => s.Group)
            .WithMany() 
            .HasForeignKey(x => x.GroupId)
            .IsRequired();

        builder.HasMany(s => s.Subjects)
            .WithOne(ss => ss.Session) 
            .HasForeignKey(ss => ss.SessionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.SessionDate)
            .HasColumnType("timestamp(0)");
    }
}