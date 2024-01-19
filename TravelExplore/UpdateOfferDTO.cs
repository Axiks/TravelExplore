using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExplore
{
    public class UpdateOfferDTO : INotifyPropertyChanged
    {
        private String _clientName;
        private String _clientSurname;
        private int _clientTelephoneNumber;
        private String _clientEmail;
        private String _clientAddress;

        private int _orderId;
        private String _addressOfDeparture;
        private DateTime _dateOfDeparture;
        private DateTime _dateOfArrival;

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

        public int ClientTelephoneNumber
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

        public DateTime DateOfDeparture
        {
            get { return this._dateOfDeparture; }
            set
            {
                this._dateOfDeparture = value;
                this.RaisePropertyChanged("DateOfDeparture");
            }
        }

        public DateTime DateOfArrival
        {
            get { return this._dateOfArrival; }
            set
            {
                this._dateOfArrival = value;
                this.RaisePropertyChanged("DateOfArrival");
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
