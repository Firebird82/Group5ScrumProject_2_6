using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group5ScrumProject.Models
{
    public class Booking
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Booking(tbBooking booking)
        {
            BookingId = BookingId;
            BookingMadeById = booking.iUserId;
            BookingDay = booking.dtDateDay;
            BokingStartTime = booking.dtTimeStart;
            BokingEndTime = booking.dtTimeEnd;

            BookingRoomName = ((from f in db.tbRooms
                              where f.iRoomId == booking.iRumId
                              select f.sRoomName).FirstOrDefault()).ToString();
        }

        public int BookingId { get; set; }
        public string BookingRoomName { get; set; }
        public int BookingMadeById { get; set; }
        public DateTime BookingDay { get; set; }
        public TimeSpan BokingStartTime { get; set; }
        public TimeSpan BokingEndTime { get; set; }
    }
}