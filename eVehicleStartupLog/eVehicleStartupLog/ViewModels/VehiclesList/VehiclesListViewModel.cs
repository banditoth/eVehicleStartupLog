using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;
using eVehicleStartupLog.Views;

namespace eVehicleStartupLog.ViewModels
{
    public partial class VehiclesListViewModel : BaseListViewModel<UIVehicle>
    {
        private readonly IErrorHandler errorHandler;
        private readonly IVehicleProvider VehicleProvider;
        private readonly IMvvmHelper mvvmHelper;

        public VehiclesListViewModel(IErrorHandler errorHandler, IVehicleProvider VehicleProvider, IMvvmHelper mvvmHelper)
        {
            this.errorHandler = errorHandler;
            this.VehicleProvider = VehicleProvider;
            this.mvvmHelper = mvvmHelper;
        }

        internal override async Task AddNew()
        {
            await OpenEditor(null);
        }

        internal override async Task Edit(UIVehicle existingEntity)
        {
            await OpenEditor(existingEntity);
        }

        internal override async Task GetAll()
        {
            try
            {
                var results = await VehicleProvider.GetAllVehicles();
                Items = results == null || results.Count == 0 ? null : new System.Collections.ObjectModel.ObservableCollection<UIVehicle>(results);
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

        private async Task OpenEditor(UIVehicle existingEntity)
        {
            try
            {
                await Navigation.PushAsync(mvvmHelper.GetInstance<VehicleEditorViewModel, VehicleEditorView>((vm, v) =>
                {
                    vm.Initalize(existingEntity);
                }));
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

    }
}
