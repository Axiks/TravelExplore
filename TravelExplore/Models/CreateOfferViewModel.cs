using System;
using System.ComponentModel;

namespace TravelExplore.Models
{
    public class CreateOfferViewModel : INotifyPropertyChanged
    {
        private string _clientName;
        private string _clientSurname;
        private string _clientTelephoneNumber;
        private string _clientEmail;
        private string _clientAddress;

        private string _addressOfDeparture;
        private DateTime _dateOfDeparture;
        private DateTime _dateOfArrival;

        public string ClientName
        {
            get { return _clientName; }
            set
            {
                _clientName = value;
                RaisePropertyChanged("ClientName");
            }
        }

        public string ClientSurname
        {
            get { return _clientSurname; }
            set
            {
                _clientSurname = value;
                RaisePropertyChanged("ClientSurname");
            }
        }

        public string ClientTelephoneNumber
        {
            get { return _clientTelephoneNumber; }
            set
            {
                _clientTelephoneNumber = value;
                RaisePropertyChanged("ClientTelephoneNumber");
            }
        }

        public string ClientEmail
        {
            get { return _clientEmail; }
            set
            {
                _clientEmail = value;
                RaisePropertyChanged("ClientEmail");
            }
        }

        public string ClientAddress
        {
            get { return _clientAddress; }
            set
            {
                _clientAddress = value;
                RaisePropertyChanged("ClientAddress");
            }
        }

        public string AddressOfDeparture
        {
            get { return _addressOfDeparture; }
            set
            {
                _addressOfDeparture = value;
                RaisePropertyChanged("AddressOfDeparture");
            }
        }

        public DateTime DateOfDeparture
        {
            get { return _dateOfDeparture; }
            set
            {
                _dateOfDeparture = value;
                RaisePropertyChanged("DateOfDeparture");
            }
        }

        public DateTime DateOfArrival
        {
            get { return _dateOfArrival; }
            set
            {
                _dateOfArrival = value;
                RaisePropertyChanged("DateOfArrival");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
