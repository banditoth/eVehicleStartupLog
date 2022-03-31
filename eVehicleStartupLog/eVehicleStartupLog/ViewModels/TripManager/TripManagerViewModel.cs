using System;
using System.Linq;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using eVehicleStartupLog.Extensions;
using eVehicleStartupLog.Interfaces;
using Xamarin.Essentials;

namespace eVehicleStartupLog.ViewModels
{
    public partial class TripManagerViewModel : BaseViewModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly ITripProvider tripProvider;
        private readonly IEmployeeProvider employeeProvider;
        private readonly IPlateProvider plateProvider;
        private readonly IVehicleProvider vehicleProvider;
        private readonly IDialogHandler dialogHandler;

        public TripManagerViewModel(IErrorHandler errorHandler, ITripProvider tripProvider, IEmployeeProvider employeeProvider, IPlateProvider plateProvider,
            IVehicleProvider vehicleProvider ,IDialogHandler dialogHandler)
        {
            this.errorHandler = errorHandler;
            this.tripProvider = tripProvider;
            this.employeeProvider = employeeProvider;
            this.plateProvider = plateProvider;
            this.vehicleProvider = vehicleProvider;
            this.dialogHandler = dialogHandler;
        }

        public void Initalize()
        {
            _ = GetOnGoingTrip();
            _ = GetAllEmployees();
            _ = GetAllPlates();
            _ = GetAllVehicles();
        }

        private async Task GetOnGoingTrip()
        {
            try
            {
                // TODO: Make procedure to only query the last unclosed from the DB
                OnGoingTrip = (await tripProvider.GetAllTrips()).Where(z => z.StopDateTime == null).FirstOrDefault();
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

        private async Task StartNewTrip()
        {
            try
            {
                OnGoingTrip = new Entities.UITrip();
                OnGoingTrip.StartDateTime = DateTime.UtcNow;
                OnGoingTrip.Employee = selectedEmployee;
                OnGoingTrip.Vehicle = selectedVehicle;
                OnGoingTrip.Plate = selectedPlate;

                Location currentLocation = await Geolocation.GetLocationAsync();

                if (currentLocation == null)
                {
                    OnGoingTrip.StartAddress = await PromptAddress();
                    return;
                }

                OnGoingTrip.StartLatitude = currentLocation.Latitude;
                OnGoingTrip.StartLongitude = currentLocation.Longitude;

                System.Collections.Generic.IEnumerable<Placemark> geocodedAddresses = await Geocoding.GetPlacemarksAsync(currentLocation);

                if (geocodedAddresses == null || geocodedAddresses.FirstOrDefault() == null)
                {
                    OnGoingTrip.StartAddress = await PromptAddress();
                    return;
                }

                OnGoingTrip.StartAddress = geocodedAddresses.First().GetDisplayAddress();
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
            finally
            {
                _ = SaveCurrentTrip();
            }
        }

        private async Task EndCurrentTrip()
        {
            if (OnGoingTrip == null)
            {
                return;
            }

            try
            {
                Location currentLocation = await Geolocation.GetLocationAsync();
                OnGoingTrip.StopDateTime = DateTime.UtcNow;

                if (currentLocation == null)
                {
                    OnGoingTrip.StopAddress = await PromptAddress();
                    return;
                }

                OnGoingTrip.StopLatitude = currentLocation.Latitude;
                OnGoingTrip.StopLongitude = currentLocation.Longitude;

                System.Collections.Generic.IEnumerable<Placemark> geocodedAddresses = await Geocoding.GetPlacemarksAsync(currentLocation);

                if (geocodedAddresses == null || geocodedAddresses.FirstOrDefault() == null)
                {
                    OnGoingTrip.StopAddress = await PromptAddress();
                    return;
                }

                OnGoingTrip.StopAddress = geocodedAddresses.First().GetDisplayAddress();

            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
            finally
            {
                _ = SaveCurrentTrip();
            }
        }

        private async Task SaveCurrentTrip()
        {
            try
            {
                await tripProvider.SaveTrip(OnGoingTrip);

                if(OnGoingTrip.StopDateTime != null)
                {
                    OnGoingTrip = null;
                }
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

        private async Task<string> PromptAddress()
        {
            string result = null;

            do
            {
                string stopAddress = await dialogHandler.DisplayPrompt("Add meg a címet manuálisan", "pl.: 7400 Kaposvár, Fő utca 44.", "Nem sikerült lekrédezni a helyzetedet, ezért manuálisan kell begépelned a címet, ahol állsz.", "Rendben");
            }
            while (string.IsNullOrWhiteSpace(result));

            return result;
        }

        private async Task GetAllEmployees()
        {
            try
            {
                System.Collections.Generic.List<Entities.UIEmployee> results = await employeeProvider.GetAllEmployees();
                Employees = results == null || results.Count == 0 ? null : new System.Collections.ObjectModel.ObservableCollection<Entities.UIEmployee>(results);
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

        private async Task GetAllPlates()
        {
            try
            {
                System.Collections.Generic.List<Entities.UIPlate> results = await plateProvider.GetAllPlates();
                Plates = results == null || results.Count == 0 ? null : new System.Collections.ObjectModel.ObservableCollection<Entities.UIPlate>(results);
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

        private async Task GetAllVehicles()
        {
            try
            {
                System.Collections.Generic.List<Entities.UIVehicle> results = await vehicleProvider.GetAllVehicles();
                Vehicles = results == null || results.Count == 0 ? null : new System.Collections.ObjectModel.ObservableCollection<Entities.UIVehicle>(results);
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

    }
}
