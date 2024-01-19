using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExplore.Data.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Telephonenumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public List<OrderEntity> Orders { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
