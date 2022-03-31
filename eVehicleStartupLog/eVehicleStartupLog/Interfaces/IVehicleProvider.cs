using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Entities;

namespace eVehicleStartupLog.Interfaces
{
    public interface IVehicleProvider
    {
        Task<UIVehicle> GetVehicle(Guid id);

        Task<List<UIVehicle>> GetAllVehicles();

        Task SaveVehicle(UIVehicle vehicleToSave);

        Task DeleteVehicle(UIVehicle vehicleToDelete);
    }
}
