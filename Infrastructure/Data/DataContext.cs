using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options){}

    public DbSet<Course> Courses { get; set; } 
    public DbSet<Group> Groups { get; set; } 
    public DbSet<Student> Students { get; set; } 
    public DbSet<Mentor> Mentors { get; set; } 
    public DbSet<StudentGroup> StudentGroups { get; set; }
    public DbSet<MentorGroup> MentorGroups { get; set; } 
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Course>()
            .HasMany(x => x.Groups)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.OnModelCreating(builder);
    }
}


