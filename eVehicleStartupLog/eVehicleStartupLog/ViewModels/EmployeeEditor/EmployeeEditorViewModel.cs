using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using eVehicleStartupLog.Entities;
using eVehicleStartupLog.Interfaces;

namespace eVehicleStartupLog.ViewModels
{
    public partial class EmployeeEditorViewModel : BaseEditorViewModel<UIEmployee>
    {
        private readonly IErrorHandler errorHandler;
        private readonly IEmployeeProvider employeeProvider;

        public EmployeeEditorViewModel(IErrorHandler errorHandler, IEmployeeProvider employeeProvider)
        {
            this.errorHandler = errorHandler;
            this.employeeProvider = employeeProvider;
        }

        internal override async Task SaveEntity()
        {
            try
            {
                await employeeProvider.SaveEmployee(Entity);
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
            }
        }
    }
}
