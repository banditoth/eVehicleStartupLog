using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using DryIoc;
using eVehicleStartupLog.Interfaces;
using eVehicleStartupLog.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eVehicleStartupLog.ViewModels
{
    public partial class MainFlyoutViewModel : BaseViewModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IMvvmHelper mvvmHelper;

        public MainFlyoutViewModel(IMvvmHelper mvvmHelper, IErrorHandler errorHandler)
        {
            this.mvvmHelper = mvvmHelper;
            this.errorHandler = errorHandler;
        }

        public void Initalize()
        {
            _ = RequestLocationPermissionIfNeeded();
            App.SetFlyoutDetailPage(mvvmHelper.GetInstance<TripManagerViewModel, TripManagerView>((vm, v) =>
            {
                vm.Initalize();
            }));
        }

        private async Task RequestLocationPermissionIfNeeded()
        {
            try
            {
                if (await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>() != PermissionStatus.Granted)
                {
                    await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

        private async Task OpenPreviousTripList()
        {
            try
            {
                App.SetFlyoutDetailPage(mvvmHelper.GetInstance<PreviousTripListViewModel, PreviousTripListView>((vm, v) =>
                {
                    vm.Initalize();
                }));
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }


        private async Task OpenPlatesList()
        {
            try
            {
                App.SetFlyoutDetailPage(mvvmHelper.GetInstance<PlatesListViewModel, PlateListView>((vm, v) =>
                {
                    vm.Initalize();
                }));
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

        private async Task OpenEmployeesList()
        {
            try
            {
                App.SetFlyoutDetailPage(mvvmHelper.GetInstance<EmployeesListViewModel, EmployeeListView>((vm, v) =>
                {
                    vm.Initalize();
                }));
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

        private async Task OpenVehiclesList()
        {
            try
            {
                App.SetFlyoutDetailPage(mvvmHelper.GetInstance<VehiclesListViewModel, VehicleListView>((vm, v) =>
                {
                    vm.Initalize();
                }));
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }
    }
}
