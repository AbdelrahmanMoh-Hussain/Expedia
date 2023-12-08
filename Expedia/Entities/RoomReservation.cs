using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Expedia.Entities
{
    public class RoomReservation: Reservation
    {

        public int RoomId { get; set; }
        public Room Room { get; set; }
        
    }
}
