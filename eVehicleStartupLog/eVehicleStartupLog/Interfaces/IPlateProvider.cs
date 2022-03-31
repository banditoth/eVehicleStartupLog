using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Entities;

namespace eVehicleStartupLog.Interfaces
{
    public interface IPlateProvider
    {
        Task<UIPlate> GetPlate(Guid id);

        Task<List<UIPlate>> GetAllPlates();

        Task SavePlate(UIPlate plateToSave);

        Task DeletePlate(UIPlate plateToDelete);
    }
}
