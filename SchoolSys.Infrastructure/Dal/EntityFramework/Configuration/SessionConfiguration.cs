using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Infrastructure.Dal.EntityFramework.Configuration;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x=>x.Subject)
            .WithMany()
            .HasForeignKey(x=>x.Subject)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x=>x.Group)
            .WithMany()
            .HasForeignKey(x=>x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.Grade);
        
        builder.Property(x => x.SessionDate)
            .HasColumnType("timestamp(0)");

        builder.Property(x => x.Comments);
        builder.Property(x => x.Status);
    }
}