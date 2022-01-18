using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebApp.Models
{
    public class Room
    {
        public Room(int id, int numberRoom, string roomType, bool ifAvailableRoom, int price)
        {
            Id = id;
            NumberRoom = numberRoom;
            RoomType = roomType;
            IfAvailableRoom = ifAvailableRoom;
            Price = price;
        }

        public int Id { get; set; }
        public int NumberRoom { get; set; }
        public string RoomType { get; set; }
        public bool IfAvailableRoom { get; set; }
        public int Price { get; set; }
    }
}