using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public string AirplaneName { get; set; }
        public int NumberOfSeats { get; set; }

        //1 - 1 realtionship
        public FlightReservation FlightReservation { get; set; }

        //1 - m realtionship
        public int AirlineId { get; set; }
        public Airline Airline { get; set; }
    }
}
