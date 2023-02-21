using ParkingLot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    internal interface ITicket
    {
        public bool CreateTicket(Ticket ticket,string type);
        public int DeleteTicket(int ticketId);
    }
}
