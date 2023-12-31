﻿using Expedia.Data;
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
    public partial class AddCardForm : Form
    {
        public Customer customer;
        public AddCardForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var company = comboBox2.SelectedItem.ToString();
            var type = comboBox1.SelectedItem.ToString();
            var date = dateTimePicker1.Value;
            var number = textBox2.Text;
            var balance = Convert.ToDecimal(textBox1.Text);

            if(number.Length < 14)
            {
                MessageBox.Show("Card Number is not correct, please check again");
            }
            else if(date < DateTime.Now) 
            {
                MessageBox.Show("This card is expried");
            }
            else
            {
                MessageBox.Show("Card Added succesfully");
                using (var context = new AppDbContext())
                {
                    var bankCard = new BankCard
                    {
                        CardNumber = number,
                        Company = company,
                        Type = type == "Debit"? Enums.BankCardType.Debit: (type == "Credit"? Enums.BankCardType.Credit: Enums.BankCardType.Virtual),
                        ExpireDate = date,
                        Balance = balance,
                        CustomerId = customer.Id,
                    };
                    context.BankCards.Add(bankCard);
                    context.SaveChanges();
                }
                Hide();
            }
        }
    }
}
