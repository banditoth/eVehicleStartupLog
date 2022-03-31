using System;
using banditoth.Forms.RecurrenceToolkit.MVVM;

namespace eVehicleStartupLog.Entities
{
    public class UIPlate : BindableObject
    {
        private Guid id;
        private string plateNumber;
        private DateTime issuedDateTime;

        public Guid Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string PlateNumber
        {
            get => plateNumber;
            set => SetProperty(ref plateNumber, value);
        }

        public DateTime IssuedDateTime
        {
            get => issuedDateTime;
            set => SetProperty(ref issuedDateTime, value);
        }
    }
}
