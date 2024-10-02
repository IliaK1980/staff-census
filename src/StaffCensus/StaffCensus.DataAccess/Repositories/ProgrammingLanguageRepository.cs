using Microsoft.EntityFrameworkCore;
using StaffCensus.DataAccess.Entities;

namespace StaffCensus.DataAccess.Repositories;

public class ProgrammingLanguageRepository(AppDbContext context) : IProgrammingLanguageRepository
{
    public async Task<List<ProgrammingLanguageEntity>> GetAllAsync()
    {
        return await context.ProgrammingLanguages.ToListAsync();
    }
}