using Microsoft.Extensions.DependencyInjection;
using StaffCensus.BusinessLogic.Interfaces;
using StaffCensus.BusinessLogic.Services;

namespace StaffCensus.BusinessLogic;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        
        return services;
    }
}