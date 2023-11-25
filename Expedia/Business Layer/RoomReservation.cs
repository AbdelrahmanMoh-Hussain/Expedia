using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Expedia.Business_Layer
{
    public class RoomReservation : Itinerary
    {

        public RoomReservation(string hotelName, string roomType, string city, int roomCapicity, DateTime startDate, DateTime endDate, decimal cost)
            : base($"Hotel: {hotelName}, Room Type: {roomType}, In City: {city}, With capicity: {roomCapicity}", (endDate - startDate).TotalDays , cost)
        {
            
        }

        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public string City { get; set; }
        public int RoomCapicity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        
    }
}
