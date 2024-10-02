namespace StaffCensus.BusinessLogic.Models;

public class Employee
{
    public int Id { get; set; }
	
	public string FirstName { get; set; } = null!;
	
	public string LastName { get; set; } = null!;
	
	public int Age { get; set; }
	
	public string Gender { get; set; } = null!;

	public int DepartmentId { get; set; }
	
	public List<int> ProgrammingLanguages { get; set; } = [];
}