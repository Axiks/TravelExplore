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
using System.Diagnostics;
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
        private ObservableCollection<OfferViewModel> MyData;

        private MainPageParams _mainPageParams;

        public MainPage()
        {
            this.InitializeComponent();
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

            var parameters = (MainPageParams)e.Parameter;

            ListView OffersLV = new ListView();

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

            if (_mainPageParams.SelectedOrderIndex >= 0)
            {
                OfferDataFrame.Navigate(typeof(OfferInfoPage), MyData[_mainPageParams.SelectedOrderIndex]);
                return;
            };
            OfferDataFrame.Navigate(typeof(EmptyOfferInfoPage));
        }
    }
}
