using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<Reservation>? Reservations { get; set; }

        public List<BankCard>? BankCards { get; set; }

    }
}
