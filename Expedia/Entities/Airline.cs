namespace Expedia.Entities
{
    public class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public bool Active { get; set; }
        public List<Flight> Flights { get; set; }

    }
}