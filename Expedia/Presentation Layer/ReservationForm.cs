using Expedia.Business_Layer;
using Expedia.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expedia.Presentation_Layer
{
    public partial class ReservationForm : Form
    {
        public string status;
        public Customer customer;
        public List<Itinerary> selectedReservations = new List<Itinerary>();
        public ReservationForm()
        {
            InitializeComponent();
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            DataAccessor dataAccessor = new DataAccessor();
            SqlParameter[] parameters = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            DataTable dt = new DataTable() ;
            if (status == "R")
            {
                dt = dataAccessor.Read("LoadRoomReservations", parameters);
                button2.Text = "Reserve Flight";
                label3.Text = "Hotel Name";
                label4.Text = "City";
                label5.Text = "Room Type";
                label6.Text = "Capicity";
            }
            else if (status == "F")
            {
                dt = dataAccessor.Read("LoadFlightReservations", parameters);
                button2.Text = "Reserve Room";
                label3.Text = "Airline Name";
                label4.Text = "Airpkane #";
                label5.Text = "From City";
                label6.Text = "To City";
            }
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["IsSelected"]) == 1)
                {
                    ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["selected"]).Value = true;
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSelectedRowsToSelectedReservationList();
            if (status == "F")
            {
                Presentation_Layer.ReservationForm reservationForm = new Presentation_Layer.ReservationForm();
                reservationForm.status = "R";
                Hide();
                reservationForm.FormClosed += (s, args) => this.Close();
                reservationForm.customer = this.customer;
                reservationForm.selectedReservations.AddRange(selectedReservations);
                reservationForm.Show();
            }
            else if (status == "R")
            {
                dataGridView1.SelectedRows.ToString();

                Presentation_Layer.ReservationForm reservationForm = new Presentation_Layer.ReservationForm();
                reservationForm.status = "F";
                Hide();
                reservationForm.FormClosed += (s, args) => this.Close();
                reservationForm.customer = this.customer;
                reservationForm.selectedReservations.AddRange(selectedReservations);
                reservationForm.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentation_Layer.CheckOutForm checkOutForm = new CheckOutForm();
            checkOutForm.customer = this.customer;
            AddSelectedRowsToSelectedReservationList();
            checkOutForm.selectedReservations.AddRange(selectedReservations);
            Hide();
            checkOutForm.FormClosed += (s, args) => this.Close();
            checkOutForm.Show();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selected.Selected = true;
            DataAccessor dataAccessor = new DataAccessor();
            SqlParameter[] parameters = new SqlParameter[1];
            var id = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            parameters[0] = new SqlParameter("id", Convert.ToInt32(id));
            dataAccessor.Open();
            if(status == "R")
            {
                dataAccessor.Execute("SelectRoom", parameters);

            }
            else if(status == "F")
            {
                dataAccessor.Execute("SelectFligh", parameters);
            }
            dataAccessor.Close();
        }

        private void AddSelectedRowsToSelectedReservationList()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selected"].Value);
                if (isSelected)
                {
                    if (status == "R")
                    {
                        var hotelName = row.Cells["Name"].Value.ToString();
                        var hotelCity = row.Cells["City"].Value.ToString();
                        var roomType = row.Cells["RoomType"].Value.ToString();
                        var capicity = Convert.ToInt32(row.Cells["Capicity"].Value);
                        var startDate = Convert.ToDateTime(row.Cells["StartDate"].Value);
                        var endDate = Convert.ToDateTime(row.Cells["EndDate"].Value);
                        var cost = Convert.ToDecimal(row.Cells["Cost"].Value);
                        RoomReservation reservation =
                            new RoomReservation(hotelName, roomType, hotelCity, capicity, startDate, endDate, cost);
                        selectedReservations.Add(reservation);
                    }
                    else if (status == "F")
                    {
                        var airlineName = row.Cells["Airline Name"].Value.ToString();
                        var airplaneNum = row.Cells["#Airplane"].Value.ToString();
                        var fromCity = row.Cells["FromCity"].Value.ToString();
                        var toCity = row.Cells["ToCity"].Value.ToString();
                        var startDate = Convert.ToDateTime(row.Cells["StartDate"].Value);
                        var endDate = Convert.ToDateTime(row.Cells["EndDate"].Value);
                        var cost = Convert.ToDecimal(row.Cells["Cost"].Value);
                        FlightReservation reservation =
                            new FlightReservation(airlineName, airplaneNum, fromCity,toCity, startDate, endDate, cost);
                        selectedReservations.Add(reservation);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Data_Access_Layer.DataAccessor dataAccessor = new DataAccessor();
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("greaterThanValue", textBox2.Text == "" ? "0" : textBox2.Text);
            parameters[1] = new SqlParameter("lessThanValue", textBox1.Text);
            if (status == "R")
            {
                dataGridView1.DataSource = dataAccessor.Read("SearchByCost", parameters);
            }
            else if (status == "F")
            {
                dataGridView1.DataSource = dataAccessor.Read("SearchByCost2", parameters);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Data_Access_Layer.DataAccessor dataAccessor = new DataAccessor();
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("greaterThanValue", textBox2.Text);
            parameters[1] = new SqlParameter("lessThanValue", textBox1.Text == "" ? "1000000": textBox1.Text);
            if(status == "R")
            {
                dataGridView1.DataSource = dataAccessor.Read("SearchByCost", parameters);
            }
            else if(status == "F")
            {
                dataGridView1.DataSource = dataAccessor.Read("SearchByCost2", parameters);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Data_Access_Layer.DataAccessor dataAccessor = new DataAccessor();
            SqlParameter[] parameters = new SqlParameter[1];
            if(status == "R")
            {
                parameters[0] = new SqlParameter("hotelName", textBox3.Text);
                dataGridView1.DataSource = dataAccessor.Read("SearchByHotelName", parameters);
            }
            else if(status == "F")
            {
                parameters[0] = new SqlParameter("airlineName", textBox3.Text);
                dataGridView1.DataSource = dataAccessor.Read("SearchByAirlineName", parameters);

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Data_Access_Layer.DataAccessor dataAccessor = new DataAccessor();
            SqlParameter[] parameters = new SqlParameter[1];
            if (status == "R")
            {
                parameters[0] = new SqlParameter("city", textBox4.Text);
                dataGridView1.DataSource = dataAccessor.Read("SearchByCity", parameters);
            }
            else if (status == "F")
            {
                parameters[0] = new SqlParameter("airplaneNumber", textBox4.Text);
                dataGridView1.DataSource = dataAccessor.Read("SearchByAirplaneNumber", parameters);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Data_Access_Layer.DataAccessor dataAccessor = new DataAccessor();
            SqlParameter[] parameters = new SqlParameter[1];
            if (status == "R")
            {
                parameters[0] = new SqlParameter("roomType", textBox5.Text);
                dataGridView1.DataSource = dataAccessor.Read("SearchByRoomType", parameters);
            }
            else if (status == "F")
            {
                parameters[0] = new SqlParameter("fromCity", textBox5.Text);
                dataGridView1.DataSource = dataAccessor.Read("SearchByfromCity", parameters);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Data_Access_Layer.DataAccessor dataAccessor = new DataAccessor();
            SqlParameter[] parameters = new SqlParameter[1];
            if (status == "R")
            {
                parameters[0] = new SqlParameter("capicity", textBox6.Text);
                dataGridView1.DataSource = dataAccessor.Read("SearchByRoomCapicity", parameters);
            }
            else if (status == "F")
            {
                parameters[0] = new SqlParameter("toCity", textBox6.Text);
                dataGridView1.DataSource = dataAccessor.Read("SearchByToCity", parameters);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
