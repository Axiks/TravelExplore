using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExplore.Data.Entities;

namespace TravelExplore.Providers
{
    public class OrderProvider : IObservable<List<OrderEntity>>
    {
        private List<IObserver<List<OrderEntity>>> _observers;
        private List<OrderEntity> _orders;

        public OrderProvider()
        {
            _observers = new List<IObserver<List<OrderEntity>>>();
            _orders = new List<OrderEntity>();
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<List<OrderEntity>>> _observers;
            private IObserver<List<OrderEntity>> _observer;

            public Unsubscriber(List<IObserver<List<OrderEntity>>> observers, IObserver<List<OrderEntity>> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }

        public IDisposable Subscribe(IObserver<List<OrderEntity>> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }

        /*public void AddOrder(Order order)
        {
            _orders.Add(order);
        }*/

        //public List<Order> GetAllOrder() => _orders;

        public void LoadOrders()
        {
            foreach (var observer in _observers)
                observer.OnNext(_orders);
        }

        public void AddOrder(OrderEntity order)
        {
            _orders.Add(order);
            foreach (var observer in _observers)
                observer.OnNext(_orders);
        }
    }
}
