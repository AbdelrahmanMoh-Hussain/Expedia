using Expedia.Data;
using Expedia.Enums;

namespace Expedia.Entities
{
    public class Admin
    {
        public void AddAvaliableFlightReservation(DateTime startDate, DateTime endDate, decimal cost, string fromCity, string toCity, int fightId)
        {
            using (var context = new AppDbContext())
            {
                var id = (context.FlightReservations.OrderBy(x => x.Id).Last().Id + 1);
                var flightReservation = new FlightReservation
                {
                    Id = id,
                    Period = new Period { StartDate = startDate, EndDate = endDate},
                    Cost = cost,
                    FromCity = fromCity,
                    ToCity = toCity,
                    FlightId = fightId
                };
                context.FlightReservations.Add(flightReservation);
                context.SaveChanges();
            }
        }

        public void AddAvaliableRoomReservation(DateTime startDate, DateTime endDate, decimal cost, int roomId)
        {
            using (var context = new AppDbContext())
            {
                var id = (context.FlightReservations.OrderBy(x => x.Id).Last().Id + 1);
                var roomReservation = new RoomReservation
                {
                    Id = id,
                    Period = new Period { StartDate = startDate, EndDate = endDate },
                    Cost = cost,

                    RoomId = roomId
                };
                context.RoomReservations.Add(roomReservation);
                context.SaveChanges();
            }
        }

        public void AddFlight(string airplaneName, int numberOfSeats, int airlineId)
        {
            using (var context = new AppDbContext())
            {
                var id = (context.Flights.OrderBy(x => x.Id).Last().Id + 1);
                var flight = new Flight
                {
                    Id = id,
                    AirplaneName = airplaneName,
                    NumberOfSeats = numberOfSeats,
                    AirlineId = airlineId
                };
                context.Flights.Add(flight);
                context.SaveChanges();
            }
        }

        public void EditFlight(int id, string airplaneName, int numberOfSeats, int airlineId)
        {
            using (var context = new AppDbContext())
            {
                var flight = context.Flights.SingleOrDefault(x => x.Id == id);
                flight.AirplaneName = airplaneName;
                flight.NumberOfSeats = numberOfSeats;
                flight.AirlineId = airlineId;
                context.SaveChanges();
            }
        }
        public void DeleteFlight(int id)
        {
            using (var context = new AppDbContext())
            {
                var flight = context.Flights.SingleOrDefault(x => x.Id == id);
                context.Flights.Remove(flight);
                context.SaveChanges();
            }
        }

        public void AddRoom(string roomType, int capicity, int hotelId)
        {
            using (var context = new AppDbContext())
            {
                var id = (context.Rooms.OrderBy(x => x.Id).Last().Id + 1);
                var room = new Room
                {
                    Id = id,
                    Type = (roomType == "Interior"? RoomType.InteriorView : 
                                (roomType == "City" ? RoomType.CityView : 
                                    (roomType == "PrivateView" ? RoomType.PrivateView : RoomType.DeluxeView)) ),
                    Capicity = capicity,
                    HotelId = hotelId
                };
                context.Rooms.Add(room);
                context.SaveChanges();
            }
        }
        public void EditRoom(int id, string roomType, int capicity, int hotelId)
        {
            using (var context = new AppDbContext())
            {
                
                var room = context.Rooms.SingleOrDefault(x => x.Id == id);
                room.Type = (roomType == "Interior" ? RoomType.InteriorView :
                                (roomType == "City" ? RoomType.CityView :
                                    (roomType == "PrivateView" ? RoomType.PrivateView : RoomType.DeluxeView)));
                room.Capicity = capicity;
                room.HotelId = hotelId;
                context.SaveChanges();
            }
        }

        public void DeleteRoom(int id)
        {
            using(var context = new AppDbContext())
            {
                var room = context.Rooms.SingleOrDefault(x => x.Id == id);
                context.Rooms.Remove(room);
                context.SaveChanges();
            }
        }
    }
}
