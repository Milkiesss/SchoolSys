using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Infrastructure.Dal.EntityFramework.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(u => u.PasswordHash)
            .IsRequired();
        
        builder.HasOne(u => u.Teacher)
            .WithOne()
            .HasForeignKey<User>(u => u.TeacherId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(u => u.Student)
            .WithOne()
            .HasForeignKey<User>(s => s.StudentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}