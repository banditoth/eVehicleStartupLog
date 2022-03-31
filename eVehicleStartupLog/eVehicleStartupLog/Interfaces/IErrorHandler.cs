using System;
namespace eVehicleStartupLog.Interfaces
{
    public interface IErrorHandler
    {
        public void HandleException(Exception ex, string additionalMessage = null, bool silent = false);
    }
}
