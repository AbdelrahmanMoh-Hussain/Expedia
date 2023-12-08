using Expedia.Entities;
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
using Expedia.Data;
using Microsoft.EntityFrameworkCore;
using Azure;
using Expedia.Enums;

namespace Expedia.Presentation_Layer
{
    public partial class ReservationForm : Form
    {
        public string status;
        public Customer customer;
        public List<Reservation> selectedReservations = new List<Reservation>();
        public ReservationForm()
        {
            InitializeComponent();
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            //DataAccessor dataAccessor = new DataAccessor();
            //SqlParameter[] parameters = null;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            //DataTable dt = new DataTable() ;
            using (var context = new AppDbContext())
            {

                if (status == "R")
                {
                    //dt = dataAccessor.Read("LoadRoomReservations", parameters);
                    var quary = from rr in context.RoomReservations.AsNoTracking()
                                join r in context.Rooms.AsNoTracking()
                                on rr.RoomId equals r.Id
                                join h in context.Hotels.AsNoTracking()
                                on r.HotelId equals h.Id
                                where rr.CustomerId == null
                                select new
                                {
                                    rr.Id,
                                    h.Name,
                                    h.Country,
                                    r.Type,
                                    r.Capicity,
                                    rr.Period,
                                    rr.Cost,

                                };
                    label3.Text = "Hotel Name";
                    label4.Text = "City";
                    label5.Text = "Room Type";
                    label6.Text = "Capicity";
                    dataGridView1.DataSource = quary.ToList();
                }
                else if (status == "F")
                {
                    //dt = dataAccessor.Read("LoadFlightReservations", parameters);
                    var quary = from fr in context.FlightReservations.AsNoTracking()
                                join f in context.Flights.AsNoTracking()
                                on fr.FlightId equals f.Id
                                join a in context.Airlines.AsNoTracking()  
                                on f.AirlineId equals a.Id
                                where fr.CustomerId == null
                                select new
                                {
                                    fr.Id,
                                    Airline_Name = a.Name,
                                    fr.FromCity,
                                    fr.ToCity,
                                    f.AirplaneName,
                                    f.NumberOfSeats,
                                    fr.Period,
                                    fr.Cost,
                                };
                    label3.Text = "Airline Name";
                    label4.Text = "Airpkane #";
                    label5.Text = "From City";
                    label6.Text = "To City";
                    dataGridView1.DataSource = quary.ToList();
                }
                
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    Console.WriteLine(dataGridView1.Rows[i].Cells.ToString());
                //    //if (Convert.ToInt32(dataGridView1.Rows[i].Cells["IsSelected"]) == 1)
                //    //{
                //    //    ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["selected"]).Value = true;
                //    //}
                //}

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
            //DataAccessor dataAccessor = new DataAccessor();
            //SqlParameter[] parameters = new SqlParameter[1];
            //var id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
            ////parameters[0] = new SqlParameter("id", Convert.ToInt32(id));
            ////dataAccessor.Open();
            ////if(status == "R")
            ////{
            ////    dataAccessor.Execute("SelectRoom", parameters);

            ////}
            ////else if(status == "F")
            ////{
            ////    dataAccessor.Execute("SelectFligh", parameters);
            ////}
            ////dataAccessor.Close();
            //using(var context = new AppDbContext())
            //{
            //    var reservation = context.Reservations.Single(x => x.Id == id);
            //    reservation.IsSelected = true;
            //    context.SaveChanges();
            //}
        }

        private void AddSelectedRowsToSelectedReservationList()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                using (var context = new AppDbContext())
                {
                    if (isSelected)
                    {
                        var id = Convert.ToInt32(row.Cells["Id"].Value);
                        var reservation = context.Reservations.Single(x => x.Id == id);
                        selectedReservations.Add(reservation);
                    }                       
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //using(var context = new AppDbContext())
            //{
            //    if (status == "R")
            //    {
            //        dataGridView1.DataSource = context.RoomReservations.Where(x => x.Cost >= Convert.ToInt32((textBox2.Text == "" ? "0" : textBox2.Text))
            //                                                                 && x.Cost <= Convert.ToInt32((textBox1.Text == "" ? "100000" : textBox1.Text))).ToList();
            //    }
            //    else if (status == "F")
            //    {
            //        dataGridView1.DataSource = context.FlightReservations.Where(x => x.Cost >= Convert.ToInt32((textBox2.Text == "" ? "0" : textBox2.Text))
            //                                                                 && x.Cost <= Convert.ToInt32((textBox1.Text == "" ? "100000" : textBox1.Text))).ToList();

            //    }
                
            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //using (var context = new AppDbContext())
            //{
            //    if (status == "R")
            //    {
            //        dataGridView1.DataSource = context.RoomReservations.Where(x => x.Cost >= Convert.ToInt32((textBox2.Text == "" ? "0" : textBox2.Text))
            //                                                                 && x.Cost <= Convert.ToInt32((textBox1.Text == "" ? "100000" : textBox1.Text))).ToList();
            //    }
            //    else if (status == "F")
            //    {
            //        dataGridView1.DataSource = context.FlightReservations.Where(x => x.Cost >= Convert.ToInt32((textBox2.Text == "" ? "0" : textBox2.Text))
            //                                                                 && x.Cost <= Convert.ToInt32((textBox1.Text == "" ? "100000" : textBox1.Text))).ToList();

            //    }
                
            //}   
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //using (var context = new AppDbContext())
            //{


            //    if (status == "R")
            //    {
            //        dataGridView1.DataSource = context.RoomReservations.Include(x => x.Room).ThenInclude(x => x.Hotel).Where(x => x.Room.Hotel.Name == textBox3.Text).ToList();
            //    }
            //    else if (status == "F")
            //    {
            //        dataGridView1.DataSource = context.FlightReservations.Include(x => x.Flight).ThenInclude(x => x.Airline).Where(x => x.Flight.Airline.Name == textBox3.Text).ToList();

            //    }
            //}
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //using (var context = new AppDbContext())
            //{
            //    if (status == "R")
            //    {
            //        dataGridView1.DataSource = context.RoomReservations.Include(x => x.Room).ThenInclude(x => x.Hotel).Where(x => x.Room.Hotel.City == textBox4.Text).ToList();
            //    }
            //    else if (status == "F")
            //    {
            //        dataGridView1.DataSource = context.FlightReservations.Include(x => x.Flight).Where(x => x.Flight.Id == Convert.ToInt32(textBox4.Text)).ToList();
            //    }
            //}
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //using (var context = new AppDbContext())
            //{
            //    if (status == "R")
            //    {
            //        var roomTypeDict = new Dictionary<string, RoomType> {
            //            { "City", RoomType.CityView },
            //            { "Interior", RoomType.InteriorView },
            //            { "Private", RoomType.PrivateView },
            //            { "Deluxe", RoomType.DeluxeView },
            //        };
            //        dataGridView1.DataSource = context.RoomReservations.Include(x => x.Room).Where(x => x.Room.Type == roomTypeDict[textBox5.Text]).ToList();
            //    }
            //    else if (status == "F")
            //    {
            //        dataGridView1.DataSource = context.FlightReservations.Where(x => x.FromCity == textBox5.Text).ToList();
            //    }
            //}
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //using (var context = new AppDbContext())
            //{
            //    if (status == "R")
            //    {
            //        dataGridView1.DataSource = context.RoomReservations.Include(x => x.Room).Where(x => x.Room.Capicity == Convert.ToInt32(textBox6.Text)).ToList();
            //    }
            //    else if (status == "F")
            //    {
            //        dataGridView1.DataSource = context.FlightReservations.Where(x => x.ToCity == textBox6.Text).ToList();
            //    }
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Presentation_Layer.MainForm mainForm = new MainForm();
            Hide();
            mainForm.customer = this.customer;
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(var context = new AppDbContext())
            {
                if(status == "R")
                {
                    if(textBox1.Text != "")
                    {
                        dataGridView1.DataSource = context.RoomReservations.Where(x => x.Cost >= Convert.ToInt32((textBox2.Text == "" ? "0" : textBox2.Text))
                                                                             && x.Cost <= Convert.ToInt32((textBox1.Text == "" ? "100000" : textBox1.Text)) && x.CustomerId == null).ToList();
                    }
                    if (textBox2.Text != "")
                    {
                        dataGridView1.DataSource = context.RoomReservations.Where(x => x.Cost >= Convert.ToInt32((textBox2.Text == "" ? "0" : textBox2.Text))
                                                                             && x.Cost <= Convert.ToInt32((textBox1.Text == "" ? "100000" : textBox1.Text)) && x.CustomerId == null).ToList();
                    }
                    if (textBox3.Text != "")
                    {
                        dataGridView1.DataSource = context.RoomReservations.Include(x => x.Room).ThenInclude(x => x.Hotel).Where(x => x.Room.Hotel.Name == textBox3.Text && x.CustomerId == null).ToList();
                    }
                    if (textBox4.Text != "")
                    {
                        dataGridView1.DataSource = context.RoomReservations.Include(x => x.Room).ThenInclude(x => x.Hotel).Where(x => x.Room.Hotel.City == textBox4.Text && x.CustomerId == null).ToList();

                    }
                    if (textBox5.Text != "")
                    {
                        var roomTypeDict = new Dictionary<string, RoomType> {
                             { "City", RoomType.CityView },
                             { "Interior", RoomType.InteriorView },
                             { "Private", RoomType.PrivateView },
                             { "Deluxe", RoomType.DeluxeView },
                        };
                        dataGridView1.DataSource = context.RoomReservations.Include(x => x.Room).Where(x => x.Room.Type == roomTypeDict[textBox5.Text] && x.CustomerId == null).ToList();
                    }
                    if (textBox6.Text != "")
                    {
                        dataGridView1.DataSource = context.RoomReservations.Include(x => x.Room).Where(x => x.Room.Capicity == Convert.ToInt32(textBox6.Text) && x.CustomerId == null).ToList();
                    }
                }
                else if (status == "F")
                {
                    if (textBox1.Text != "")
                    {
                        dataGridView1.DataSource = context.FlightReservations.Where(x => x.Cost >= Convert.ToDecimal((textBox2.Text == "" ? "0" : textBox2.Text))
                                                                             && x.Cost <= Convert.ToDecimal((textBox1.Text == "" ? "100000" : textBox1.Text)) && x.CustomerId == null).ToList();
                    }
                    if (textBox2.Text != "")
                    {
                        dataGridView1.DataSource = context.FlightReservations.Where(x => x.Cost >= Convert.ToDecimal((textBox2.Text == "" ? "0" : textBox2.Text))
                                                                             && x.Cost <= Convert.ToDecimal((textBox1.Text == "" ? "100000" : textBox1.Text)) && x.CustomerId == null).ToList();
                    }
                    if (textBox3.Text != "")
                    {
                        dataGridView1.DataSource = context.FlightReservations.Include(x => x.Flight).ThenInclude(x => x.Airline).Where(x => x.Flight.Airline.Name == textBox3.Text && x.CustomerId == null).ToList();
                    }
                    if (textBox4.Text != "")
                    {
                        dataGridView1.DataSource = context.FlightReservations.Include(x => x.Flight).Where(x => x.Flight.Id == Convert.ToInt32(textBox4.Text) && x.CustomerId == null).ToList();
                    }
                    if (textBox5.Text != "")
                    {
                        dataGridView1.DataSource = context.FlightReservations.Where(x => x.FromCity == textBox5.Text && x.CustomerId == null).ToList();
                    }
                    if (textBox6.Text != "")
                    {
                        dataGridView1.DataSource = context.FlightReservations.Where(x => x.ToCity == textBox6.Text && x.CustomerId == null).ToList();
                    }
                }
            }
        }
    }
}
