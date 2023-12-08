using Expedia.Data;

namespace Expedia
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            //Seed Data
            using(var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                if(context.Customers.Count() == 0)
                    context.Customers.AddRange(SeedData.LoadCustomers);
                if (context.BankCards.Count() == 0)
                    context.BankCards.AddRange(SeedData.LoadBankCards);
                if (context.Airlines.Count() == 0)
                    context.Airlines.AddRange(SeedData.LoadAirlines);
                if (context.Flights.Count() == 0)
                    context.Flights.AddRange(SeedData.LoadFLights);
                if (context.Hotels.Count() == 0)
                    context.Hotels.AddRange(SeedData.LoadHotels);
                if (context.Rooms.Count() == 0)
                    context.Rooms.AddRange(SeedData.LoadRooms);
                if (context.RoomReservations.Count() == 0)
                    context.RoomReservations.AddRange(SeedData.LoadRoomReservations);
                if (context.FlightReservations.Count() == 0)
                    context.FlightReservations.AddRange(SeedData.LoadFlightReservations);

                context.SaveChanges();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Presentation_Layer.LoginForm());
        }
    }
}