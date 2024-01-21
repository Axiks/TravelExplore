using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelExplore.Data.Entities;
using TravelExplore.Models;
using TravelExplore.Providers;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravelExplore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateOfferPage : Page
    {
        public CreateOfferViewModel CreateOfferDTO;

        public CreateOfferPage()
        {
            this.InitializeComponent();

            CreateOfferDTO = new CreateOfferViewModel();

            CreateOfferDTO.DateOfArrival = DateTime.Now;
            ArrivalDatePicker.MinYear = DateTimeOffset.Now;

            CreateOfferDTO.DateOfDeparture = DateTime.Now;
            DepartureDatePicker.MinYear = DateTimeOffset.Now;
        }

        private void CurrentWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 880)
                VisualStateManager.GoToState(this, "DefaultState", false);
            else
                VisualStateManager.GoToState(this, "SmallState", false);
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

        private static Random random = new Random();

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void RandomDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (CreateOfferDTO.ClientName == null) CreateOfferDTO.ClientName = RandomString(10);
            if (CreateOfferDTO.ClientSurname == null) CreateOfferDTO.ClientSurname = RandomString(10);
            if (CreateOfferDTO.ClientEmail == null) CreateOfferDTO.ClientEmail = RandomString(16);
            if (CreateOfferDTO.ClientAddress == null) CreateOfferDTO.ClientAddress = RandomString(36);
            if (CreateOfferDTO.ClientTelephoneNumber == null) CreateOfferDTO.ClientTelephoneNumber = random.Next(1000000000).ToString();
            if (CreateOfferDTO.AddressOfDeparture == null) CreateOfferDTO.AddressOfDeparture = RandomString(36);

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            FillFieldsInfoBar.IsOpen = false;
            // Validation
            if (CreateOfferDTO.ClientName == null) FillFieldsInfoBar.IsOpen = true;
            if(CreateOfferDTO.ClientSurname == null) FillFieldsInfoBar.IsOpen = true;
            if(CreateOfferDTO.ClientEmail == null) FillFieldsInfoBar.IsOpen = true;
            if(CreateOfferDTO.ClientAddress == null) FillFieldsInfoBar.IsOpen = true;
            if(CreateOfferDTO.AddressOfDeparture == null) FillFieldsInfoBar.IsOpen = true;

            if (FillFieldsInfoBar.IsOpen == true) return;

            SingletonOfferProvider singletonOrderMonitor = SingletonOfferProvider.Instance;
            var OrderMonitor = singletonOrderMonitor.OfferProvider;
            OrderMonitor.AddOffer(CreateOfferDTO);

            App.TryGoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }
        
    }
}
