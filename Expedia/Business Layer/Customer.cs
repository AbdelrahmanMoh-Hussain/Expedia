using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.Business_Layer
{
    public class Customer
    {
        public Customer(int id, string name, string userName, string password)
        {
            Id = id;
            Name = name;
            UserName = userName;
            Password = password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
