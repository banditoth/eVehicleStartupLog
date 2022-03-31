using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;
using eVehicleStartupLog.Models;

namespace eVehicleStartupLog.Services
{
    public class PlateProviderService : IPlateProvider
    {
        private readonly IPlateRepository repository;
        private readonly IMapper mapper;

        public PlateProviderService(IPlateRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task DeletePlate(UIPlate PlateToDelete)
        {
            return repository.DeletePlate(mapper.Map<Plate>(PlateToDelete));
        }

        public async Task<List<UIPlate>> GetAllPlates()
        {
            return mapper.Map<List<UIPlate>>(await repository.GetAllPlates());
        }

        public async Task<UIPlate> GetPlate(Guid id)
        {
            return mapper.Map<UIPlate>(await repository.GetPlate(id));
        }

        public Task SavePlate(UIPlate PlateToSave)
        {
            return repository.SavePlate(mapper.Map<Plate>(PlateToSave));
        }
    }
}
