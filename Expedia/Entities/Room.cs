using Expedia.Enums;

namespace Expedia.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public RoomType Type { get; set; }
        public int Capicity { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public RoomReservation RoomReservation { get; set; }
    }
}