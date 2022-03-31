using System;
using System.Threading.Tasks;
using eVehicleStartupLog.Interfaces;
using Xamarin.Forms;

namespace eVehicleStartupLog.Services
{
    public class DialogHandlerService : IDialogHandler
    {
        public DialogHandlerService()
        {

        }

        public Task<string> DisplayPrompt(string title, string placeholder, string description, string okButton)
        {
            return Application.Current.MainPage.DisplayPromptAsync(title, description, okButton, placeholder: placeholder);
        }
    }
}
