namespace Expedia.Entities
{
    public class FlightReservation: Reservation
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        
    }
}
