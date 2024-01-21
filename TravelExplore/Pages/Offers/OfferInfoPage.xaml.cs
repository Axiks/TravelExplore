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
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using TravelExplore.Providers;
using TravelExplore.Models;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravelExplore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OfferInfoPage : Page
    {
        private OfferViewModel OfferData;
        private OfferProvider _orderProvider;

        public OfferInfoPage()
        {
            this.InitializeComponent();

            SingletonOfferProvider singletonOrderMonitor = SingletonOfferProvider.Instance;
            _orderProvider = singletonOrderMonitor.OfferProvider;
        }

        private void CurrentWindow_SizeChanged(object sender, Microsoft.UI.Xaml.SizeChangedEventArgs e)
        {
            if (e.NewSize.Width > 780)
                VisualStateManager.GoToState(this, "DefaultState", false);
            else
                VisualStateManager.GoToState(this, "SmallState", false);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (OfferViewModel)e.Parameter;

            OfferData = parameters;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(UpdateOfferPage), OfferData);
            //myDeleteButton.Content = "Clicked :D";
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            _orderProvider.RemoveOrder(OfferData.OrderId);
        }
    }

}
