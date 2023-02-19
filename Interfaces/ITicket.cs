using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    internal interface ITicket
    {
        public void TakeTicketInfo();
        public void DeleteTicket(int ticketId);
    }
}
