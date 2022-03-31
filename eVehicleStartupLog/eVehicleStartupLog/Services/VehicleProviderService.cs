using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;
using eVehicleStartupLog.Models;

namespace eVehicleStartupLog.Services
{
    public class VehicleProviderService : IVehicleProvider
    {
        private readonly IVehicleRepository repository;
        private readonly IMapper mapper;

        public VehicleProviderService(IVehicleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task DeleteVehicle(UIVehicle VehicleToDelete)
        {
            return repository.DeleteVehicle(mapper.Map<Vehicle>(VehicleToDelete));
        }

        public async Task<List<UIVehicle>> GetAllVehicles()
        {
            return mapper.Map<List<UIVehicle>>(await repository.GetAllVehicles());
        }

        public async Task<UIVehicle> GetVehicle(Guid id)
        {
            return mapper.Map<UIVehicle>(await repository.GetVehicle(id));
        }

        public Task SaveVehicle(UIVehicle VehicleToSave)
        {
            return repository.SaveVehicle(mapper.Map<Vehicle>(VehicleToSave));
        }
    }

}
