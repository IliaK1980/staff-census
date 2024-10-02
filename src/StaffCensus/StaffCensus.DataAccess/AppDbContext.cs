using Microsoft.EntityFrameworkCore;
using StaffCensus.DataAccess.Entities;

namespace StaffCensus.DataAccess;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<ProgrammingLanguageEntity> ProgrammingLanguages { get; set; }
    public DbSet<WorkExperienceEntity> WorkExperiences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentEntity>().HasData(
            new DepartmentEntity { Id = 1, Name = "IT", Floor = 2 },
            new DepartmentEntity { Id = 2, Name = "HR", Floor = 1 }
        );

        modelBuilder.Entity<ProgrammingLanguageEntity>().HasData(
            new ProgrammingLanguageEntity { Id = 1, Name = "C#" },
            new ProgrammingLanguageEntity { Id = 2, Name = "Java" }
        );
    }
}