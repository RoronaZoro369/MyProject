using AutoMapper;
using BusinessLogicLayer.Contracts;
using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _logger = logger;
            _logger.LogDebug("Nlog is integrated to Employee Controller");
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _employeeService.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching employees.");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("FindById/{id}")]
        [HttpGet]
        public IActionResult FindById(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex, $"An error occurred while fetching employee with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeDTO employeeModel)
        {
            var employee = _mapper.Map<EmployeeDTO>(employeeModel);
            _employeeService.CreateEmployee(employee);
            return Ok(new { Message = "Employee created successfully" });
        }

        [Route("CreateEmployee")]
        [HttpPost]
        public ActionResult CreateEmployees(EmployeesDTO employeeModel)
        {
            var employee = _mapper.Map<EmployeesDTO>(employeeModel);
            _employeeService.CreateEmployees(employee);
            return Ok(new { Message = "Employee created successfully" });
        }

        [Route("Update")]
        [HttpPut]
        public ActionResult UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<EmployeeDTO>(employeeDTO);
            _employeeService.UpdateEmployee(employee);
            return Ok(new { Message = "Employee updated successfully" });
        }

        [Route("Delete")]
        [HttpDelete]
        public ActionResult DeleteEmployeeById(int id)
        {
            var existingEmployee = _employeeService.GetEmployeeById(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            _employeeService.DeleteEmployeeById(id);

            return Ok(new { Message = "Employee deleted successfully" });
        }
    }
}
