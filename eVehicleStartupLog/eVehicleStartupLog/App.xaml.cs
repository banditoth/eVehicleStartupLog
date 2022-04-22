using System;
using AutoMapper;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using DryIoc;
using eVehicleStartupLog.Database;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;
using eVehicleStartupLog.Models;
using eVehicleStartupLog.Services;
using eVehicleStartupLog.ViewModels;
using eVehicleStartupLog.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eVehicleStartupLog
{
    public partial class App : Application
    {
        private static readonly Container _dependencyContainer = new Container();

        public App()
        {
            InitializeComponent();
            RegisterApplicationComponents();

            MainPage = GetContainer().Resolve<IMvvmHelper>().GetInstance<MainFlyoutViewModel, MainFlyoutPage>((vm, v) =>
            {
                vm.Initalize();
            });
        }

        public static void SetFlyoutDetailPage(Page pageToSet)
        {
            if(Current.MainPage is FlyoutPage flyout)
            {
                flyout.Detail = new NavigationPage(pageToSet);
                flyout.IsPresented = false;
            }
        }

        public static Container GetContainer()
        {
            return _dependencyContainer;
        }

        private void RegisterApplicationComponents()
        {
            _dependencyContainer.UseInstance<IMapper>(new Mapper(new MapperConfiguration(z=>
            {
                z.CreateMap<UIPlate, Plate>();
                z.CreateMap<UIEmployee, Employee>();
                z.CreateMap<UIVehicle, Vehicle>();
                z.CreateMap<UITrip, Trip>();
            })));

            // Services
            _dependencyContainer.Register<IDialogHandler, DialogHandlerService>();
            _dependencyContainer.Register<IErrorHandler, ErrorHandlerService>();
            _dependencyContainer.Register<IEmployeeProvider, EmployeeProviderService>();
            _dependencyContainer.Register<IEmployeeRepository, DatabaseContext>();
            _dependencyContainer.Register<IPlateProvider, PlateProviderService>();
            _dependencyContainer.Register<IPlateRepository, DatabaseContext>();
            _dependencyContainer.Register<ITripProvider, TripProviderService>();
            _dependencyContainer.Register<ITripRepository, DatabaseContext>();
            _dependencyContainer.Register<IVehicleProvider, VehicleProviderService>();
            _dependencyContainer.Register<IVehicleRepository, DatabaseContext>();
            _dependencyContainer.Register<IMvvmHelper, MvvmHelperService>();
            // Views
            _dependencyContainer.Register<EmployeeEditorView>();
            _dependencyContainer.Register<EmployeeListView>();
            _dependencyContainer.Register<MainFlyoutPage>();
            _dependencyContainer.Register<PlateEditorView>();
            _dependencyContainer.Register<PlateListView>();
            _dependencyContainer.Register<PreviousTripListView>();
            _dependencyContainer.Register<TripManagerView>();
            _dependencyContainer.Register<VehicleEditorView>();
            _dependencyContainer.Register<VehicleListView>();
            // ViewModels
            _dependencyContainer.Register<EmployeeEditorViewModel>();
            _dependencyContainer.Register<EmployeesListViewModel>();
            _dependencyContainer.Register<MainFlyoutViewModel>();
            _dependencyContainer.Register<PlateEditorViewModel>();
            _dependencyContainer.Register<PlatesListViewModel>();
            _dependencyContainer.Register<PreviousTripListViewModel>();
            _dependencyContainer.Register<TripManagerViewModel>();
            _dependencyContainer.Register<VehicleEditorViewModel>();
            _dependencyContainer.Register<VehiclesListViewModel>();

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

