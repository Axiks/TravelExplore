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
    public sealed partial class UpdateOfferPage : Page
    {
        public UpdateOfferViewModel CreateOfferDTO;
        private OfferProvider _offerProvider;

        public UpdateOfferPage()
        {
            this.InitializeComponent();

            CreateOfferDTO = new UpdateOfferViewModel();
            CreateOfferDTO.DateOfArrival = DateTime.Now;
            ArrivalDatePicker.MinYear = DateTimeOffset.Now;
            CreateOfferDTO.DateOfDeparture = DateTime.Now;
            DepartureDatePicker.MinYear = DateTimeOffset.Now;

            SingletonOfferProvider singletonOrderMonitor = SingletonOfferProvider.Instance;
            _offerProvider = singletonOrderMonitor.OfferProvider;
        }

        private void CurrentWindow_SizeChanged(object sender, Microsoft.UI.Xaml.SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 880)
                VisualStateManager.GoToState(this, "DefaultState", false);
            else
                VisualStateManager.GoToState(this, "SmallState", false);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (OfferViewModel)e.Parameter;

            CreateOfferDTO.OrderId = parameters.OrderId;
            CreateOfferDTO.ClientName = parameters.ClientName;
            CreateOfferDTO.ClientSurname = parameters.ClientSurname;
            CreateOfferDTO.ClientAddress = parameters.ClientAddress;
            CreateOfferDTO.ClientTelephoneNumber = parameters.ClientTelephoneNumber;
            CreateOfferDTO.ClientEmail = parameters.ClientEmail;
            CreateOfferDTO.AddressOfDeparture = parameters.AddressOfDeparture;
            CreateOfferDTO.DateOfDeparture = DateTime.Parse(parameters.DateOfDeparture);
            CreateOfferDTO.DateOfArrival = DateTime.Parse(parameters.DateOfArrival);

        }

        private void arrivalDatePicker_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            if (ArrivalDatePicker.SelectedDate != null)
            {
                if (DepartureDatePicker.SelectedDate < args.NewDate.Value)
                {
                    DepartureDatePicker.SelectedDate = args.NewDate.Value;
                }
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            _offerProvider.Reload(); //Fix
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            FillFieldsInfoBar.IsOpen = false;
            // Validation
            if (CreateOfferDTO.ClientName == null) FillFieldsInfoBar.IsOpen = true;
            if (CreateOfferDTO.ClientSurname == null) FillFieldsInfoBar.IsOpen = true;
            if (CreateOfferDTO.ClientEmail == null) FillFieldsInfoBar.IsOpen = true;
            if (CreateOfferDTO.ClientAddress == null) FillFieldsInfoBar.IsOpen = true;
            if (CreateOfferDTO.AddressOfDeparture == null) FillFieldsInfoBar.IsOpen = true;

            if (FillFieldsInfoBar.IsOpen == true) return;

            _offerProvider.UpdateOffer(CreateOfferDTO);

            App.TryGoBack();
        }
    }
}
