using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Model
{
    internal class Ticketclass 
    {
        public int slotNumber;
        public int ticketId;
        public string vehicleNumber;
        public string inTime;
        public string outTime;

        public Ticketclass(int slotNumber,int ticketId, string vehicleNumber, string inTime, string outTime)
        {
            this.slotNumber = slotNumber;
            this.ticketId = ticketId;
            this.vehicleNumber = vehicleNumber;
            this.inTime = inTime;
            this.outTime = outTime;
        }
    }
}
