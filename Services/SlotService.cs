using ParkingLot.Interfaces;
using ParkingLot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    internal class SlotService : ISlot
    {

      // List to Store All Types of Slots
        public List<Slot> allSlots= new List<Slot>();

        // Method which Books the Slot and CHnages its Status
        public bool BookSlot(int slotNumber,string type)
        {
        
          for(int i = 0; i < allSlots.Count; i++)
          {
                if (allSlots[i].slotType==type && allSlots[i].slotNumber == slotNumber)
                {
                    allSlots[i].isOccupied=true;
                    return true;
                }

          }
            return false;
        }
        
        //Method Which CLears The SLot and Changes Its status
        public bool ClearSlot(int slotNumber)
        {

            for(int i = 0; i < allSlots.Count; i++)
            {
                if ( allSlots[i].slotNumber == slotNumber)
                {
                    allSlots[i].isOccupied=false;
                    return true;
                }

            }
            return false;
        }

        // Method to Get the SLot status of the Specified type of Slot
        public int  GetSlotsStatus(string type)
        {
           return this.VacantSlots(type);
        }

       //Method That Initializes the Slots
        public bool InitializeSlots(string type,int size)
        {
            int beforeCommencing=this.allSlots.Count;
            this.CommenceSlots(size,type);
            int afterCommencing=this.allSlots.Count;
            if (afterCommencing-beforeCommencing == size)
            {
                return true;
            }
            return false; 
        }
        
        // Method Which Returns the Vacant Slot 
        public int ViewVacantSlot(string type)
        {
            try
            {
                int i = allSlots.Where(x => x.slotType == type && x.isOccupied==false).Select(x => x.slotNumber).First();
                return i;
            } catch (Exception e)
            {
                return -1;
            }
      
        }

       // Method which Creates the Slots and Adds to The List 
        public void CommenceSlots(int Size,string type)
        {
            int previousSlotCount=this.allSlots.Count;
            for(int i = previousSlotCount; i < previousSlotCount+Size; i++)
            {
                 Slot tempSlot= new Slot();
                 tempSlot.slotNumber=i;
                 tempSlot.slotType=type;
                 this.allSlots.Add(tempSlot);
            }
        }

        // Returns the Number of Vacant Slots in that particular Type
        public int VacantSlots(string type)
        {
            try { 
                int  vacantSlotCount=allSlots.
                Where(n=>n.slotType==type && n.isOccupied==false)
                .Select(n=>n)
                .Count();
                return vacantSlotCount;
                }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
