using Microsoft.EntityFrameworkCore;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Infrastructure.Controllers.EntityFramework.Configuration;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentHistory> StudentHistories { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TeacherSubject> TeacherSubjectsvies { get; set; }
}