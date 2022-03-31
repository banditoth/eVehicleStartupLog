using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using DryIoc;
using eVehicleStartupLog.Interfaces;
using Xamarin.Forms;

namespace eVehicleStartupLog.ViewModels
{
    public class MainFlyoutViewModel : BaseViewModel
    {
        private readonly IErrorHandler _errorHandler;

        public MainFlyoutViewModel()
        {
            _errorHandler = App.GetContainer().Resolve<IErrorHandler>();
        }

        public void Initalize()
        {
            App.SetFlyoutDetailPage();
        }

        private async Task OpenPreviousTripList()
        {
            try
            {
                App.SetFlyoutDetailPage(Connector.CreateInstance<PreviousTripListViewModel>((vm, v) =>
                {
                    vm.Initalize();
                }));
            }
            catch (Exception ex)
            {
                _errorHandler.HandleException(ex);
            }
        }


        private async Task OpenPlatesList()
        {
            try
            {
                App.SetFlyoutDetailPage(Connector.CreateInstance<PlatesListViewModel>((vm, v) =>
                {
                    vm.Initalize();
                }));
            }
            catch (Exception ex)
            {
                _errorHandler.HandleException(ex);
            }
        }

        private async Task OpenEmployeesList()
        {
            try
            {
                App.SetFlyoutDetailPage(Connector.CreateInstance<EmployeesListViewModel>((vm, v) =>
                {
                    vm.Initalize();
                }));
            }
            catch (Exception ex)
            {
                _errorHandler.HandleException(ex);
            }
        }

        private async Task OpenVehiclesList()
        {
            try
            {
                App.SetFlyoutDetailPage(Connector.CreateInstance<VehiclesListViewModel>((vm, v) =>
                {
                    vm.Initalize();
                }));
            }
            catch (Exception ex)
            {
                _errorHandler.HandleException(ex);
            }
        }
    }
}
