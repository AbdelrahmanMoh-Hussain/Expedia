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
                Data_Access_Layer.DataAccessor dataAccessor = new Data_Access_Layer.DataAccessor();
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("name", name_txtbox.Text);
                parameters[1] = new SqlParameter("userName", userName_txtbox.Text);
                parameters[2] = new SqlParameter("password", password_txtbox.Text);
                dataAccessor.Open();
                dataAccessor.Execute("AddCustomer", parameters);
                dataAccessor.Close();

                Presentation_Layer.MainForm mainForm = new MainForm();
                Hide();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.customer = new Business_Layer.Customer(++lastCustomerId, name_txtbox.Text, userName_txtbox.Text, password_txtbox.Text);
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
