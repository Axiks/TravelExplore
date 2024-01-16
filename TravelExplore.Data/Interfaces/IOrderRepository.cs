using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExplore.Data.Entities;

namespace TravelExplore.Data.Interfaces
{
    public interface IOrderRepository
    {
        public List<OrderEntity> GetOrders();
        public OrderEntity CreateOrder(int userId, string AddressOfDeparture, DateTime DateOfArrival, DateTime DateOfDeparture);
        public OrderEntity UpdateOrder(int orderId, string? AddressOfDeparture, DateTime? DateOfArrival, DateTime? DateOfDeparture);
        public void DeleteOrder(int orderId);
    }
}