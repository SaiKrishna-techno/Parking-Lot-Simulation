using ParkingLot.Interfaces;
using ParkingLot.Model;
using ParkingLot.Views;
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

      
        public List<Slot> allSlots= new List<Slot>();


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

        
        public int  GetSlotsStatus(string type)
        {
           return this.VacantSlots(type);
        }

       
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
        

        public int ViewVacantSlot(string type)
        {
        for(int i = 0; i < allSlots.Count; i++)
        {       
                if (allSlots[i].slotType==type && allSlots[i].isOccupied == false)
                {
                    return i;
                }
        }
        return -1;
        }

       
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
