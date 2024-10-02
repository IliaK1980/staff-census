using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaffCensus.BusinessLogic.Models;

namespace StaffCensus.UI.Models;

public class EmployeeViewModel
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public int Age { get; set; }

    [Required]
    public string Gender { get; set; } = null!;

    [Required]
    public int DepartmentId { get; set; }

    public IEnumerable<SelectListItem> Departments { get; set; } = [];

    public List<int> ProgrammingLanguageIds { get; set; } = [];
    public IEnumerable<SelectListItem> ProgrammingLanguages { get; set; } = [];

    public EmployeeViewModel()
    {
    }

    public EmployeeViewModel(Employee employee)
    {
        Id = employee.Id;
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        Age = employee.Age;
        Gender = employee.Gender;
        DepartmentId = employee.DepartmentId;
        ProgrammingLanguageIds = [..employee.ProgrammingLanguages];
    }
}