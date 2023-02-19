using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    internal interface ISlot
    {
        public void InitializeSlots(string type,int size);
        public void BookSlot();

        public void GetSlots(string type);
        public void ClearSlot(int slotNumber);

        public int ViewVacantSlot();
    }
}
