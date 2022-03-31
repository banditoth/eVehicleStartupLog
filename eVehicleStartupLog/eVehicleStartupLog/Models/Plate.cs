using System;
using SQLite;

namespace eVehicleStartupLog.Models
{
    public class Plate
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public string PlateNumber { get; set; }

        public DateTime IssuedDateTime { get; set; }
    }
}
