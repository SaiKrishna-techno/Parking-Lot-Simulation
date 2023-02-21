using ParkingLot.Interfaces;
using ParkingLot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Injector
{
    internal class Injector 
    {
        public ISlot slot;
        public ITicket ticket;

        //Constructor for the Injector
        public Injector(ISlot slot, ITicket ticket)
        {
            this.slot = slot;
            this.ticket = ticket;
        }

        // Methods of SlotService
        public bool  BookSlot(int slotNumber,string type)
        {
          return   this.slot.BookSlot(slotNumber,type);
        }

        public int ViewVacantSlot( string type)
        {
           return this.slot.ViewVacantSlot(type);
            
        }

        public bool ClearSlot(int slotNumber)
        {
           return this.slot.ClearSlot(slotNumber);
        }

        public int GetSlotsStatus(string type)
        {
             return this.slot.GetSlotsStatus(type);
        }

        public bool InitializeSlots(string type,int size)
        {
             return this.slot.InitializeSlots(type,size);
        }

       

        //Methods of Ticket Service

        public int DeleteTicket(int ticketId)
        {
           return this.ticket.DeleteTicket(ticketId);
        }

        public bool CreateTicket(Ticket ticket,string type)
        {
             return this.ticket.CreateTicket(ticket,type);
        }

        

    }
}
