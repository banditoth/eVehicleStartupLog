using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Entities;

namespace eVehicleStartupLog.Interfaces
{
    public interface IPlateProvider
    {
        Task<UIPlate> GetPlate(Guid id);

        Task<IEnumerable<UIPlate>> GetAllPlates();

        Task<UIPlate> SavePlate(UIPlate plateToSave);

        Task DeletePlate(UIPlate plateToDelete);
    }
}
