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
    public partial class CheckOutForm : Form
    {
        public Customer customer;
        public List<Itinerary> selectedReservations = new List<Itinerary>();

        public CheckOutForm()
        {
            InitializeComponent();
        }

        private void CheckOutForm_Load(object sender, EventArgs e)
        {
            DataAccessor dataAccessor = new DataAccessor();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Id",  customer.Id);
            DataTable dt = dataAccessor.Read("LoadBankCards", parameters);
            dataGridView1.DataSource = dt;
            
            foreach(var reservation in selectedReservations.Select(x => x.ToString()))
            {
                richTextBox1.Text += $"\u2023 {reservation}";
            }
            richTextBox1.Text += "\n---------------------\n";
            richTextBox1.Text += $"Total Cost: {selectedReservations.Sum(x => x.Cost)}";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cardCompany = dataGridView1.Rows[e.RowIndex].Cells["Company"].Value.ToString();
            var cardType = dataGridView1.Rows[e.RowIndex].Cells["Type"].Value.ToString();
            var cardNum = dataGridView1.Rows[e.RowIndex].Cells["CardNumber"].Value.ToString();
            var balance = dataGridView1.Rows[e.RowIndex].Cells["Balance"].Value.ToString();
            company.Text = cardCompany;
            type.Text = $"- {cardType} Card";
            num.Text = cardNum;
            balance_label.Text = $"Balance: $ {balance}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var balance = Convert.ToDecimal(balance_label.Text.Split()[2]);
            var totalCost = selectedReservations.Sum(x => x.Cost);
            if (balance < totalCost)
            {
                status_label.ForeColor = Color.Red;
                status_label.Text = "Reservation Faild\nYour balance is not enough";
            }
            else
            {
                status_label.ForeColor = Color.Green;
                status_label.Text = "Reservation Confirmed\nMoney withdraw successfuly";

                balance -= totalCost;
                balance_label.Text = $"Balance: $ {balance}";

                DataAccessor dataAccessor = new DataAccessor();
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("cardNumber", num.Text);
                parameters[1] = new SqlParameter("company", company.Text);
                parameters[2] = new SqlParameter("balance", balance.ToString());
                

                dataAccessor.Open();
                dataAccessor.Execute("EditBankCardBalance", parameters);
                dataAccessor.Close();
            }
        }

        private void status_label_Click(object sender, EventArgs e)
        {

        }

        private void type_Click(object sender, EventArgs e)
        {

        }

        private void num_Click(object sender, EventArgs e)
        {

        }

        private void company_Click(object sender, EventArgs e)
        {

        }

        private void reservations_Click(object sender, EventArgs e)
        {

        }

        private void balance_label_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Returning will delete your list of reservations");
            Presentation_Layer.MainForm mainForm = new MainForm();
            Hide();
            mainForm.customer = this.customer;
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Presentation_Layer.AddCardForm cardForm = new AddCardForm();
            cardForm.customer = this.customer;
            cardForm.Show();
            this.FormClosed += (s, arg) => cardForm.Close();

            DataAccessor dataAccessor = new DataAccessor();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Id", customer.Id);
            DataTable dt = dataAccessor.Read("LoadBankCards", parameters);
            dataGridView1.DataSource = dt;

        }
    }
}
