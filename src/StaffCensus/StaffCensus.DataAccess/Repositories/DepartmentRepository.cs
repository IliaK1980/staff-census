using Microsoft.EntityFrameworkCore;
using StaffCensus.DataAccess.Entities;

namespace StaffCensus.DataAccess.Repositories;

public class DepartmentRepository(AppDbContext context) : IDepartmentRepository
{
    public async Task<List<DepartmentEntity>> GetAllAsync()
    {
        return await context.Departments.ToListAsync();
    }
}