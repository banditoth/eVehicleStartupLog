using System;
using SQLite;

namespace eVehicleStartupLog.Models
{
    public class Vehicle
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public string VehicleIdentifier { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }
    }
}
