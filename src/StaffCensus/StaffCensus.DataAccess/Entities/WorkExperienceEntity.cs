using System.ComponentModel.DataAnnotations;

namespace StaffCensus.DataAccess.Entities;

public class WorkExperienceEntity
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int EmployeeId { get; set; }

    public EmployeeEntity Employee { get; set; } = null!;
    
    [Required]
    public int ProgrammingLanguageId { get; set; }
    
    public ProgrammingLanguageEntity ProgrammingLanguage { get; set; } = null!;
}