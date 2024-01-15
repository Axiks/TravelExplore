using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using TravelExplore.Data;
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
        private ObservableCollection<MyDataClass> MyData = new ObservableCollection<MyDataClass>();
        private readonly ApplicationDbContext _dbContext;

        public MainPage()
        {
            this.InitializeComponent();

            string connectionString = "Data Source=NEKO\\SQLEXPRESS; Initial Catalog=travel-explore-db; User Id=neko; Password=neko";
            _dbContext = new ApplicationDbContext(connectionString);
            _dbContext.Database.EnsureCreated();

            MyData.Add(new MyDataClass("Miku", "Katowice", DateTime.Now, DateTime.Now.AddDays(3)));
            MyData.Add(new MyDataClass("Nana", "Red sea", DateTime.Now, DateTime.Now.AddDays(7)));
            MyData.Add(new MyDataClass("Axiks", "California", DateTime.Now, DateTime.Now.AddDays(14)));
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateOrderPage));
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
    }

    public class MyDataClass
    {
        public String ClientName { get; set; }
        public String AddressOfDeparture { get; set; }
        public String DateOfDeparture { get; set; }
        public String DateOfArrival { get; set; }

        public MyDataClass(String ClientName, String AddressOfDeparture, DateTime DateOfDeparture, DateTime DateOfArrival)
        {
            this.ClientName = ClientName;
            this.AddressOfDeparture = AddressOfDeparture;
            this.DateOfDeparture = DateOfDeparture.ToString("dd/MM/yyyy");
            this.DateOfArrival = DateOfArrival.ToString("dd/MM/yyyy");
        }
    }
}
