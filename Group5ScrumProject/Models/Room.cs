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

        public List<BookingInfo> BookingList(DateTime day)
        {
            List<BookingInfo> bookingList = new List<BookingInfo>();
            List<TimeSpan> timeList = new List<TimeSpan>();

            timeList.Add(new TimeSpan(9, 0, 0));
            timeList.Add(new TimeSpan(10, 0, 0));
            timeList.Add(new TimeSpan(11, 0, 0));
            timeList.Add(new TimeSpan(12, 0, 0));
            timeList.Add(new TimeSpan(13, 0, 0));
            timeList.Add(new TimeSpan(14, 0, 0));
            timeList.Add(new TimeSpan(15, 0, 0));
            timeList.Add(new TimeSpan(16, 0, 0));

            foreach (TimeSpan time in timeList)
            {
                bookingList.Add(new BookingInfo(RoomId, time, day));
            }
            
            return bookingList;
        }
    }
}