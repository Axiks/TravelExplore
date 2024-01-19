using System;
using System.ComponentModel;
using TravelExplore.Data.Entities;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravelExplore
{
    public class OfferViewModel : INotifyPropertyChanged
    {
        private String _clientName;
        private String _clientSurname;
        private String _clientTelephoneNumber;
        private String _clientEmail;
        private String _clientAddress;

        private int _orderId;
        private String _addressOfDeparture;
        private String _dateOfDeparture;
        private String _dateOfArrival;

        private String _dateOfCreatedOffer;
        private String _dateOfUpdatesOffer;

        public String ClientName
        {
            get { return this._clientName; }
            set
            {
                this._clientName = value;
                this.RaisePropertyChanged("ClientName");
            }
        }

        public String ClientSurname
        {
            get { return this._clientSurname; }
            set
            {
                this._clientSurname = value;
                this.RaisePropertyChanged("ClientSurname");
            }
        }

        public String ClientTelephoneNumber
        {
            get { return this._clientTelephoneNumber; }
            set
            {
                this._clientTelephoneNumber = value;
                this.RaisePropertyChanged("ClientTelephoneNumber");
            }
        }

        public String ClientEmail
        {
            get { return this._clientEmail; }
            set
            {
                this._clientEmail = value;
                this.RaisePropertyChanged("ClientEmail");
            }
        }
        
        public String ClientAddress
        {
            get { return this._clientAddress; }
            set
            {
                this._clientAddress = value;
                this.RaisePropertyChanged("ClientAddress");
            }
        }

        public int OrderId
        {
            get { return this._orderId; }
            set
            {
                this._orderId = value;
                this.RaisePropertyChanged("OrderId");
            }
        }

        public String AddressOfDeparture
        {
            get { return this._addressOfDeparture; }
            set
            {
                this._addressOfDeparture = value;
                this.RaisePropertyChanged("AddressOfDeparture");
            }
        }

        public String DateOfDeparture
        {
            get { return this._dateOfDeparture; }
            set
            {
                this._dateOfDeparture = value;
                this.RaisePropertyChanged("DateOfDeparture");
            }
        }

        public String DateOfArrival
        {
            get { return this._dateOfArrival; }
            set
            {
                this._dateOfArrival = value;
                this.RaisePropertyChanged("DateOfArrival");
            }
        }

        public String DateOfCreatedOffer
        {
            get { return this._dateOfCreatedOffer; }
            set
            {
                this._dateOfCreatedOffer = value;
                this.RaisePropertyChanged("DateOfCreatedOffer");
            }
        }

        public String DateOfUpdatesOffer
        {
            get { return this._dateOfUpdatesOffer; }
            set
            {
                this._dateOfUpdatesOffer = value;
                this.RaisePropertyChanged("DateOfUpdatesOffer");
            }
        }

        /*        public OfferViewModel(String ClientName, String AddressOfDeparture, DateTime DateOfDeparture, DateTime DateOfArrival)
                {
                    this.ClientName = ClientName;
                    this.AddressOfDeparture = AddressOfDeparture;
                    this.DateOfDeparture = DateOfDeparture.ToString("dd/MM/yyyy");
                    this.DateOfArrival = DateOfArrival.ToString("dd/MM/yyyy");
                }*/

        public OfferViewModel(CustomerEntity costumer, OrderEntity order)
        {
            this.ClientName = costumer.Name;
            this.ClientSurname = costumer.Surname;
            this.ClientTelephoneNumber = costumer.Telephonenumber.ToString();
            this.ClientEmail = costumer.Email;
            this.ClientAddress = costumer.Address;


            this.OrderId = order.Id;
            this.AddressOfDeparture = order.AddressOfDeparture;
            this.DateOfDeparture = order.DateOfDeparture.ToString("dd/MM/yyyy");
            this.DateOfArrival = order.DateOfArrival.ToString("dd/MM/yyyy");

            this.DateOfCreatedOffer = order.Created.ToString("dd/MM/yyyy");
            this.DateOfUpdatesOffer = order.Updated.ToString("dd/MM/yyyy");
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
