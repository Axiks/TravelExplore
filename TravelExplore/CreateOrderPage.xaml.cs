using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelExplore.Data.Entities;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravelExplore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateOrderPage : Page
    {
        public CreateOrderPage()
        {
            this.InitializeComponent();

            // Set minimum to the current year and maximum to five years from now.
            ArrivalDatePicker.SelectedDate = DateTimeOffset.Now;
            ArrivalDatePicker.MinYear = DateTimeOffset.Now;
            // Set minimum to the current year and maximum to five years from now.
            DepartureDatePicker.SelectedDate = DateTimeOffset.Now;
            DepartureDatePicker.MinYear = DateTimeOffset.Now;
        }

        private void arrivalDatePicker_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            if (ArrivalDatePicker.SelectedDate != null)
            {
                if(DepartureDatePicker.SelectedDate < args.NewDate.Value) {
                    DepartureDatePicker.SelectedDate = args.NewDate.Value;
                }
                //ArrivalDatePicker = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day);
            }
            //ArrivalDatePicker.Text = arrivalDateTime.ToString();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SingletonOrderProvider singletonOrderMonitor = SingletonOrderProvider.Instance;
            var OrderMonitor = singletonOrderMonitor.OrderProvider;
            var order = new OrderEntity();
            order.Id = 454654646;
            order.Updated = DateTime.Now;
            order.Created = DateTime.Now;
            OrderMonitor.AddOrder(order);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }
        
    }
}
