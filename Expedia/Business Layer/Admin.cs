using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.Business_Layer
{
    public class Admin
    {
        Data_Access_Layer.DataAccessor dataAccessor = new Data_Access_Layer.DataAccessor();

        public void AddFlightReservation(string fromCity, string toCity, DateTime startDate, DateTime endDate, string cost, string airlineName, int airplaneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("fromCity", fromCity);
            parameters[1] = new SqlParameter("toCity", toCity);
            parameters[2] = new SqlParameter("startDate", startDate);
            parameters[3] = new SqlParameter("endDate", endDate);
            parameters[4] = new SqlParameter("cost", cost);
            parameters[5] = new SqlParameter("airline", airlineName);
            parameters[6] = new SqlParameter("airplane", airplaneNumber);

            dataAccessor.Open();
            dataAccessor.Execute("AddFlightReservation", parameters);
            dataAccessor.Close();
        }

        public void EditFlightReservation(int id, string fromCity, string toCity, DateTime startDate, DateTime endDate, string cost, string airlineName, int airplaneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[8];
            parameters[0] = new SqlParameter("fromCity", fromCity);
            parameters[1] = new SqlParameter("toCity", toCity);
            parameters[2] = new SqlParameter("startDate", startDate);
            parameters[3] = new SqlParameter("endDate", endDate);
            parameters[4] = new SqlParameter("cost", cost);
            parameters[5] = new SqlParameter("airline", airlineName);
            parameters[6] = new SqlParameter("airplane", airplaneNumber);
            parameters[7] = new SqlParameter("id", id);

            dataAccessor.Open();
            dataAccessor.Execute("EditFlightReservation", parameters);
            dataAccessor.Close();
        }
        public void DeleteFlightReservation(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("id", id);


            dataAccessor.Open();
            dataAccessor.Execute("DeleteFlightReservation", parameters);
            dataAccessor.Close();
        }

        public void AddRoomReservation(string roomNumber, string hotel, DateTime startDate, DateTime endDate, string cost)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("roomNumber", roomNumber);
            parameters[1] = new SqlParameter("hotel", hotel);
            parameters[2] = new SqlParameter("startDate", startDate);
            parameters[3] = new SqlParameter("endDate", endDate);
            parameters[4] = new SqlParameter("cost", cost);

            dataAccessor.Open();
            dataAccessor.Execute("AddRoomReservation", parameters);
            dataAccessor.Close();
        }
        public void EditRoomReservation(int id, string roomNumber, string hotel, DateTime startDate, DateTime endDate, string cost)
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("id", id);
            parameters[1] = new SqlParameter("roomNumber", roomNumber);
            parameters[2] = new SqlParameter("hotel", hotel);
            parameters[3] = new SqlParameter("startDate", startDate);
            parameters[4] = new SqlParameter("endDate", endDate);
            parameters[5] = new SqlParameter("cost", cost);

            dataAccessor.Open();
            dataAccessor.Execute("EditRoomReservation", parameters);
            dataAccessor.Close();
        }

        public void DeleteRoomReservation(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("id", id);


            dataAccessor.Open();
            dataAccessor.Execute("DeleteRoomReservation", parameters);
            dataAccessor.Close();
        }
    }
}
