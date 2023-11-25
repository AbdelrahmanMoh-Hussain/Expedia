using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.Business_Layer
{
    public abstract class Itinerary
    {
        protected Itinerary(string name, double period, decimal cost)
        {
            Name = name;
            Period = period;
            Cost = cost;
        }

        protected virtual string Name { get; set; }
        protected virtual double Period { get; set; }
        public virtual decimal Cost { get; set; }

        public override string ToString()
        {
            return $"{Name}"
                 + $"\nPeriod(Days): {Period}"
                 + $"\t[${Cost}]\n";
        }
    }
}
