using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExplore.Data;
using TravelExplore.Data.Entities;
using TravelExplore.Data.Repositories;
using TravelExplore.Providers;

namespace TravelExplore.Services
{
    public class OfferService
    {
        private ApplicationDbContext _dbContext;
        private CostumerRepository _costumerRepository;
        private OrderRepository _orderRepository;
        private OrderProvider _orderProvider;

        public OfferService()
        {
            string connectionString = "Data Source=NEKO\\SQLEXPRESS; Initial Catalog=travel-explore-db; User Id=neko; Password=neko";
            _dbContext = new ApplicationDbContext(connectionString);
            _costumerRepository = new CostumerRepository(_dbContext);
            _orderRepository = new OrderRepository(_dbContext);
            _orderProvider = SingletonOrderProvider.Instance.OrderProvider;
        }

        public void LoadOffer()
        {
            var orders = _orderRepository.GetOrders();
            foreach (var order in orders)
            {

            }
        }
    }
}
