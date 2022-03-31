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
        public readonly SQLiteAsyncConnection Connection;

        public SQLiteDatabaseConnector()
        {
            Connection = new SQLiteAsyncConnection(Constans.SQLDatabaseAccessString);
            Connection.CreateTablesAsync<Employee, Plate, Trip, Vehicle>().ConfigureAwait(true).GetAwaiter().GetResult();
        }
    }
}
