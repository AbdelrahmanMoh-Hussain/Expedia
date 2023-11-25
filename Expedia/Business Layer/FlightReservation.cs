namespace Expedia.Business_Layer
{
    public class FlightReservation : Itinerary
    {

        public FlightReservation(string airline, string airplaneNumber, string fromCity, string toCity, DateTime startDate, DateTime endDate, decimal cost)
            : base($"Airline: {airline}, #Airplane: {airplaneNumber}, From City: {fromCity}, To City: {toCity}", (endDate - startDate).TotalDays, cost)
        {

        }

        public string AirlineName { get; set; }
        public string AirplaneNumber { get; set; }
        public string FromCity { get; set; }
        public int ToCity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
