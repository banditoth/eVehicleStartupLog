using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Interfaces;
using eVehicleStartupLog.Models;

namespace eVehicleStartupLog.Database
{
    public class DatabaseContext : IVehicleRepository, IEmployeeRepository, ITripRepository, IPlateRepository
    {
        private readonly SQLiteDatabaseConnector _connector;

        public DatabaseContext()
        {
            _connector = new SQLiteDatabaseConnector();
        }

        private Task GeneralDelete<T>(T toDelete)
        {
            return _connector.Connection.DeleteAsync<T>(toDelete);
        }

        private Task<List<T>> GeneralGetAll<T>() where T : new()
        {
            return _connector.Connection.Table<T>().ToListAsync();
        }

        private Task<T> GeneralGetById<T>(Guid id) where T : new()
        {
            return _connector.Connection.GetAsync<T>(id);
        }

        private Task GeneralSave<T>(T toSave)
        {
            return _connector.Connection.InsertOrReplaceAsync(toSave);
        }


        public Task DeleteEmployee(Employee employeeToDelete)
        {
            return GeneralDelete(employeeToDelete);
        }

        public Task DeletePlate(Plate plateToDelete)
        {
            return GeneralDelete(plateToDelete);
        }

        public Task DeleteTrip(Trip tripToDelete)
        {
            return GeneralDelete(tripToDelete);
        }

        public Task DeleteVehicle(Vehicle vehicleToDelete)
        {
            return GeneralDelete(vehicleToDelete);
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            return GeneralGetAll<Employee>();        }

        public Task<List<Plate>> GetAllPlates()
        {
            return GeneralGetAll<Plate>();
        }

        public Task<List<Trip>> GetAllTrips()
        {
            return GeneralGetAll<Trip>();
        }

        public Task<List<Vehicle>> GetAllVehicles()
        {
            return GeneralGetAll<Vehicle>();
        }

        public Task<Employee> GetEmployee(Guid id)
        {
            return GeneralGetById<Employee>(id);
        }

        public Task<Plate> GetPlate(Guid id)
        {
            return GeneralGetById<Plate>(id);
        }

        public Task<Trip> GetTrip(Guid id)
        {
            return GeneralGetById<Trip>(id);
        }

        public Task<Vehicle> GetVehicle(Guid id)
        {
            return GeneralGetById<Vehicle>(id);
        }

        public Task SaveEmployee(Employee employeeToSave)
        {
            return GeneralSave(employeeToSave);
        }

        public Task SavePlate(Plate plateToSave)
        {
            return GeneralSave(plateToSave);
        }

        public Task SaveTrip(Trip tripToSave)
        {
            return GeneralSave(tripToSave);
        }

        public Task SaveVehicle(Vehicle vehicleToSave)
        {
            return GeneralSave(vehicleToSave);
        }
    }
}
