using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Model;

namespace ParkingLot.Interfaces
{
    internal interface ISlot
    {
        public bool InitializeSlots(string type,int size);

        public bool BookSlot(int slotNumber,string type);

        public int GetSlotsStatus(string type);

        public bool ClearSlot(int slotNumber);

        public int ViewVacantSlot(string type);
        
    }
}
