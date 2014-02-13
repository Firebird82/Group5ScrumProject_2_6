using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group5ScrumProject.Models
{
    public class Room
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        string roomIdNr = "";

        public Room(tbRoom room)
        {
            roomIdNr = room.iRoomId.ToString();
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

            for (int i = 0; i < timeList.Count-1; i++)
            {
                tbBooking booking = (from f in db.tbBookings
                                     where f.iRumId == RoomId && day == f.dtDateDay && f.dtTimeStart == timeList[i]
                                     select f).FirstOrDefault();

                if (booking != null)
                {
                    TimeSpan startTime = booking.dtTimeStart;
                    TimeSpan endTime = booking.dtTimeEnd;

                    int bookingTimeDifference = endTime.Hours - startTime.Hours;

                    string userName = (from f in db.tbUsers
                                       where f.iUserId == booking.iUserId
                                       select f.sUserName).FirstOrDefault();

                    string userClass = (from f in db.tbUsers
                                        where f.iUserId == booking.iUserId
                                        select f.sClass).FirstOrDefault();

                    string bookedBy = userName + " - " + userClass;
                    string roomId = roomIdNr.ToString();
                    string isBooked = "Redan bokad";
                    string bookingDay = day.ToString("yyyy/MM/dd");

                    for (int x = 0; x < bookingTimeDifference; x++)
                    {
                        if (x > 0)
                        {
                            startTime = startTime.Add(TimeSpan.FromHours(1));    
                        }
                        
                        string timeStart = (startTime.ToString()) ;
                        string timePlusOneHour = startTime.Add(TimeSpan.FromHours(1)).ToString();
                     
                        bookingList.Add(new BookingInfo(roomId, bookedBy, timeStart, timePlusOneHour, isBooked, bookingDay));

                        if (x < bookingTimeDifference-1)
                        {
                            i++;   
                        }   
                    }
                }
                else
                {
                    string bookedBy = "";
                    string roomId = roomIdNr.ToString();
                    string timeStart = timeList[i].ToString();
                    string timePlusOneHour = timeList[i].Add(TimeSpan.FromHours(1)).ToString();
                    string isBooked = "Boka";
                    string bookingDay = day.ToString("yyyy/MM/dd");

                    bookingList.Add(new BookingInfo(roomId, bookedBy, timeStart, timePlusOneHour, isBooked, bookingDay));
                }     
            }
            return bookingList;
        }
    }
}