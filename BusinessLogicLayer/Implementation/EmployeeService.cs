using AutoMapper;
using BusinessLogicLayer.Contracts;
using DataAccessLayer.DTO;
using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public void Create(EmployeeDTO employee)
        {
            var employeeModel = _mapper.Map<EmployeeDTO>(employee);
            _employeeRepository.CreateEmployee(employeeModel);
        }

        public void CreateEmployee(EmployeeDTO employee)
        {
            var employeeModel = _mapper.Map<EmployeeDTO>(employee);
            _employeeRepository.CreateEmployee(employeeModel);
        }

        public void CreateEmployees(EmployeesDTO employee)
        {
            var employeeModel = _mapper.Map<EmployeesDTO>(employee);
            _employeeRepository.CreateEmployees(employeeModel);
        }

        public void DeleteEmployeeById(int id)
        {
            _employeeRepository.DeleteEmployeeById(id);
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var employeeModel = _employeeRepository.FindById(id);

            if (employeeModel == null)
            {
                return null;
            }

            var employee = _mapper.Map<EmployeeDTO>(employeeModel);
            return employee;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }




        public void UpdateEmployee(EmployeeDTO employee)
        {
            var employeeModel = _mapper.Map<EmployeeDTO>(employee);
            _employeeRepository.UpdateEmployee(employeeModel);
        }
    }
}
