using System;
using SQLite;

namespace eVehicleStartupLog.Models
{
    public class Employee
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string DriversLicenseId { get; set; }

        public string PersonalId { get; set; }

        public DateTime EmploymentContractStartDate { get; set; }
    }
}
