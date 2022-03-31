using System;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using DryIoc;
using eVehicleStartupLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eVehicleStartupLog
{
    public partial class App : Application
    {
        private static readonly Container _dependencyContainer = new Container();

        public App ()
        {
            InitializeComponent();
            RegisterApplicationComponents();

            MainPage = Connector.CreateInstance<MainFlyoutViewModel>((vm, v) =>
            {
                vm.Initalize();
            });
        }

        public static void SetFlyoutDetailPage(Page pageToSet)
        {
            if(Current.MainPage is FlyoutPage flyout)
            {
                flyout.Detail = pageToSet;
                flyout.IsPresented = false;
            }
        }

        public static Container GetContainer()
        {
            return _dependencyContainer;
        }

        private void RegisterApplicationComponents()
        {
            
        }

        protected override void OnStart ()
        {

        }

        protected override void OnSleep ()
        {

        }

        protected override void OnResume ()
        {

        }
    }
}

