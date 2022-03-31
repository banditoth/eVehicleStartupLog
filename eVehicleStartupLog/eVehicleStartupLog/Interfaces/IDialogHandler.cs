using System;
using System.Threading.Tasks;

namespace eVehicleStartupLog.Interfaces
{
    public interface IDialogHandler
    {
        Task<string> DisplayPrompt(string title, string placeholder, string description, string okButton);
    }
}
