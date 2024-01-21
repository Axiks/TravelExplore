using System.ComponentModel;
using TravelExplore.Data.Entities;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravelExplore.Models
{
    public class OfferViewModel : INotifyPropertyChanged
    {
        private string _clientName;
        private string _clientSurname;
        private string _clientTelephoneNumber;
        private string _clientEmail;
        private string _clientAddress;

        private int _orderId;
        private string _addressOfDeparture;
        private string _dateOfDeparture;
        private string _dateOfArrival;

        private string _dateOfCreatedOffer;
        private string _dateOfUpdatesOffer;

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

        public int OrderId
        {
            get { return _orderId; }
            set
            {
                _orderId = value;
                RaisePropertyChanged("OrderId");
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

        public string DateOfDeparture
        {
            get { return _dateOfDeparture; }
            set
            {
                _dateOfDeparture = value;
                RaisePropertyChanged("DateOfDeparture");
            }
        }

        public string DateOfArrival
        {
            get { return _dateOfArrival; }
            set
            {
                _dateOfArrival = value;
                RaisePropertyChanged("DateOfArrival");
            }
        }

        public string DateOfCreatedOffer
        {
            get { return _dateOfCreatedOffer; }
            set
            {
                _dateOfCreatedOffer = value;
                RaisePropertyChanged("DateOfCreatedOffer");
            }
        }

        public string DateOfUpdatesOffer
        {
            get { return _dateOfUpdatesOffer; }
            set
            {
                _dateOfUpdatesOffer = value;
                RaisePropertyChanged("DateOfUpdatesOffer");
            }
        }

        public OfferViewModel(CustomerEntity costumer, OrderEntity order)
        {
            ClientName = costumer.Name;
            ClientSurname = costumer.Surname;
            ClientTelephoneNumber = costumer.Telephonenumber.ToString();
            ClientEmail = costumer.Email;
            ClientAddress = costumer.Address;


            OrderId = order.Id;
            AddressOfDeparture = order.AddressOfDeparture;
            DateOfDeparture = order.DateOfDeparture.ToString("dd.MM.yyyy");
            DateOfArrival = order.DateOfArrival.ToString("dd.MM.yyyy");

            DateOfCreatedOffer = order.Created.ToString("dd.MM.yyyy HH:mm");
            DateOfUpdatesOffer = order.Updated.ToString("dd.MM.yyyy HH:mm");
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
