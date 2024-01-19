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
using TravelExplore.Observers;
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
    public sealed partial class MainPage : Page, IObserver<List<OrderEntity>>
    {
        private readonly ApplicationDbContext _dbContext;

        private ObservableCollection<MyDataClass> MyData;

        AuthorsCollection collection;

        public MainPage()
        {
            this.InitializeComponent();

            string connectionString = "Data Source=NEKO\\SQLEXPRESS; Initial Catalog=travel-explore-db; User Id=neko; Password=neko";
            _dbContext = new ApplicationDbContext(connectionString);

            MyData = new ObservableCollection<MyDataClass>();
            _dbContext.Database.EnsureCreated();

            /*MyData.Add(new MyDataClass("Miku", "Katowice", DateTime.Now, DateTime.Now.AddDays(3)));
            MyData.Add(new MyDataClass("Nana", "Red sea", DateTime.Now, DateTime.Now.AddDays(7)));
            MyData.Add(new MyDataClass("Axiks", "California", DateTime.Now, DateTime.Now.AddDays(14)));*/

/*            ListView OffersLV = new ListView();

            collection = new AuthorsCollection();
            OffersLV.ItemsSource = collection;

            

            OfferListPanel.Children.Add(OffersLV);*/

            SingletonOrderProvider singletonOrderMonitor = SingletonOrderProvider.Instance;
            OrderProvider OrderProvider = singletonOrderMonitor.OrderProvider;

            OrderProvider.Subscribe(this);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (RestaurantParams)e.Parameter;

            ListView OffersLV = new ListView();

            //collection = new AuthorsCollection();
            MyData = parameters.MyData;
            OffersLV.ItemsSource = MyData;

            //OfferListPanel.Children.Add(OffersLV);

            // parameters.Name
            // parameters.Text
            // ...
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateOrderPage));
        }
        private void myTestButton_Click(object sender, RoutedEventArgs e)
        {
            //collection.Add(collection[0]);
            MyData.Add(new MyDataClass("Nana", "Red sea", DateTime.Now, DateTime.Now.AddDays(7)));
        }


        private void myDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //myDeleteButton.Content = "Clicked :D";
        }

        private void dg_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Cancel)
                return;

            string editedColumnProperty = ((Binding)((DataGridBoundColumn)e.Column).Binding).Path.Path;
            object newValue = null;
            if (e.EditingElement is TextBox editingTextBox)
            {
                newValue = editingTextBox.Text;
            }
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(List<OrderEntity> values)
        {
            var aaaaaaa = values;
            //collection.Add(collection[0]);
            MyData.Add(new MyDataClass("Nana", "Red sea", DateTime.Now, DateTime.Now.AddDays(7)));
        }
    }

    public class AuthorsCollection : ObservableCollection<Person>
    {
        public AuthorsCollection()
        {
            Add(new Person
            {
                FirstName = "Bejaoui",
                LastName = "Bechir",
                PseudoName = "Yougerthen"
            });
            Add(new Person
            {
                FirstName = "Bejaoui",
                LastName = "Bechir",
                PseudoName = "Yougerthen"
            });
            Add(new Person
            {
                FirstName = "Bejaoui",
                LastName = "Bechir",
                PseudoName = "Yougerthen"
            });
            Add(new Person
            {
                FirstName = "Bejaoui",
                LastName = "Bechir",
                PseudoName = "Yougerthen"
            });
        }
    }

    public class Person
    {
        public Person() { }
        public Person(string FirstName, string LastName, string PseudoName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PseudoName = PseudoName;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string PseudoName
        {
            get;
            set;
        }
        public override string ToString()
        {
            return string.Format("First name: {0}, Last name: {1}, Pseudo name: {2}", FirstName, LastName, PseudoName);
        }
    }

    public class MyDataClass : INotifyPropertyChanged
    {
        private String _clientName;
        private String _addressOfDeparture;
        private String _dateOfDeparture;
        private String _DateOfArrival;

        public String ClientName
        {
            get { return this._clientName; }
            set
            {
                this._clientName = value;
                this.RaisePropertyChanged("ClientName");
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
            get { return this._DateOfArrival; }
            set
            {
                this._DateOfArrival = value;
                this.RaisePropertyChanged("DateOfArrival");
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
