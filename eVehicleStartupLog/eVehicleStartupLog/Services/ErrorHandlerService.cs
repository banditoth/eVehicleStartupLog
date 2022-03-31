using System;
using eVehicleStartupLog.Interfaces;
using Xamarin.Forms;

namespace eVehicleStartupLog.Services
{
    public class ErrorHandlerService : IErrorHandler
    {
        public ErrorHandlerService()
        {

        }

        public void HandleException(Exception ex, string additionalMessage = null, bool silent = false)
        {
            try
            {
                Console.WriteLine(ex.ToString());

                if (silent == false)
                {
                    Application.Current.MainPage.DisplayAlert("Hiba történt", additionalMessage ?? "Kérjük próbálja újra végrehajtani a műveletet", "Rendben");
                }
            }
            catch (Exception ex2)
            {
                Console.WriteLine("Could not display error message, exception occured.: " + ex2.ToString());
            }
        }
    }
}
