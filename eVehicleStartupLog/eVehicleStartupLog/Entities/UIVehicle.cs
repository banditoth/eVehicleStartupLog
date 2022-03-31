using System;
using banditoth.Forms.RecurrenceToolkit.MVVM;

namespace eVehicleStartupLog.Entities
{
    public class UIVehicle : BindableObject
    {
        private Guid id;
        private string vehicleIdentifier;
        private string manufacturer;
        private string model;
        private int year;

        public Guid Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string VehicleIdentifier
        {
            get => vehicleIdentifier;
            set
            {
                SetProperty(ref vehicleIdentifier, value);
                NotifyPropertyChanged(nameof(DisplayName));
            }
        }

        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                SetProperty(ref manufacturer, value);
                NotifyPropertyChanged(nameof(DisplayName));
            }
        }

        public string Model
        {
            get => model;
            set
            {
                SetProperty(ref model, value);
                NotifyPropertyChanged(nameof(DisplayName));
            }
        }

        public int Year
        {
            get => year;
            set
            {
                SetProperty(ref year, value);
                NotifyPropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName
        {
            get
            {
                string result = manufacturer + " " + model + " (" + year + ") " + vehicleIdentifier;
                return string.IsNullOrWhiteSpace(result) ? null : result;
            }
        }
    }
}
