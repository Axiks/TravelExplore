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
        public Customer GetCustomerById(int customerId);
        public Customer CreateCustomer(string name, string surname, int? Telephonenumber, string email);
    }
}
