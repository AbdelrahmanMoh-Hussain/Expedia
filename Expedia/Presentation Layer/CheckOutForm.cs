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
using Expedia.Data;

namespace Expedia.Presentation_Layer
{
    public partial class CheckOutForm : Form
    {
        public Customer customer;
        public List<Reservation> selectedReservations = new List<Reservation>();

        public CheckOutForm()
        {
            InitializeComponent();
        }

        private void CheckOutForm_Load(object sender, EventArgs e)
        {
            using(var context = new AppDbContext())
            {
                var quary = from b in context.BankCards
                            where b.CustomerId == customer.Id
                            select new
                            {
                                customer.Name,
                                b.CardNumber,
                                b.Company,
                                b.Type,
                                b.ExpireDate,
                                b.Balance
                            };
                dataGridView1.DataSource = quary.ToList();
            }
            
            foreach(var reservation in selectedReservations.Select(x => x.ToString()))
            {
                richTextBox1.Text += $"\u2023 {reservation}";
            }
            richTextBox1.Text += "\n---------------------\n";
            richTextBox1.Text += $"Total Cost: {selectedReservations.Sum(x => x.Cost)}";

            var cardCompany = dataGridView1.Rows[0].Cells["Company"].Value.ToString();
            var cardType = dataGridView1.Rows[0].Cells["Type"].Value.ToString();
            var cardNum = dataGridView1.Rows[0].Cells["CardNumber"].Value.ToString();
            var balance = dataGridView1.Rows[0].Cells["Balance"].Value.ToString();
            company.Text = cardCompany;
            type.Text = $"- {cardType} Card";
            num.Text = cardNum;
            balance_label.Text = $"Balance: $ {balance}";
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

                using (var context = new AppDbContext())
                {
                    var bankCard = context.BankCards.Single(x => x.CardNumber == num.Text && x.Company == company.Text);
                    bankCard.Balance = balance;

                    foreach(var reservation in selectedReservations)
                    {
                        context.Attach(reservation);
                        reservation.CustomerId = customer.Id;
                    }

                    context.SaveChanges();

                    selectedReservations.Clear();
                }
            }
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
        }

        private void CheckOutForm_Activated(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                var quary = from b in context.BankCards
                            where b.CustomerId == customer.Id
                            select new
                            {
                                customer.Name,
                                b.CardNumber,
                                b.Company,
                                b.Type,
                                b.ExpireDate,
                                b.Balance
                            };
                dataGridView1.DataSource = quary.ToList();
            }
        }
    }
}
