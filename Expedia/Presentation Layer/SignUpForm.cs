using Expedia.Data;
using Expedia.Entities;
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
    public partial class SignUpForm : Form
    {

        public int lastCustomerId;
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Presentation_Layer.LoginForm loginForm = new LoginForm();
            Hide();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(password_txtbox.Text.Equals(confirmPassword_txtbox.Text, StringComparison.OrdinalIgnoreCase))
            {
                using(var context = new AppDbContext())
                {
                    var id = (context.Customers.OrderBy(x => x.Id).Last().Id + 1);
                    var customer = new Customer
                    {
                        Id = id,
                        Name = name_txtbox.Text,
                        UserName = userName_txtbox.Text,
                        Password = password_txtbox.Text,
                    };
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }

                Presentation_Layer.MainForm mainForm = new MainForm();
                Hide();
                mainForm.FormClosed += (s, args) => this.Close();
                using (var context = new AppDbContext())
                {
                    mainForm.customer = context.Customers.OrderBy(x => x.Id).Last();
                }
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("The passwords doesn't match, please enter the password again");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
