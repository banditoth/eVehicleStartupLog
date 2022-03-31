using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Entities;

namespace eVehicleStartupLog.Interfaces
{
    public interface IEmployeeProvider
    {
        Task<UIEmployee> GetEmployee(Guid id);

        Task<List<UIEmployee>> GetAllEmployees();

        Task SaveEmployee(UIEmployee employeeToSave);

        Task DeleteEmployee(UIEmployee employeeToDelete);
    }
}
