using StaffCensus.BusinessLogic.Models;

namespace StaffCensus.BusinessLogic.Interfaces;

public interface IProgrammingLanguageService
{
    Task<IEnumerable<ProgrammingLanguage>> GetAllLanguagesAsync();
}