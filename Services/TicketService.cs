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
        public SlotService slot=new SlotService();
        public List<Ticket> TwoWheelerTickets= new List<Ticket>();
        public List<Ticket> FourWheelerTickets= new List<Ticket>();
        public List<Ticket> HeavyVehicleTickets= new List<Ticket>();

        public int DeleteTicket(int ticketIds,string type)
        {
            if (type == "TwoWheeler")
            {
              
              int status= this.RemoveTicket(TwoWheelerTickets,ticketIds);
                if (status!=-1)
                {
                   
                     return status;
                }
            }
            if (type == "FourWheeler")
            {
               int status= this.RemoveTicket(FourWheelerTickets,ticketIds);
                if (status!=-1)
                {
                   
                     return status;
                }
             
            }
            if (type == "HeavyVehicle")
            {
               int status= this.RemoveTicket(HeavyVehicleTickets,ticketIds);
                if (status!=-1)
                {  
                     return status;
                }
            }
            return -1;
        }

        public bool CreateTicket(Ticket ticket,string type)
        {
            
            if (type == "TwoWheeler")
            {
                this.TwoWheelerTickets.Add(ticket);
                return true;
            }
            else if (type == "FourWheeler")
            {
                this.FourWheelerTickets.Add(ticket);
                return true;
            }
            else if (type == "HeavyVehicle")
            {
                this.HeavyVehicleTickets.Add(ticket);
                return true;
            }
            return false;
        }

        public int RemoveTicket(List<Ticket> ticketList,int ticketId)
        {

            try
            {
                Ticket deletingTicket=ticketList.
                    Where(n=>n.ticketId==ticketId)
                    .Select(n=>n)
                    .First();

               ticketList.Remove(deletingTicket);
                return deletingTicket.slotNumber;
            }
            catch
            {
                return -1;
            }
        }
    }
}
