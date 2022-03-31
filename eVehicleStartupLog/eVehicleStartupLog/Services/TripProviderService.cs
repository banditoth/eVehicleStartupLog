using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;
using eVehicleStartupLog.Models;

namespace eVehicleStartupLog.Services
{
    public class TripProviderService : ITripProvider
    {
        private readonly ITripRepository repository;
        private readonly IMapper mapper;

        public TripProviderService(ITripRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task DeleteTrip(UITrip TripToDelete)
        {
            return repository.DeleteTrip(mapper.Map<Trip>(TripToDelete));
        }

        public async Task<List<UITrip>> GetAllTrips()
        {
            return mapper.Map<List<UITrip>>(await repository.GetAllTrips());
        }

        public async Task<UITrip> GetTrip(Guid id)
        {
            return mapper.Map<UITrip>(await repository.GetTrip(id));
        }

        public Task SaveTrip(UITrip TripToSave)
        {
            return  repository.SaveTrip(mapper.Map<Trip>(TripToSave));
        }
    }

}
