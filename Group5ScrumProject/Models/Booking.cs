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
            BookingId = booking.iBookingID;
            BookingMadeById = booking.iUserId;
            BookingDay = booking.dtDateDay;
            BokingStartTime = booking.dtTimeStart;
            BokingEndTime = booking.dtTimeEnd;
            BookingMadeByName = (from f in db.tbUsers
                                where f.iUserId == booking.iUserId
                                select f.sUserName).FirstOrDefault();

            BookingRoomName = ((from f in db.tbRooms
                                where f.iRoomId == booking.iRumId
                                select f.sRoomName).FirstOrDefault()).ToString();
        }

        public string BookingMadeByName { get; set; }
        public int BookingId { get; set; }
        public string BookingRoomName { get; set; }
        public int BookingMadeById { get; set; }
        public DateTime BookingDay { get; set; }
        public TimeSpan BokingStartTime { get; set; }
        public TimeSpan BokingEndTime { get; set; }
    }
}