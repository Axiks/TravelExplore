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


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravelExplore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OfferInfoPage : Page
    {
        private MyDataClass OfferData;
        private OrderProvider _orderProvider;

        public OfferInfoPage()
        {
            this.InitializeComponent();

            SingletonOrderProvider singletonOrderMonitor = SingletonOrderProvider.Instance;
            _orderProvider = singletonOrderMonitor.OrderProvider;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (MyDataClass)e.Parameter;

            OfferData = parameters;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            //myDeleteButton.Content = "Clicked :D";
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            _orderProvider.RemoveOrder(OfferData.OrderId);
        }
    }
}
