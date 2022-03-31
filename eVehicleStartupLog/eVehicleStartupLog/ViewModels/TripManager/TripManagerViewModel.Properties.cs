using System;
using System.Collections.ObjectModel;
using eVehicleStartupLog.Entities;

namespace eVehicleStartupLog.ViewModels
{
    public partial class TripManagerViewModel
    {
        public bool HasRunningTrip
        {
            get
            {
                return OnGoingTrip != null;
            }
        }

        private UITrip onGoingTrip;
        public UITrip OnGoingTrip
        {
            get => onGoingTrip;
            set
            {
                SetProperty(ref onGoingTrip, value);
                NotifyPropertyChanged(nameof(OnGoingTrip));
            }
        }

        private ObservableCollection<UIEmployee> employees;
        public ObservableCollection<UIEmployee> Employees
        {
            get => employees;
            set => SetProperty(ref employees, value);
        }

        private ObservableCollection<UIPlate> plates;
        public ObservableCollection<UIPlate> Plates
        {
            get => plates;
            set => SetProperty(ref plates, value);
        }

        private ObservableCollection<UIVehicle> vehicles;
        public ObservableCollection<UIVehicle> Vehicles
        {
            get => vehicles;
            set => SetProperty(ref vehicles, value);
        }

        private UIEmployee selectedEmployee;
        public UIEmployee SelectedEmployee
        {
            get => selectedEmployee;
            set => SetProperty(ref selectedEmployee, value);
        }

        private UIPlate selectedPlate;
        public UIPlate SelectedPlate
        {
            get => selectedPlate;
            set => SetProperty(ref selectedPlate, value);
        }


        private UIVehicle selectedVehicle;
        public UIVehicle SelectedVehicle
        {
            get => selectedVehicle;
            set => SetProperty(ref selectedVehicle, value);
        }


    }
}
