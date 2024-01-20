using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExplore.Data.Entities;

namespace TravelExplore.Data.Interfaces
{
    public interface ICustomerRepository
    {
        public CustomerEntity GetCustomerById(int customerId);
        public CustomerEntity CreateCustomer(string name, string surname, string email, string? address, string? telephonenumber);
        public CustomerEntity UpdateCustomer(int customerId, string? name, string? surname, string? email, string? address, string? telephonenumber);
    }
}
