using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Entities;

namespace eVehicleStartupLog.Interfaces
{
    public interface ITripProvider
    {
        Task<UITrip> GetTrip(Guid id);

        Task<IEnumerable<UITrip>> GetAllTrips();

        Task<UITrip> SaveTrip(UITrip tripToSave);

        Task DeleteTrip(UITrip tripToDelete);
    }
}
