using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Entities;

namespace eVehicleStartupLog.Interfaces
{
    public interface IEmployeeProvider
    {
        Task<UIEmployee> GetEmployee(Guid id);

        Task<IEnumerable<UIEmployee>> GetAllEmployees();

        Task<UIEmployee> SaveEmployee(UIEmployee employeeToSave);

        Task DeleteEmployee(UIEmployee employeeToDelete);
    }
}
