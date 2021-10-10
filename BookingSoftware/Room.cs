using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSoftware
{
    enum rType
    {
        ClubRoom, Suite, Deluxe, Standard, Family
    }
    class Room
    {
        public int RoomID { get; set; }
        public rType RoomType { get; set; }
        public int RoomPrice { get; set; }
        public string RoomDescription { get; set; }
        public bool Available { get; set; }
    }
}
