using Expedia.Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expedia.Presentation_Layer
{
    public partial class MainForm : Form
    {
        public Customer customer;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Presentation_Layer.ReservationForm reservationForm = new Presentation_Layer.ReservationForm();
            reservationForm.status = "F";
            reservationForm.customer = this.customer;
            Hide();
            reservationForm.FormClosed += (s, args) => this.Close();
            reservationForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentation_Layer.ReservationForm reservationForm = new Presentation_Layer.ReservationForm();
            reservationForm.status = "R";
            reservationForm.customer = this.customer;
            Hide();
            reservationForm.FormClosed  +=(s, args) => this.Close();
            reservationForm.Show();
        }

        private void ShowProfile_label_Click(object sender, EventArgs e)
        {
            Presentation_Layer.ProfileForm profileForm = new ProfileForm();
            profileForm.customer = this.customer;
            Hide();
            profileForm.FormClosed += (s, args) => this.Close();
            profileForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Presentation_Layer.ProfileForm profileForm = new ProfileForm();
            profileForm.customer = this.customer;
            Hide();
            profileForm.FormClosed += (s, args) => this.Close();
            profileForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Presentation_Layer.LoginForm loginFrom = new LoginForm();
            Hide();
            loginFrom.FormClosed += (s, args) => this.Close();
            loginFrom.Show();
        }
    }
}
