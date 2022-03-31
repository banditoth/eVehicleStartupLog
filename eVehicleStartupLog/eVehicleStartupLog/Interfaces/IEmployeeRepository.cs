using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Models;

namespace eVehicleStartupLog.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(Guid id);

        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> SaveEmployee(Employee employeeToSave);

        Task DeleteEmployee(Employee employeeToDelete);
    }
}
