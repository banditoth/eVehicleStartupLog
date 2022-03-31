using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Models;

namespace eVehicleStartupLog.Interfaces
{
    public interface ITripRepository
    {
        Task<Trip> GetTrip(Guid id);

        Task<IEnumerable<Trip>> GetAllTrips();

        Task<Trip> SaveTrip(Trip tripToSave);

        Task DeleteTrip(Trip tripToDelete);
    }
}
