using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;
using eVehicleStartupLog.Models;
using eVehicleStartupLog.Resources;
using SQLite;

namespace eVehicleStartupLog.Database
{
    public class SQLiteDatabaseConnector
    {
        private readonly SQLiteAsyncConnection _connection;

        public SQLiteDatabaseConnector()
        {
            _connection = new SQLiteAsyncConnection(Constans.SQLDatabaseAccessString);
            _connection.CreateTablesAsync<Employee, Plate, Trip, Vehicle>().ConfigureAwait(true).GetAwaiter().GetResult();
        }
    }
}
