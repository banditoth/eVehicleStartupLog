using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;
using eVehicleStartupLog.Models;

namespace eVehicleStartupLog.Services
{
    public class EmployeeProviderService : IEmployeeProvider
    {
        private readonly IEmployeeRepository repository;
        private readonly IMapper mapper;

        public EmployeeProviderService(IEmployeeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task DeleteEmployee(UIEmployee employeeToDelete)
        {
            return repository.DeleteEmployee(mapper.Map<Employee>(employeeToDelete));
        }

        public async Task<List<UIEmployee>> GetAllEmployees()
        {
            return mapper.Map<List<UIEmployee>>(await repository.GetAllEmployees());
        }

        public async Task<UIEmployee> GetEmployee(Guid id)
        {
            return mapper.Map<UIEmployee>(await repository.GetEmployee(id));
        }

        public Task SaveEmployee(UIEmployee employeeToSave)
        {
            return repository.SaveEmployee(mapper.Map<Employee>(employeeToSave));
        }
    }
}
