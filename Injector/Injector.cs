using ParkingLot.Interfaces;
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
        public void  BookSlot()
        {
            this.slot.BookSlot();
        }

        public void ViewVacantSlot()
        {
            this.slot.ViewVacantSlot();
        }

        public void ClearSlot(int k)
        {
            this.slot.ClearSlot(k);
        }

        public void GetSlots(string type)
        {
            this.slot.GetSlots(type);
        }

        public void InitializeSlots(string type,int size)
        {
            this.slot.InitializeSlots(type,size);
        }

        //Methods of Ticket Service

        public void DeleteTicket(int k)
        {
            this.ticket.DeleteTicket(k);
        }

        public void TakeTicketInfo()
        {
            this.ticket.TakeTicketInfo();
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
