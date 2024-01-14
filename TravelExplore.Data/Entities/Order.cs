using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExplore.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set;}
        public required string AddressOfDeparture { get; set; }
        public required DateTime DateOfArrival { get; set; }
        public required DateTime DateOfDeparture { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
