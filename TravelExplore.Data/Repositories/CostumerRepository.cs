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

        public CustomerEntity CreateCustomer(string name, string surname, string email, string? address, int? telephonenumber)
        {
            var customer = new CustomerEntity { Name = name, Surname = surname, Email = email, Address = address, Telephonenumber = telephonenumber };
            _context.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public CustomerEntity GetCustomerById(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);
            return customer;
        }
    }
}
