using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExplore.Providers
{
    public sealed class SingletonOfferProvider
    {
        private static readonly SingletonOfferProvider instance = new SingletonOfferProvider();
        public OfferProvider OfferProvider { get; }

        static SingletonOfferProvider()
        {
        }
        private SingletonOfferProvider()
        {
            OfferProvider = new OfferProvider();
        }
        public static SingletonOfferProvider Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
