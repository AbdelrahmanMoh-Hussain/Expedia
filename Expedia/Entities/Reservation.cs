using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.Entities
{
    public abstract class Reservation
    {
        public int Id { get; set; }
        public Period Period { get; set; }
        public decimal Cost { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public override string ToString()
        {
            return $"{Id}\t"
                 + $"{Period}\t"
                 + $"{Cost:C}\t"
                 + $"   {CustomerId}\n";
        }
    }

    public class Period 
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return $"{StartDate.ToString("MM-dd")} - {EndDate.ToString("MM-dd")}";
        }
    }
}