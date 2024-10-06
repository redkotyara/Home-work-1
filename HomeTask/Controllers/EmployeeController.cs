using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using HomeTask.BusinessLogic.Models;
using HomeTask.BusinessLogic.Services.Interfaces;
using HomeTask.Filters;

namespace HomeTask.Controllers
{
    [BasicAuthentication]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IProgramingLanguageService _programingLanguageService;
        private readonly IGenderService _genderService;
        
        public EmployeeController(
            IEmployeeService employeeService, 
            IProgramingLanguageService programingLanguageService, 
            IDepartmentService departmentService,
            IGenderService genderService)
        {
            _employeeService = employeeService;
            _programingLanguageService = programingLanguageService;
            _departmentService = departmentService;
            _genderService = genderService;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetEmployees(
            string? lastName,
            int? departmentId,
            string? firstName,
            int? age,
            int? genderId,
            int? programLanguageId,
            int? pageNumber,
            CancellationToken token)
        {
            var filter = new GetEmployeesFilter
            {
                DepartmentId = departmentId,
                FirstName = firstName,
                GenderId = genderId,
                Age = age,
                LastMame = lastName,
                ProgramLanguageId = programLanguageId
            };

            const int pageSize = 10;
            
            var employees = await _employeeService.GetEmployeesAsync(
                filter,
                pageNumber ?? 1,
                pageSize,
                token);
            
            await LoadStaticDataAsync(token);

            ViewData["lastName"] = lastName;
            ViewData["departmentId"] = departmentId;
            ViewData["firstName"] = firstName;
            ViewData["age"] = age;
            ViewData["genderId"] = genderId;
            ViewData["programLanguageId"] = programLanguageId;

            return View("Index", employees);
        }

        private async Task LoadStaticDataAsync(CancellationToken token)
        {
            var departments = await _departmentService.GetAllDepartmentsAsync(token);
            var programingLanguages = await _programingLanguageService.GetProgramingLanguagesAsync(token);
            var genders = await _genderService.GetGendersAsync(token);
            
            ViewData["Departments"] = departments;
            ViewData["ProgramingLanguages"] = programingLanguages;
            ViewData["Genders"] = genders;
        }

        [HttpGet]
        public async Task<ActionResult> Add(CancellationToken token)
        {
            await LoadStaticDataAsync(token);
            
            return View("Add");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id, CancellationToken token)
        {
            var employee = await _employeeService.GetEmployeeAsync(id, token);
            
            await LoadStaticDataAsync(token);

            var model = new CreateOrUpdateEmployeeModel
            {
                EmployeeId = employee.EmployeeId,
                Age = employee.Age,
                DepartmentId = employee.Department.DepartmentId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                GenderId = employee.Gender.GenderId,
                ProgramingLanguageIds = employee.ProgramingLanguages.Select(x => x.ProgramingLanguageId).ToArray()
            };
            
            return View("Edit", model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id, CancellationToken token)
        {
            await _employeeService.DeleteEmployeeAsync(id, token);
            
            return RedirectToAction("GetEmployees", "Employee");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(
            CreateOrUpdateEmployeeModel model,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                await LoadStaticDataAsync(cancellationToken);
                return View("Edit", model);
            }
            
            await _employeeService.EditEmployeeAsync(model, cancellationToken);

            return RedirectToAction("GetEmployees", "Employee");
        }
        

        [HttpPost]
        public async Task<ActionResult> Add(CreateOrUpdateEmployeeModel model, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                await LoadStaticDataAsync(token);
                return View("Add", model);
            }
            
            await _employeeService.AddEmployeeAsync(model, token);
            
            return RedirectToAction("GetEmployees", "Employee");
        }
    }
}