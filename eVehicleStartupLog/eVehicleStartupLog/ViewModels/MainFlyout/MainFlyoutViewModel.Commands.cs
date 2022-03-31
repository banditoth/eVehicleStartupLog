using System;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace eVehicleStartupLog.ViewModels
{
    public partial class MainFlyoutViewModel
    {
        private AsyncCommand _openEmployeesCommand;
        public AsyncCommand OpenEmployeesCommand { get => _openEmployeesCommand ?? (_openEmployeesCommand = new AsyncCommand(OpenEmployeesList)); }


        private AsyncCommand _openPlatesCommand;
        public AsyncCommand OpenPlatesCommand { get => _openPlatesCommand ?? (_openPlatesCommand = new AsyncCommand(OpenPlatesList)); }


        private AsyncCommand _openPreviousTripsCommand;
        public AsyncCommand OpenPreviousTripsCommand { get => _openPreviousTripsCommand ?? (_openPreviousTripsCommand = new AsyncCommand(OpenPreviousTripList)); }


        private AsyncCommand _openVehiclesCommand;
        public AsyncCommand OpenVehiclesCommand { get => _openVehiclesCommand ?? (_openVehiclesCommand = new AsyncCommand(OpenVehiclesList)); }

    }
}
