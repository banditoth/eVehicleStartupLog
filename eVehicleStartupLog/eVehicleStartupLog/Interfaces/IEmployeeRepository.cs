using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Models;

namespace eVehicleStartupLog.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(Guid id);

        Task<List<Employee>> GetAllEmployees();

        Task SaveEmployee(Employee employeeToSave);

        Task DeleteEmployee(Employee employeeToDelete);
    }
}
