using System;
using Xamarin.Forms;

namespace eVehicleStartupLog.ViewModels
{
    public class BaseViewModel : banditoth.Forms.RecurrenceToolkit.MVVM.BaseViewModel
    {
        public INavigation Navigation { get; set; }
    }
}
