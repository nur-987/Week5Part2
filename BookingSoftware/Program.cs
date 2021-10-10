using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSoftware
{
    class Program
    {
        public static List<Room> RoomsList = new List<Room>();
        public static List<Customer> CustList = new List<Customer>();


        static void Main(string[] args)
        {
            AddRooms();

            Console.WriteLine("enter customer ID");
            int tempCustId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("enter customer Name");
            string tempCustName = Console.ReadLine();

            AddCustomer(tempCustId, tempCustName);

            Console.WriteLine("Start Booking");
            DisplaAvailRooms();

            Console.WriteLine("Choose a room");
            Console.WriteLine("Input in chosen room ID");
            int tempRoomId = Int32.Parse(Console.ReadLine());

            ChooseRoom(tempRoomId);

            Console.WriteLine("How many nights will you be staying?");
            int nightTemp = Int32.Parse(Console.ReadLine());

            CalculateBill(nightTemp,tempCustId,tempRoomId);

            Console.ReadLine();

        }

        private static void AddCustomer(int tempCustId, string tempCustName)
        {
            Customer newCustomer = new Customer();
            newCustomer.CustomerID = tempCustId;
            newCustomer.CustomerName = tempCustName;

            CustList.Add(newCustomer);

        }

        public static void CalculateBill(int nights, int custId, int roomId)
        {
            Bill newBill = new Bill();

            newBill.CustomerId_Bill = CustList.Find(x => x.CustomerID == custId);

            Room room_RoomId = RoomsList.Find(x => x.RoomID == roomId);
            newBill.RoomPrice_Bill = room_RoomId;

            newBill.NightsStaying = nights;

            newBill.Paid = false;

            newBill.Tax = 0.5;

            //not getting the customer ID and roomID=> roomPrice
            Console.WriteLine("customerID from the bill class" + newBill.CustomerId_Bill);
            Console.WriteLine("price of room from the bill class" + newBill.RoomPrice_Bill);
            Console.WriteLine("num of nights from the bill class" + newBill.NightsStaying);
            Console.WriteLine("paid from the bill class" + newBill.Paid);
            Console.WriteLine("tax from the bill class" + newBill.Tax);


        }

        public static void DisplaAvailRooms()
        {
            foreach (Room item in RoomsList)
            {
                if (item.Available)
                {
                    Console.WriteLine(item.RoomID);
                    Console.WriteLine(item.RoomType);
                    Console.WriteLine(item.RoomPrice);
                    Console.WriteLine(item.RoomDescription);
                    Console.WriteLine("-------------------------------------");
                }
            }
        }
        public static void ChooseRoom(int id)
        {
            foreach (Room item in RoomsList)
            {
                if (item.RoomID == id)
                {
                    Console.WriteLine("please confirm this is the room you would like to book");
                    Console.WriteLine(item.RoomID);
                    Console.WriteLine(item.RoomType);
                    Console.WriteLine(item.RoomPrice);
                    Console.WriteLine(item.RoomDescription);
                    Console.WriteLine("Proceed?");
                    string input = Console.ReadLine();

                    if(input == "Y")
                    {
                        item.Available = false;
                    }

                }
            }
        }
        public static void AddRooms()
        {
            Room room = new Room()
            {
                RoomID = 1,
                RoomType = rType.ClubRoom,
                RoomPrice = 599,
                RoomDescription = "spacious. sea view. bath tub. private pool",
                Available = true

            };
            Room room2 = new Room()
            {
                RoomID = 2,
                RoomType = rType.Suite,
                RoomPrice = 799,
                RoomDescription = "spacious. sea view. bath tub. club access",
                Available = true

            };
            Room room3 = new Room()
            {
                RoomID = 3,
                RoomType = rType.Family,
                RoomPrice = 499,
                RoomDescription = "spacious. 4 beds. bath tub. kids play area",
                Available = true

            };
            Room room4 = new Room()
            {
                RoomID = 4,
                RoomType = rType.Standard,
                RoomPrice = 199,
                RoomDescription = "single bed. garden view. balcony",
                Available = true

            };
            Room room5 = new Room()
            {
                RoomID = 5,
                RoomType = rType.Deluxe,
                RoomPrice = 299,
                RoomDescription = "king bed. garden view. balcony, late check out",
                Available = true

            };
            RoomsList.Add(room);
            RoomsList.Add(room2);
            RoomsList.Add(room3);
            RoomsList.Add(room4);
            RoomsList.Add(room5);

        }
    }
}
