using StaffCensus.DataAccess.Entities;

namespace StaffCensus.DataAccess.Repositories;

public interface IDepartmentRepository
{
    Task<List<DepartmentEntity>> GetAllAsync();
}