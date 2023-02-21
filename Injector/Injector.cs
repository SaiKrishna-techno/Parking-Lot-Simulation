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
        public IPark park;

        //Constructor for the Injector
        public Injector(ISlot slot, ITicket ticket, IPark park)
        {
            this.slot = slot;
            this.ticket = ticket;
            this.park = park;
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

        public bool ClearSlot(int slotNumber,string type)
        {
           return this.slot.ClearSlot(slotNumber,type);
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

        public int DeleteTicket(int ticketId,string type)
        {
           return this.ticket.DeleteTicket(ticketId,type);
        }

        public bool CreateTicket(Ticket ticket,string type)
        {
             return this.ticket.CreateTicket(ticket,type);
        }

        // Methods of Parking Service

        public void ParkVehicle()
        {
            this.park.ParkVehicle();
        }

        public void UnparkVehicle()
        {
            this.park.UnParkVehicle();
        }

    }
}
