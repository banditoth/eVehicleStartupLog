using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Models;

namespace eVehicleStartupLog.Interfaces
{
    public interface IPlateRepository
    {
        Task<Plate> GetPlate(Guid id);

        Task<IEnumerable<Plate>> GetAllPlates();

        Task<Plate> SavePlate(Plate plateToSave);

        Task DeletePlate(Plate plateToDelete);
    }
}
