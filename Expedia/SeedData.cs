using Expedia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia
{
    public class SeedData
    {
        public static List<Customer> LoadCustomers => new()
        {
            new Customer {Id = 1, Name = "Ahmed Mohamed", UserName = "AhmedxMoh", Password = "123"},
            new Customer {Id = 2, Name = "Sara Ail", UserName = "Soso", Password = "0000"},
            new Customer {Id = 3, Name = "Taha abo gabal", UserName = "Pop123", Password = "753"},
        };

        public static List<BankCard> LoadBankCards => new()
        {
            new BankCard { CardNumber = "417447", Company = "Visa", Type = Enums.BankCardType.Credit, ExpireDate = new DateTime(2026,11,01), Balance = 15000, CustomerId = 1},
            new BankCard { CardNumber = "217447", Company = "Master", Type = Enums.BankCardType.Debit, ExpireDate = new DateTime(2024,11,01), Balance = 70, CustomerId = 1},
            new BankCard { CardNumber = "317447", Company = "PayPal", Type = Enums.BankCardType.Virtual, ExpireDate = new DateTime(2023,11,01), Balance = 15000, CustomerId = 2},

        };

        public static List<Airline> LoadAirlines => new()
        {
            new Airline {Id = 1,Name = "Egypt Fly", Country = "Egypt", Active = true},
            new Airline {Id = 2,Name = "Turkish Fly", Country = "Turkey", Active = true},
        };
        public static List<Flight> LoadFLights => new()
        {
            new Flight {Id = 1,AirplaneName = "Boeing", NumberOfSeats = 500, AirlineId = 1},
            new Flight {Id = 2,AirplaneName = "Boeing", NumberOfSeats = 500, AirlineId = 2},
            new Flight {Id = 3,AirplaneName = "Airbus A320", NumberOfSeats = 700, AirlineId = 1},
        };

        public static List<Hotel> LoadHotels => new()
        {
            new Hotel {Id = 1,Name = "Hilton Hotels", Country = "Egypt", City = "Cairo", NumberOfStars = 5},
            new Hotel {Id = 2,Name = "Hilton Hotels", Country = "Egypt", City = "Alex", NumberOfStars = 4},
            new Hotel {Id = 3,Name = "The Plaza Hotel", Country = "USA", City = "New York", NumberOfStars = 5},
        };

        public static List<Room> LoadRooms => new()
        {
            new Room {Id = 1,Type = Enums.RoomType.CityView, Capicity = 3, HotelId = 1},
            new Room {Id = 2,Type = Enums.RoomType.InteriorView, Capicity = 5, HotelId = 3},
            new Room {Id = 3,Type = Enums.RoomType.PrivateView, Capicity = 1, HotelId = 1},
        };

        public static List<FlightReservation> LoadFlightReservations => new()
        {
            new FlightReservation {Id = 1, Period = new Period { StartDate = DateTime.Today.AddDays(7), EndDate = DateTime.Today.AddDays(14) }, Cost = 1000m, FromCity = "Cairo", ToCity = "New York", CustomerId = 1, FlightId = 1 }
        };

        public static List<RoomReservation> LoadRoomReservations => new()
        {
             new RoomReservation {Id = 2, Period = new Period { StartDate = DateTime.Today.AddDays(7), EndDate = DateTime.Today.AddDays(14) }, Cost = 1000m, CustomerId = 2, RoomId = 1 }

        };

    }
}
