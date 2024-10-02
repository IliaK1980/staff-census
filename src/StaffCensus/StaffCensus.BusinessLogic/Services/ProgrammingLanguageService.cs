using StaffCensus.BusinessLogic.Interfaces;
using StaffCensus.BusinessLogic.Models;
using StaffCensus.DataAccess.Repositories;

namespace StaffCensus.BusinessLogic.Services;

public class ProgrammingLanguageService(IProgrammingLanguageRepository repository) : IProgrammingLanguageService
{
    public async Task<IEnumerable<ProgrammingLanguage>> GetAllLanguagesAsync()
    {
        return (await repository.GetAllAsync()).Select(x => new ProgrammingLanguage
        {
            Id = x.Id,
            Name = x.Name
        });
    }
}