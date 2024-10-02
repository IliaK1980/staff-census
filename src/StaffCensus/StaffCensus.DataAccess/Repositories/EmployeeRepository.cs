using Microsoft.EntityFrameworkCore;
using StaffCensus.DataAccess.Entities;

namespace StaffCensus.DataAccess.Repositories;

public class EmployeeRepository(AppDbContext context) : IEmployeeRepository
{
    public IQueryable<EmployeeEntity> GetAll()
    {
        return context.Employees.Where(e => !e.IsDeleted);
    }

    public Task<EmployeeEntity?> GetAsync(int id)
    {
        return context.Employees.Include(x => x.WorkExperiences).Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddAsync(EmployeeEntity employee)
    {
        context.Employees.Add(employee);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EmployeeEntity employee)
    {
        context.Entry(employee).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await context.Employees.FindAsync(id);
        if (employee != null)
        {
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }
    }
}