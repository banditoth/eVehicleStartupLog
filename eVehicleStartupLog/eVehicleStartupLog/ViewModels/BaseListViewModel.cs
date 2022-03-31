using System.Collections.ObjectModel;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using Xamarin.CommunityToolkit.ObjectModel;

namespace eVehicleStartupLog.ViewModels
{
    public abstract class BaseListViewModel<T> : BaseViewModel
    {
        private AsyncCommand<T> editExistingCommand;
        public AsyncCommand<T> EditExistingCommand => editExistingCommand ??= new AsyncCommand<T>(Edit);

        private AsyncCommand addNewCommand;
        public AsyncCommand AddNewCommand => addNewCommand ??= new AsyncCommand(AddNew);

        private ObservableCollection<T> items;
        public ObservableCollection<T> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        public void Initalize()
        {
            _ = GetAll();
        }

        internal abstract Task GetAll();

        internal abstract Task Edit(T existingEntity);

        internal abstract Task AddNew();
    }
}
