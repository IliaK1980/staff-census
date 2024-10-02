using System.ComponentModel.DataAnnotations;

namespace StaffCensus.DataAccess.Entities;

public class DepartmentEntity
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    
    [Required]
    [Range(minimum: 1, maximum: 50)]
    public int Floor { get; set; }
}