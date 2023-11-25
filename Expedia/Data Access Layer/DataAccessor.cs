using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Expedia.Data_Access_Layer
{
    public class DataAccessor
    {
        SqlConnection conn;
        public DataAccessor()
        {
            var connString = @"Server=.\SQLExpress;Database=Expedia;Trusted_Connection=Yes;";
           //var connString = @"Server=.\SQLExpress;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Expedia.mdfDatabase=Expedia;Trusted_Connection=Yes;";
            conn = new SqlConnection(connString);
            conn.Open();
        }

        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public void Close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public DataTable Read(string commandText, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = commandText;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public void Execute(string commandText, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = commandText;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            cmd.ExecuteNonQuery();
        }
    }
}
