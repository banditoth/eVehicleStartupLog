using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Entities;

namespace eVehicleStartupLog.Interfaces
{
    public interface ITripProvider
    {
        Task<UITrip> GetTrip(Guid id);

        Task<List<UITrip>> GetAllTrips();

        Task SaveTrip(UITrip tripToSave);

        Task DeleteTrip(UITrip tripToDelete);
    }
}
