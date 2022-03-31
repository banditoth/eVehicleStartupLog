using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;

namespace eVehicleStartupLog.ViewModels
{
    public partial class PlateEditorViewModel : BaseEditorViewModel<UIPlate>
    {
        private readonly IErrorHandler errorHandler;
        private readonly IPlateProvider plateProvider;

        public PlateEditorViewModel(IErrorHandler errorHandler, IPlateProvider plateProvider)
        {
            this.errorHandler = errorHandler;
            this.plateProvider = plateProvider;
        }

        internal override async Task SaveEntity()
        {
            try
            {
                await plateProvider.SavePlate(Entity);
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

    }
}
