using System.ComponentModel.DataAnnotations;

namespace StaffCensus.DataAccess.Entities;

public class EmployeeEntity
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;
    
    [Required]
    public int Age { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string Gender { get; set; } = null!;
    
    [Required]
    public int DepartmentId { get; set; }
    
    [Required]
    public bool IsDeleted { get; set; }
    
    public DepartmentEntity Department { get; set; } = null!;
    
    public ICollection<WorkExperienceEntity> WorkExperiences { get; set; } = [];
}