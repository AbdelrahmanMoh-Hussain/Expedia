using Expedia.Business_Layer;
using Expedia.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expedia.Presentation_Layer
{
    public partial class LoginForm : Form
    {
        private DataTable dt;
        DataAccessor dataAccessor = new DataAccessor();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SqlParameter[] parameters = null;
            dt = dataAccessor.Read("LoadCustomers", parameters);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Presentation_Layer.SignUpForm sighupForm = new SignUpForm();
            Hide();
            sighupForm.FormClosed += (s, args) => this.Close();
            sighupForm.lastCustomerId = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["Id"]);
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
                        Console.WriteLine("1. Flight Reservation");
                        Console.WriteLine("2. Room Reservation");
                        Console.WriteLine("3. Logout");
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
                                    Console.Write("Enter from city: ");
                                    var fromCity = Console.ReadLine();
                                    Console.Write("Enter to city: ");
                                    var toCity = Console.ReadLine();
                                    Console.Write("Enter start date: ");
                                    var startDate = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("Enter end date: ");
                                    var endDate = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("Enter cost: ");
                                    var cost = Console.ReadLine();
                                    Console.Write("Enter airline name: ");
                                    var airline = Console.ReadLine();
                                    Console.Write("Enter airplane number: ");
                                    var ailplane = Convert.ToInt32(Console.ReadLine());
                                    admin.AddFlightReservation(fromCity, toCity, startDate, endDate, cost, airline, ailplane);
                                }
                                else if (key2 == "2")
                                {
                                    Console.Write("Enter reservition Id: ");
                                    var id = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter from city: ");
                                    var fromCity = Console.ReadLine();
                                    Console.Write("Enter to city: ");
                                    var toCity = Console.ReadLine();
                                    Console.Write("Enter start date: ");
                                    var startDate = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("Enter end date: ");
                                    var endDate = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("Enter cost: ");
                                    var cost = Console.ReadLine();
                                    Console.Write("Enter airline name: ");
                                    var airline = Console.ReadLine();
                                    Console.Write("Enter airplane number: ");
                                    var ailplane = Convert.ToInt32(Console.ReadLine());
                                    admin.EditFlightReservation(id, fromCity, toCity, startDate, endDate, cost, airline, ailplane);
                                }
                                else if (key2 == "3")
                                {
                                    Console.Write("Enter reservition Id: ");
                                    var id = Convert.ToInt32(Console.ReadLine());
                                    admin.DeleteFlightReservation(id);
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
                                    Console.Write("Enter room number: ");
                                    var roomNumber = Console.ReadLine();
                                    Console.Write("Enter hotel name: ");
                                    var hotel = Console.ReadLine();
                                    Console.Write("Enter start date: ");
                                    var startDate = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("Enter end date: ");
                                    var endDate = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("Enter cost: ");
                                    var cost = Console.ReadLine();
                                    admin.AddRoomReservation(roomNumber, hotel, startDate, endDate, cost);
                                }
                                else if (key2 == "2")
                                {
                                    Console.Write("Enter reservition Id: ");
                                    var id = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter room number: ");
                                    var roomNumber = Console.ReadLine();
                                    Console.Write("Enter hotel name: ");
                                    var hotel = Console.ReadLine();
                                    Console.Write("Enter start date: ");
                                    var startDate = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("Enter end date: ");
                                    var endDate = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("Enter cost: ");
                                    var cost = Console.ReadLine();
                                    admin.EditRoomReservation(id, roomNumber, hotel, startDate, endDate, cost);
                                }
                                else if (key2 == "3")
                                {
                                    Console.Write("Enter reservition Id: ");
                                    var id = Convert.ToInt32(Console.ReadLine());
                                    admin.DeleteRoomReservation(id);
                                }
                                else if (key2 == "4")
                                {
                                    break;
                                }
                            }
                        }
                        else if (key == "3")
                        {
                            break;
                        }
                    }

                    Show();

                }
                else
                {
                    
                    Customer customer = null;
                    bool customerFound = false;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["UserName"].ToString().ToLower() == userName_txtbox.Text.ToLower() && dt.Rows[i]["Password"].ToString() == password_txtbox.Text)
                        {
                            customerFound = true;
                            customer = new Customer(Convert.ToInt32(dt.Rows[i]["Id"]), dt.Rows[i]["Name"].ToString(), dt.Rows[i]["UserName"].ToString(), dt.Rows[i]["Password"].ToString());
                            break;
                        }
                    }
                    if (!customerFound)
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
