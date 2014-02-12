using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group5ScrumProject.Models
{
    public class BookingInfo
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public BookingInfo(string roomId, string bookedBy, string timeStart, string timePlusOneHour, string isBooked, string bookingDay)
        {
            RoomId = roomId;

            BookedBy = bookedBy;
            RoomId = roomId;
            TimeStart = timeStart;
            TimePlusOneHour = timePlusOneHour;
            IsBooked = isBooked;
            BookingDay = bookingDay;
        }

        public string BookedBy { get; set; }
        public string RoomId { get; set; }
        public string TimeStart { get; set; }
        public string TimePlusOneHour { get; set; }
        public string IsBooked { get; set; }
        public string BookingDay { get; set; }
    }
}