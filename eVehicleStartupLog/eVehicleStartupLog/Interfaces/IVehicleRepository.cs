using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Models;

namespace eVehicleStartupLog.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(Guid id);

        Task<List<Vehicle>> GetAllVehicles();

        Task SaveVehicle(Vehicle vehicleToSave);

        Task DeleteVehicle(Vehicle vehicleToDelete);
    }
}
