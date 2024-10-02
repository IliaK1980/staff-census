using System.ComponentModel.DataAnnotations;

namespace StaffCensus.DataAccess.Entities;

public class ProgrammingLanguageEntity
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
}