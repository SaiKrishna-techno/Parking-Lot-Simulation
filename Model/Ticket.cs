using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Model
{
    internal interface iTicket
    {
        public string ticketId { get; set; }
        public string vehicleNumber { get; set; }

        public string inTime { get; set; }

        public string outTime { get; set; }
    }
}
