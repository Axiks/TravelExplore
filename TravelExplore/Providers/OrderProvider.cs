using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExplore.Data;
using TravelExplore.Data.Entities;
using TravelExplore.Data.Repositories;

namespace TravelExplore.Providers
{
    public class OrderProvider : IObservable<List<OrderEntity>>
    {
        private List<IObserver<List<OrderEntity>>> _observers;
        private List<OrderEntity> _orders;
        private OrderRepository _orderRepository;
        private CostumerRepository _costumerRepository;

        public OrderProvider()
        {
            _observers = new List<IObserver<List<OrderEntity>>>();
            _orders = new List<OrderEntity>();

            string connectionString = "Data Source=NEKO\\SQLEXPRESS; Initial Catalog=travel-explore-db; User Id=neko; Password=neko";
            ApplicationDbContext applicationDbContext = new ApplicationDbContext(connectionString);
            applicationDbContext.Database.EnsureCreated();

            _orderRepository = new OrderRepository(applicationDbContext);
            _costumerRepository = new CostumerRepository(applicationDbContext);
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

        public void LoadOrders()
        {
            var orders = _orderRepository.GetOrders();
            foreach (var order in orders)
            {
                _orders.Add(order);
            }

            foreach (var observer in _observers)
                observer.OnNext(_orders);
        }

        public void AddOrder(OrderEntity order)
        {
            _orders.Add(order);
            foreach (var observer in _observers)
                observer.OnNext(_orders);
        }

        public void RemoveOrder(int orderId)
        {
            _orderRepository.DeleteOrder(orderId);

            var elementToRemove = _orders.Where(x => x.Id == orderId).FirstOrDefault();
            _orders.Remove(elementToRemove);

            foreach (var observer in _observers)
                observer.OnNext(_orders);
        }
    }
}
