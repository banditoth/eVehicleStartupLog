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
            _dependencyContainer.UseInstance<IMapper>(new Mapper(new MapperConfiguration(z=>
            {
                z.CreateMap<UIPlate, Plate>();
                z.CreateMap<UIEmployee, Employee>();
                z.CreateMap<UIVehicle, Vehicle>();
                z.CreateMap<UITrip, Trip>();
            })));
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

            Connector.Register(typeof(EmployeeEditorViewModel), typeof(EmployeeEditorView));
            Connector.Register(typeof(EmployeesListViewModel), typeof(EmployeeListView));
            Connector.Register(typeof(MainFlyoutViewModel), typeof(MainFlyoutPage));
            Connector.Register(typeof(PlateEditorViewModel), typeof(PlateEditorView));
            Connector.Register(typeof(PlatesListViewModel), typeof(PlateListView));
            Connector.Register(typeof(TripManagerViewModel), typeof(TripManagerView));
            Connector.Register(typeof(VehicleEditorViewModel), typeof(VehicleEditorView));
            Connector.Register(typeof(VehiclesListViewModel), typeof(VehicleListView));
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

