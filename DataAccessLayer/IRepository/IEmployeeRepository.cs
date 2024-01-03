using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO FindById(int id);
        void Create(EmployeeDTO employee);
        void CreateEmployee(EmployeeDTO employee);
        void CreateEmployees(EmployeesDTO employee);
        void UpdateEmployee(EmployeeDTO employee);
        void DeleteEmployeeById(int id);
    }
}
