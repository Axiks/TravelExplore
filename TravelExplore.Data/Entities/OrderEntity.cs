using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExplore.Data.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public CustomerEntity Customer { get; set;}
        public string AddressOfDeparture { get; set; }
        public DateTime DateOfArrival { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
