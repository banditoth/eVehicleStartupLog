using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Entities;

namespace eVehicleStartupLog.Interfaces
{
    public interface IVehicleProvider
    {
        Task<UIVehicle> GetVehicle(Guid id);

        Task<IEnumerable<UIVehicle>> GetAllVehicles();

        Task<UIVehicle> SaveVehicle(UIVehicle vehicleToSave);

        Task DeleteVehicle(UIVehicle vehicleToDelete);
    }
}
