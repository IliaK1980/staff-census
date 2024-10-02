using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaffCensus.BusinessLogic.Interfaces;
using StaffCensus.BusinessLogic.Models;
using StaffCensus.UI.Models;

namespace StaffCensus.UI.Controllers;

public class HomeController(
    IEmployeeService employeeService,
    IDepartmentService departmentService,
    IProgrammingLanguageService programmingLanguageService,
    ILogger<HomeController> logger) : Controller
{
    public async Task<IActionResult> Index(string search)
    {
        var employees = (await employeeService.GetAllEmployeesAsync(search)).Select(e => new EmployeeListItemModel
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Department = e.Department
        });

        return View(employees);
    }

    // Добавление сотрудника
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new EmployeeViewModel
        {
            Departments =
                (await departmentService.GetAllDepartmentsAsync()).Select(x =>
                    new SelectListItem(x.Name, x.Id.ToString())),
            ProgrammingLanguages =
                (await programmingLanguageService.GetAllLanguagesAsync()).Select(x =>
                    new SelectListItem(x.Name, x.Id.ToString()))
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EmployeeViewModel model)
    {
        if (ModelState.IsValid)
        {
            await employeeService.AddEmployeeAsync(new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                DepartmentId = model.DepartmentId,
                Gender = model.Gender,
                ProgrammingLanguages = [..model.ProgrammingLanguageIds]
            });
            return RedirectToAction("Index");
        }

        model.Departments =
            (await departmentService.GetAllDepartmentsAsync()).Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        model.ProgrammingLanguages =
            (await programmingLanguageService.GetAllLanguagesAsync()).Select(x =>
                new SelectListItem(x.Name, x.Id.ToString()));
        return View(model);
    }

    // Редактирование сотрудника
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var employee = await employeeService.GetEmployeeByIdAsync(id);

        var model = new EmployeeViewModel(employee)
        {
            Departments =
                (await departmentService.GetAllDepartmentsAsync()).Select(x =>
                    new SelectListItem(x.Name, x.Id.ToString())),
            ProgrammingLanguages =
                (await programmingLanguageService.GetAllLanguagesAsync()).Select(x =>
                    new SelectListItem(x.Name, x.Id.ToString()))
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EmployeeViewModel model)
    {
        if (ModelState.IsValid)
        {
            employeeService.UpdateEmployeeAsync(new Employee
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Gender = model.Gender,
                DepartmentId = model.DepartmentId,
                ProgrammingLanguages = [..model.ProgrammingLanguageIds]
            });
            return RedirectToAction("Index");
        }

        model.Departments =
            (await departmentService.GetAllDepartmentsAsync()).Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        model.ProgrammingLanguages =
            (await programmingLanguageService.GetAllLanguagesAsync()).Select(x =>
                new SelectListItem(x.Name, x.Id.ToString()));
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await employeeService.SoftDeleteEmployeeAsync(id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}