using StaffCensus.DataAccess.Entities;

namespace StaffCensus.DataAccess.Repositories;

public interface IProgrammingLanguageRepository
{
    Task<List<ProgrammingLanguageEntity>> GetAllAsync();
}