using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Models;

namespace eVehicleStartupLog.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(Guid id);

        Task<IEnumerable<Vehicle>> GetAllVehicles();

        Task<Vehicle> SaveVehicle(Vehicle vehicleToSave);

        Task DeleteVehicle(Vehicle vehicleToDelete);
    }
}
