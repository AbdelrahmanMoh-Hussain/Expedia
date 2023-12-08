using Expedia.Entities;
using System.Data;
using Expedia.Data;
using Microsoft.EntityFrameworkCore;
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
            using (var context = new AppDbContext())
            {

                if (status == "R")
                {
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


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Presentation_Layer.MainForm mainForm = new MainForm();
            Hide();
            mainForm.customer = this.customer;
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
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
