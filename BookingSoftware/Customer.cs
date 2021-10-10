using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSoftware
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int HandPhoneNum { get; set; }
        public bool NewCustomer { get; set; }

        public Room ChosenRoom { get; set; }
    }
}
