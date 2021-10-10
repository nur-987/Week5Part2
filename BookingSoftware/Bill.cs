using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSoftware
{
    class Bill
    {
        public Room RoomPrice_Bill { get; set; }
        public Customer CustomerId_Bill { get; set; }
        public bool Paid { get; set; }
        public double TotalBill { get; set; }
        public double Tax { get; set; }
        public int NightsStaying { get; set; }

        
    }
}
