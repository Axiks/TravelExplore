using Microsoft.EntityFrameworkCore;
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
    public class OfferProvider : IObservable<List<OfferViewModel>>
    {
        private List<IObserver<List<OfferViewModel>>> _observers;
        private List<OfferViewModel> _offers;
        private OrderRepository _orderRepository;
        private CostumerRepository _costumerRepository;

        public OfferProvider()
        {
            _observers = new List<IObserver<List<OfferViewModel>>>();
            _offers = new List<OfferViewModel>();

            string connectionString = "Data Source=NEKO\\SQLEXPRESS; Initial Catalog=travel-explore-db; User Id=neko; Password=neko";
            ApplicationDbContext applicationDbContext = new ApplicationDbContext(connectionString);
            //applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();

            _orderRepository = new OrderRepository(applicationDbContext);
            _costumerRepository = new CostumerRepository(applicationDbContext);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<List<OfferViewModel>>> _observers;
            private IObserver<List<OfferViewModel>> _observer;

            public Unsubscriber(List<IObserver<List<OfferViewModel>>> observers, IObserver<List<OfferViewModel>> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }

        public IDisposable Subscribe(IObserver<List<OfferViewModel>> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }

        public void Reload()
        {
            foreach (var observer in _observers)
                observer.OnNext(_offers);
        }

        public void LoadOrders()
        {
            var orders = _orderRepository.GetOrders();

            foreach (var order in orders)
            {
                var offer = new OfferViewModel(order.Customer, order);
                _offers.Add(offer);
            }

            foreach (var observer in _observers)
                observer.OnNext(_offers);
        }

        public void AddOffer(CreateOfferDTO offerDTO)
        {
            var newCostumer = _costumerRepository.CreateCustomer(offerDTO.ClientName, offerDTO.ClientSurname, offerDTO.ClientEmail, offerDTO.ClientAddress, offerDTO.ClientTelephoneNumber);
            var newOrder = _orderRepository.CreateOrder(newCostumer.Id, offerDTO.AddressOfDeparture, offerDTO.DateOfArrival, offerDTO.DateOfDeparture);

            //_orderRepository.CreateOrder(order);
            var offer = new OfferViewModel(newCostumer, newOrder);
            _offers.Add(offer);
            foreach (var observer in _observers)
                observer.OnNext(_offers);
        }

        public void UpdateOffer(UpdateOfferDTO offerDTO)
        {
            var order = _orderRepository.UpdateOrder(
                    offerDTO.OrderId,
                    offerDTO.AddressOfDeparture,
                    offerDTO.DateOfArrival,
                    offerDTO.DateOfDeparture
                );

            var costumer = _costumerRepository.UpdateCustomer(
                    order.Customer.Id,
                    offerDTO.ClientName,
                    offerDTO.ClientSurname,
                    offerDTO.ClientEmail,
                    offerDTO.ClientAddress,
                    offerDTO.ClientTelephoneNumber
                );
            var elementToUpdate = _offers.Where(x => x.OrderId == offerDTO.OrderId).First();

            elementToUpdate.ClientName = costumer.Name;
            elementToUpdate.ClientSurname = costumer.Surname;
            elementToUpdate.ClientEmail = costumer.Email;
            elementToUpdate.ClientAddress = costumer.Address;
            elementToUpdate.ClientTelephoneNumber = costumer.Telephonenumber.ToString();

            elementToUpdate.AddressOfDeparture = order.AddressOfDeparture;
            elementToUpdate.DateOfArrival = order.DateOfArrival.ToString();
            elementToUpdate.DateOfDeparture = order.DateOfDeparture.ToString();

            foreach (var observer in _observers)
                observer.OnNext(_offers);
        }

        public void RemoveOrder(int orderId)
        {
            _orderRepository.DeleteOrder(orderId);

            var elementToRemove = _offers.Where(x => x.OrderId == orderId).FirstOrDefault();
            _offers.Remove(elementToRemove);

            foreach (var observer in _observers)
                observer.OnNext(_offers);
        }
    }
}
