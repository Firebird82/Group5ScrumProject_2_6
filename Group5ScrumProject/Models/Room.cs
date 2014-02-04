using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group5ScrumProject.Models
{
    public class Room
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Room(int id)
        {
            RoomId = id;
            RoomName = db.tbRooms
                .Where(i => i.iRoomId == RoomId)
                .FirstOrDefault().sRoomName;
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; }
    }
}