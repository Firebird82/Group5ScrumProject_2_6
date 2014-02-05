using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group5ScrumProject.Models
{
    public class Room
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Room(tbRoom room)
        {
            RoomId = room.iRoomId;
            RoomName = room.sRoomName;
            Chairs = room.iRoomChairs;
            RoomDescription = room.sRoomDesc;
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int Chairs { get; set; }
        public string RoomDescription { get; set; }
    }
}