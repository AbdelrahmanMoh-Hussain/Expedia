using Expedia.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.Entities
{
    public class BankCard
    {
        public string CardNumber { get; set; }
        public string Company { get; set; }
        public BankCardType Type { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Balance { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
