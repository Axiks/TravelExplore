using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using TravelExplore.Data;
using TravelExplore.Data.Entities;
using TravelExplore.Providers;
using Windows.ApplicationModel.Contacts;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravelExplore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<MyDataClass> MyData;

        private MainPageParams _mainPageParams;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (MainPageParams)e.Parameter;

            ListView OffersLV = new ListView();

            //collection = new AuthorsCollection();
            MyData = parameters.MyData;
            OffersLV.ItemsSource = MyData;

            _mainPageParams = parameters;

            if (_mainPageParams != null && _mainPageParams.SelectedOrderIndex >= 0)
            {
                orderListView.SelectedIndex = _mainPageParams.SelectedOrderIndex;
                return;
            }
            OfferDataFrame.Navigate(typeof(EmptyOfferInfoPage));
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateOrderPage));
        }
        
        private void orderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainPageParams.SelectedOrderIndex = orderListView.SelectedIndex;

            if (_mainPageParams.SelectedOrderIndex >= 0) {
                OfferDataFrame.Navigate(typeof(OfferInfoPage), MyData[_mainPageParams.SelectedOrderIndex]);
                return;
            };
            OfferDataFrame.Navigate(typeof(EmptyOfferInfoPage));
        }

        private void myTestButton_Click(object sender, RoutedEventArgs e)
        {
            //collection.Add(collection[0]);
            /*MyData.Add(new MyDataClass("Nana", "Red sea", DateTime.Now, DateTime.Now.AddDays(7)));

            OfferDataFrame.Navigate(typeof(OfferInfoPage), MyData.Last());*/

            SingletonOrderProvider singletonOrderMonitor = SingletonOrderProvider.Instance;
            var OrderMonitor = singletonOrderMonitor.OrderProvider;
            var order = new OrderEntity();
            order.Id = 111111;
            order.Updated = DateTime.Now;
            order.Created = DateTime.Now;
            OrderMonitor.AddOrder(order);
        }
    }

    public class MyDataClass : INotifyPropertyChanged
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

        public MyDataClass(String ClientName, String AddressOfDeparture, DateTime DateOfDeparture, DateTime DateOfArrival)
        {
            this.ClientName = ClientName;
            this.AddressOfDeparture = AddressOfDeparture;
            this.DateOfDeparture = DateOfDeparture.ToString("dd/MM/yyyy");
            this.DateOfArrival = DateOfArrival.ToString("dd/MM/yyyy");
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
