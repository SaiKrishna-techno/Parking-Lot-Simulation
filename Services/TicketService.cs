using ParkingLot.Interfaces;
using ParkingLot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    internal class TicketService : ITicket
    {
       
        public List<Ticket> allTickets= new List<Ticket>();

        public int DeleteTicket(int ticketIds)
        {

            for(int i = 0; i < allTickets.Count; i++)
            {
                if (allTickets[i].ticketId==ticketIds)
                {
                    var tempTicket=allTickets[i].slotNumber;
                    allTickets.RemoveAt(i);
                    return tempTicket;
                }
            }
            return -1;
        }

        public bool CreateTicket(Ticket ticket,string type)
        {

            if(type=="TwoWheeler"||type=="FourWheeler" || type == "HeavyVehicle")
            {
            allTickets.Add(ticket);
            return true;
            }
            return false;
        }
       
    }
}
