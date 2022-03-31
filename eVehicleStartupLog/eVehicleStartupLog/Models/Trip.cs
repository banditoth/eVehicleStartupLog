using System;
using SQLite;

namespace eVehicleStartupLog.Models
{
    public class Trip
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public Guid PlateId { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid VehicleId { get; set; }

        public double? StartLatitude { get; set; }

        public double? StartLongitude { get; set; }

        public string StartAddress { get; set; }

        public DateTime StartDateTime { get; set; }

        public double? StopLatitude { get; set; }

        public double? StopLongitude { get; set; }

        public string StopAddress { get; set; }

        public DateTime? StopDateTime { get; set; }
    }
}
