using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExplore.Data.Entities;
using TravelExplore.Data.Interfaces;

namespace TravelExplore.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public OrderEntity CreateOrder(int userId, string AddressOfDeparture, DateTime DateOfArrival, DateTime DateOfDeparture)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id ==  userId);
            var order = new OrderEntity { Customer = customer, AddressOfDeparture = AddressOfDeparture, DateOfArrival = DateOfArrival, DateOfDeparture = DateOfDeparture };
            _context.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id ==  orderId);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public List<OrderEntity> GetOrders()
        {
            return _context.Orders
                .Include(x => x.Customer)
                .ToList();
        }

        public OrderEntity UpdateOrder(int orderId, string? AddressOfDeparture, DateTime? DateOfArrival, DateTime? DateOfDeparture)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            if (AddressOfDeparture != null) order.AddressOfDeparture = AddressOfDeparture;
            if (DateOfArrival != null) order.DateOfArrival = (DateTime)DateOfArrival;
            if (DateOfDeparture != null) order.DateOfDeparture = (DateTime)DateOfDeparture;
            _context.SaveChanges();
            return order;
        }
    }
}
