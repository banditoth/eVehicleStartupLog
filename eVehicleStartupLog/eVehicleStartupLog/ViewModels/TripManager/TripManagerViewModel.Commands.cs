using System;
using Xamarin.CommunityToolkit.ObjectModel;

namespace eVehicleStartupLog.ViewModels
{
    public partial class TripManagerViewModel
    {
        private AsyncCommand startTripCommand;
        public AsyncCommand StartTripCommand => startTripCommand ??= new AsyncCommand(StartNewTrip);

        private AsyncCommand endTripCommand;
        public AsyncCommand EndTripCommand => endTripCommand ??= new AsyncCommand(EndCurrentTrip);

    }
}
