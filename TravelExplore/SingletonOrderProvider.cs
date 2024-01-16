using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExplore.Providers;

namespace TravelExplore
{
    public sealed class SingletonOrderProvider
    {
        private static readonly SingletonOrderProvider instance = new SingletonOrderProvider();
        public OrderProvider OrderProvider { get; }
        
        static SingletonOrderProvider()
        {
        }
        private SingletonOrderProvider()
        {
            OrderProvider = new OrderProvider();
        }
        public static SingletonOrderProvider Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
