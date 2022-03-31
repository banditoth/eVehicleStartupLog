using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using Xamarin.CommunityToolkit.ObjectModel;

namespace eVehicleStartupLog.ViewModels
{
    public abstract class BaseEditorViewModel<T> : BaseViewModel
    {
        private AsyncCommand saveCommand;
        public AsyncCommand SaveCommand => saveCommand ??= new AsyncCommand(SaveEntity);

        private T entity;
        public T Entity
        {
            get => entity;
            set => SetProperty(ref entity, value);
        }


        public BaseEditorViewModel()
        {
        }

        public virtual void Initalize(T existingEntity)
        {
            Entity = existingEntity ?? Activator.CreateInstance<T>();
        }

        internal abstract Task SaveEntity();

    }
}
