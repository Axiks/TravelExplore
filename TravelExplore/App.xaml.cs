using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelExplore.Data.Entities;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using TravelExplore.Providers;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TravelExplore
{
    public class MainPageParams
    {
        public MainPageParams() { }
        public ObservableCollection<MyDataClass> MyData { get; set; }
        public int SelectedOrderIndex { get; set; } = -1;
    }

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application, IObserver<List<OrderEntity>>
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>

        private MainPageParams _myPageparameters = new MainPageParams();

        public App()
        {
            this.InitializeComponent();

            SingletonOrderProvider singletonOrderMonitor = SingletonOrderProvider.Instance;
            OrderProvider OrderProvider = singletonOrderMonitor.OrderProvider;
            OrderProvider.Subscribe(this);
        }



        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();

            // Create a Frame to act as the navigation context and navigate to the first page
            _rootFrame = new Frame();
            _rootFrame.NavigationFailed += OnNavigationFailed;


            _myPageparameters.MyData = new ObservableCollection<MyDataClass> {
                new MyDataClass("Miku", "Katowice", DateTime.Now, DateTime.Now.AddDays(3)),
                new MyDataClass("Nana", "Red sea", DateTime.Now, DateTime.Now.AddDays(7)),
                new MyDataClass("Axiks", "California", DateTime.Now, DateTime.Now.AddDays(14))
            };

            // Navigate to the first page, configuring the new page
            // by passing required information as a navigation parameter
            _rootFrame.Navigate(typeof(MainPage), _myPageparameters);

            // Place the frame in the current Window
            m_window.Content = _rootFrame;
            // Ensure the MainWindow is active
            m_window.Activate();

            SingletonOrderProvider singletonOrderMonitor = SingletonOrderProvider.Instance;
            var OrderProvider = singletonOrderMonitor.OrderProvider;
            OrderProvider.LoadOrders();
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private Window m_window;
        private static Frame _rootFrame;

        public static bool TryGoBack()
        {
            //Frame rootFrame = Window.Current.Content as Frame;
            Frame rootFrame = _rootFrame;
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                return true;
            }
            return false;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(List<OrderEntity> orders)
        {
            _myPageparameters.MyData.Clear();
            foreach (var order in orders)
            {
                var data = new MyDataClass("Nana", order.AddressOfDeparture, order.DateOfDeparture, order.DateOfArrival);
                data.OrderId = order.Id;
                data.DateOfCreatedOffer = order.Created.ToString();
                data.DateOfUpdatesOffer = order.Updated.ToString();
                _myPageparameters.MyData.Add(data);
            }
        }
    }
}
