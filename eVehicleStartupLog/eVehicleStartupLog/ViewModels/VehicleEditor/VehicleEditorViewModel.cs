using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;

namespace eVehicleStartupLog.ViewModels
{
    public partial class VehicleEditorViewModel : BaseEditorViewModel<UIVehicle>
    {
        private readonly IErrorHandler errorHandler;
        private readonly IVehicleProvider vehicleProvider;

        public VehicleEditorViewModel(IErrorHandler errorHandler, IVehicleProvider vehicleProvider)
        {
            this.errorHandler = errorHandler;
            this.vehicleProvider = vehicleProvider;
        }

        internal override async Task SaveEntity()
        {
            try
            {
                await vehicleProvider.SaveVehicle(Entity);
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }
    }
}
