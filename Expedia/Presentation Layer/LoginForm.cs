using Expedia.Entities;

using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Expedia.Data;

namespace Expedia.Presentation_Layer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Presentation_Layer.SignUpForm sighupForm = new SignUpForm();
            Hide();
            sighupForm.FormClosed += (s, args) => this.Close();
            using (var context = new AppDbContext()) {
                sighupForm.lastCustomerId = context.Customers.OrderBy(x => x.Id).Last().Id;
            }
             sighupForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(userName_txtbox.Text == "" || password_txtbox.Text == "")
            {
                MessageBox.Show("Please enter your login details first");
            }
            else
            {
                if (userName_txtbox.Text.Equals("admin", StringComparison.OrdinalIgnoreCase) || password_txtbox.Text.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    Hide();
                    AllocConsole();
                    Admin admin = new Admin();
                    while (true)
                    {
                        Console.WriteLine("[[Welcome Admin]]");
                        Console.WriteLine("1. Flight");
                        Console.WriteLine("2. Room");
                        Console.WriteLine("3. Reservation");
                        Console.WriteLine("4. Logout");
                        Console.WriteLine("Enter number in range [1-3]: ");
                        var key = Console.ReadLine();
                        if (key == "1")
                        {
                            while (true)
                            {
                                AdminMenu("Flight");
                                var key2 = Console.ReadLine();
                                if (key2 == "1")
                                {
                                    Console.Write("Enter Airplane Name: ");
                                    var airplaneName = Console.ReadLine();
                                    Console.Write("Enter to #Seats: ");
                                    var numberOfSeats = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Airline Id: ");
                                    var airlineId = Convert.ToInt32(Console.ReadLine());
                                    admin.AddFlight(airplaneName, numberOfSeats, airlineId);
                                }
                                else if (key2 == "2")
                                {
                                    Console.Write("Enter Flight Id: ");
                                    var id = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Airplane Name: ");
                                    var airplaneName = Console.ReadLine();
                                    Console.Write("Enter to #Seats: ");
                                    var numberOfSeats = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Airline Id: ");
                                    var airlineId = Convert.ToInt32(Console.ReadLine());
                                    admin.EditFlight(id, airplaneName, numberOfSeats, airlineId);
                                }
                                else if (key2 == "3")
                                {
                                    Console.Write("Enter reservition Id: ");
                                    var id = Convert.ToInt32(Console.ReadLine());
                                    admin.DeleteFlight(id);
                                }
                                else if (key2 == "4")
                                {
                                    break;
                                }
                            }
                        }
                        else if (key == "2")
                        {
                            while (true)
                            {
                                AdminMenu("Room");
                                var key2 = Console.ReadLine();
                                if (key2 == "1")
                                {
                                    Console.Write("Enter Room Type: ");
                                    var roomType = Console.ReadLine();
                                    Console.Write("Enter Capicity: ");
                                    var capicity = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Hotel Id: ");
                                    var hotelId = Convert.ToInt32(Console.ReadLine());

                                    admin.AddRoom(roomType, capicity, hotelId);
                                }
                                else if (key2 == "2")
                                {
                                    Console.Write("Enter Room Id: ");
                                    var id = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Room Type: ");
                                    var roomType = Console.ReadLine();
                                    Console.Write("Enter Capicity: ");
                                    var capicity = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Hotel Id: ");
                                    var hotelId = Convert.ToInt32(Console.ReadLine());

                                    admin.EditRoom(id, roomType, capicity, hotelId);
                                }
                                else if (key2 == "3")
                                {
                                    Console.Write("Enter reservition Id: ");
                                    var id = Convert.ToInt32(Console.ReadLine());
                                    admin.DeleteRoom(id);
                                }
                                else if (key2 == "4")
                                {
                                    break;
                                }
                            }
                        }
                        else if(key == "3")
                        {
                            Console.WriteLine("Fligt ==> f\nRoom ==> r");
                            var key2 = Console.ReadLine();
                            if(key2 == "f")
                            {
                                Console.Write("Enter Start Date: ");
                                var startDate = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("Enter End Date: ");
                                var endDate = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("Enter Cost: ");
                                var cost = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Enter From City: ");
                                var fromCity = Console.ReadLine();
                                Console.Write("Enter To City: ");
                                var toCity = Console.ReadLine();
                                Console.Write("Enter Flight Id: ");
                                var flightId = Convert.ToInt32(Console.ReadLine());

                                admin.AddAvaliableFlightReservation(startDate, endDate, cost,  fromCity, toCity, flightId);
                            }
                            else if(key2 == "r")
                            {
                                Console.Write("Enter Start Date: ");
                                var startDate = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("Enter End Date: ");
                                var endDate = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("Enter Cost: ");
                                var cost = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Enter Room Id: ");
                                var roomId = Convert.ToInt32(Console.ReadLine());

                                admin.AddAvaliableRoomReservation(startDate, endDate, cost,roomId);
                            }
                        }
                        else if (key == "4")
                        {
                            break;
                        }
                    }

                    Show();

                }
                else
                {
                    
                    Customer customer = null;
                    using(var context = new AppDbContext())
                    {
                        customer = context.Customers.First(x => x.UserName == userName_txtbox.Text && x.Password == password_txtbox.Text);
                    }

                    if (customer is null)
                    {
                        MessageBox.Show("Wrong username or password, please try again");
                    }
                    else
                    {
                        Presentation_Layer.MainForm mainForm = new MainForm();
                        Hide();
                        mainForm.customer = customer;
                        mainForm.FormClosed += (s, args) => this.Close();
                        mainForm.Show();
                    }
                }
            }
        }

        private void AdminMenu(string section)
        {
            Console.WriteLine($"[[You are in {section} section]]");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Edit");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Return back");
            Console.WriteLine("Enter number in range [1-4]: ");
        }


        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        

    }
}
