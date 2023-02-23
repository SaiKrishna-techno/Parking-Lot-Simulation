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
     
        //We Will be Storing All The Tickets Here in this List
        public List<Ticket> allTickets= new List<Ticket>();

        // Method to Delete the Ticket from the List based on the TicketIDs
        public int DeleteTicket(int ticketIds)
        {
            try
            {
                Ticket ticket = allTickets.Where(x => x.ticketId == ticketIds).First();
                allTickets.Remove(ticket);
                return ticket.slotNumber;
            }
            catch { 
            return -1;
            }

          
        }

        // Method to Add the Ticket To the List 
        public bool CreateTicket(Ticket ticket)
        { 
            allTickets.Add(ticket);
            return true;
        }
       
    }
}
