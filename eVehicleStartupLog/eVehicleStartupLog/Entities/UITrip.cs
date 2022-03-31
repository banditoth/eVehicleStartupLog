using System;
using banditoth.Forms.RecurrenceToolkit.MVVM;

namespace eVehicleStartupLog.Entities
{
    public class UITrip : BindableObject
    {
        private Guid id;
        private UIPlate plate;
        private UIEmployee employee;
        private UIVehicle vehicle;
        private double? startLatitude;
        private double? startLongitude;
        private string startAddress;
        private DateTime startDateTime;
        private double? stopLatitude;
        private double? stopLongitude;
        private string stopAddress;
        private DateTime? stopDateTime;

        public Guid Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public UIPlate Plate
        {
            get => plate;
            set => SetProperty(ref plate, value);
        }

        public UIEmployee Employee
        {
            get => employee;
            set => SetProperty(ref employee, value);
        }

        public UIVehicle Vehicle
        {
            get => vehicle;
            set => SetProperty(ref vehicle, value);
        }

        public double? StartLatitude
        {
            get => startLatitude;
            set => SetProperty(ref startLatitude, value);
        }

        public double? StartLongitude
        {
            get => startLongitude;
            set => SetProperty(ref startLongitude, value);
        }

        public string StartAddress
        {
            get => startAddress;
            set => SetProperty(ref startAddress, value);
        }

        public DateTime StartDateTime
        {
            get => startDateTime;
            set => SetProperty(ref startDateTime, value);
        }

        public double? StopLatitude
        {
            get => stopLatitude;
            set => SetProperty(ref stopLatitude, value);
        }

        public double? StopLongitude
        {
            get => stopLongitude;
            set => SetProperty(ref stopLongitude, value);
        }

        public string StopAddress
        {
            get => stopAddress;
            set => SetProperty(ref stopAddress, value);
        }

        public DateTime? StopDateTime
        {
            get => stopDateTime;
            set => SetProperty(ref stopDateTime, value);
        }

    }
}
