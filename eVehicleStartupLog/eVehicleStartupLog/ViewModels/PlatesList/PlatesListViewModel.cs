using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;

namespace eVehicleStartupLog.ViewModels
{
    public partial class PlatesListViewModel : BaseListViewModel<UIPlate>
    {
        private readonly IErrorHandler errorHandler;
        private readonly IPlateProvider plateProvider;

        public PlatesListViewModel(IErrorHandler errorHandler, IPlateProvider plateProvider)
        {
            this.errorHandler = errorHandler;
            this.plateProvider = plateProvider;
        }

        internal override async Task AddNew()
        {
            await OpenEditor(null);
        }

        internal override async Task Edit(UIPlate existingEntity)
        {
            await OpenEditor(existingEntity);
        }

        internal override async Task GetAll()
        {
            try
            {
                var results = await plateProvider.GetAllPlates();
                Items = results == null || results.Count == 0 ? null : new System.Collections.ObjectModel.ObservableCollection<UIPlate>(results);
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

        private async Task OpenEditor(UIPlate existingEntity)
        {
            try
            {
                await Navigator.Instance.Navigation.PushAsync(Connector.CreateInstance<PlateEditorViewModel>((vm, v) =>
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
