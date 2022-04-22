using System;
using DryIoc;
using eVehicleStartupLog.Interfaces;
using eVehicleStartupLog.ViewModels;
using Xamarin.Forms;

namespace eVehicleStartupLog.Services
{
    public class MvvmHelperService : IMvvmHelper
    {
        public Page GetInstance<TViewModel, TPage>(Action<TViewModel, TPage> initalizer = null) where TViewModel : BaseViewModel where TPage : Page
        {
            TPage pageCreated = App.GetContainer().Resolve<TPage>();
            TViewModel viewModel =  App.GetContainer().Resolve<TViewModel>();
            pageCreated.BindingContext = viewModel;
            viewModel.Navigation = pageCreated.Navigation;

            initalizer?.Invoke(viewModel, pageCreated);

            return pageCreated;
        }
    }
}
