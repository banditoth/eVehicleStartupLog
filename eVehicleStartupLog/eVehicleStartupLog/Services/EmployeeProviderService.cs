using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;

namespace eVehicleStartupLog.Services
{
    public class EmployeeProviderService : IEmployeeProvider
    {
        private readonly IEmployeeRepository repository;

        public EmployeeProviderService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public Task DeleteEmployee(UIEmployee employeeToDelete)
        {
            return repository.DeleteEmployee();
        }

        public Task<IEnumerable<UIEmployee>> GetAllEmployees()
        {
            return repository.GetAllEmployees();
        }

        public Task<UIEmployee> GetEmployee(Guid id)
        {
            return repository.GetEmployee(id);
        }

        public Task<UIEmployee> SaveEmployee(UIEmployee employeeToSave)
        {
            return repository.SaveEmployee(id);
        }
    }
}
