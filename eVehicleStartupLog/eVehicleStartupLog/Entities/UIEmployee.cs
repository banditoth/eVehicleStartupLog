using System;
using banditoth.Forms.RecurrenceToolkit.MVVM;

namespace eVehicleStartupLog.Entities
{
    public class UIEmployee : BindableObject
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string driversLicenseId;
        private string personalId;
        private DateTime? employmentContractStartDate;

        public Guid Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string FullName
        {
            get
            {
                string result = firstName + " " + lastName;
                return string.IsNullOrWhiteSpace(result) ? null : result;
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                SetProperty(ref firstName, value);
                NotifyPropertyChanged(nameof(FullName));
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                SetProperty(ref lastName, value);
                NotifyPropertyChanged(nameof(FullName));
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }

        public string DriversLicenseId
        {
            get => driversLicenseId;
            set => SetProperty(ref driversLicenseId, value);
        }

        public string PersonalId
        {
            get => personalId;
            set => SetProperty(ref personalId, value);
        }

        public DateTime? EmploymentContractStartDate
        {
            get => employmentContractStartDate;
            set => SetProperty(ref employmentContractStartDate, value);
        }
    }
}
