using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;
using eVehicleStartupLog.Views;

namespace eVehicleStartupLog.ViewModels
{
    public partial class EmployeesListViewModel : BaseListViewModel<UIEmployee>
    {
        private readonly IErrorHandler errorHandler;
        private readonly IEmployeeProvider employeeProvider;
        private readonly IMvvmHelper helper;

        public EmployeesListViewModel(IErrorHandler errorHandler, IEmployeeProvider employeeProvider, IMvvmHelper helper)
        {
            this.errorHandler = errorHandler;
            this.employeeProvider = employeeProvider;
            this.helper = helper;
        }

        internal override async Task AddNew()
        {
            await OpenEditor(null);
        }

        internal override async Task Edit(UIEmployee existingEntity)
        {
            await OpenEditor(existingEntity);
        }

        internal override async Task GetAll()
        {
            try
            {
                var results = await employeeProvider.GetAllEmployees();
                Items = results == null || results.Count == 0 ? null : new System.Collections.ObjectModel.ObservableCollection<UIEmployee>(results);
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }

        private async Task OpenEditor(UIEmployee existingEntity)
        {
            try
            {
                await Navigation.PushAsync(helper.GetInstance<EmployeeEditorViewModel,EmployeeEditorView>((vm, v) =>
                {
                    vm.Initalize(existingEntity);
                }));
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }
    }
}
