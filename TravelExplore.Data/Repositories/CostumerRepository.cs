using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExplore.Data.Entities;
using TravelExplore.Data.Interfaces;

namespace TravelExplore.Data.Repositories
{
    public class CostumerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CostumerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer CreateCustomer(string name, string surname, int? telephonenumber, string email)
        {
            var customer = new Customer { Name = name, Surname = surname, Telephonenumber = telephonenumber, Email = email };
            _context.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);
            return customer;
        }
    }
}
