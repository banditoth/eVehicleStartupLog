using System;
using eVehicleStartupLog.ViewModels;
using Xamarin.Forms;

namespace eVehicleStartupLog.Interfaces
{
    public interface IMvvmHelper
    {
        Page GetInstance<TViewModel, TPage>(Action<TViewModel, TPage> initalizer = null) where TViewModel : BaseViewModel where TPage : Page;
    }
}
