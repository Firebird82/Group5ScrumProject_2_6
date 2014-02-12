using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group5ScrumProject.Models
{
    public class BookingInfo
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public BookingInfo(int roomId, TimeSpan time, DateTime day)
        {
            tbBooking booking = (from f in db.tbBookings
                                where f.iRumId == roomId && day == f.dtDateDay && time == f.dtTimeStart
                                select f).FirstOrDefault();

            if (booking != null)
            {

                BookedById = booking.iUserId.ToString(); //Hämta användarens namn och klass David Sebela - SHAN13
                RoomId = roomId; 
                TimeStart = booking.dtTimeStart.ToString();
                TimeEnd = time.Add(TimeSpan.FromHours(1)).ToString();
                IsBooked = "Redan bokad";
                BookingDay = booking.dtDateDay.ToString();   
            }
            else
            {
                BookedById = "";
                RoomId = roomId;
                TimeStart = time.ToString();
                TimeEnd = time.Add(TimeSpan.FromHours(1)).ToString();
                IsBooked = "Boka";
                BookingDay = "";
            }
        }

        public string BookedById { get; set; }
        public int RoomId { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string IsBooked { get; set; }
        public string BookingDay { get; set; }
    }
}