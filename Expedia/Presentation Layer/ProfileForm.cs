using Expedia.Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expedia.Presentation_Layer
{
    public partial class ProfileForm : Form
    {
        public Customer customer;
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            label1.Text = customer.Name;
            label2.Text = customer.UserName;
            label3.Text = customer.Password;
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
            Presentation_Layer.MainForm mainForm = new MainForm();
            Hide();
            mainForm.customer = this.customer;
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }
    }
}
