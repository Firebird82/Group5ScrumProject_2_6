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
                RoomId = roomId.ToString();
                TimeStart = booking.dtTimeStart.ToString();
                TimeEnd = time.Add(TimeSpan.FromHours(1)).ToString();
                IsBooked = "Redan bokad";
                BookingDay = day.ToString("yyyy/MM/dd");   
            }
            else
            {
                BookedById = "";
                RoomId = roomId.ToString();
                TimeStart = time.ToString();
                TimeEnd = time.Add(TimeSpan.FromHours(1)).ToString();
                IsBooked = "Boka";
                BookingDay = day.ToString("yyyy/MM/dd"); 
            }
        }

        public string BookedById { get; set; }
        public string RoomId { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string IsBooked { get; set; }
        public string BookingDay { get; set; }
    }
}