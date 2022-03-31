using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;

namespace eVehicleStartupLog.ViewModels
{
    public partial class PreviousTripListViewModel : BaseListViewModel<UITrip>
    {
        private readonly IErrorHandler errorHandler;
        private readonly ITripProvider tripProvider;

        public PreviousTripListViewModel(IErrorHandler errorHandler, ITripProvider tripProvider)
        {
            this.errorHandler = errorHandler;
            this.tripProvider = tripProvider;
        }

        internal override Task AddNew()
        {
            throw new NotSupportedException();
        }

        internal override Task Edit(UITrip existingEntity)
        {
            throw new NotSupportedException();
        }

        internal override async Task GetAll()
        {
            try
            {
                var results = await tripProvider.GetAllTrips();
                Items = results == null || results.Count == 0 ? null : new System.Collections.ObjectModel.ObservableCollection<UITrip>(results);
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }
    }
}
