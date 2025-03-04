using Microsoft.EntityFrameworkCore;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Infrastructure.Dal.EntityFramework;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<User?> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentHistory> StudentHistories { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TeacherSubject> TeacherSubjectsvies { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}