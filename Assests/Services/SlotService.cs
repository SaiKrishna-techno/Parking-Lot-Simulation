using Newtonsoft.Json.Linq;
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

       public  List<Slot> TwoWheelerSlots = new List<Slot>();
       public  List<Slot> FourWheelerSlots = new List<Slot>();
       public  List<Slot> HeavyVehicleSlots = new List<Slot>();


        public bool BookSlot(int slotNumber,string type)
        {
            if (type == "TwoWheeler")
            {
              
                this.TwoWheelerSlots[slotNumber].isOccupied=true;
                return true;
            }
            if (type=="FourWheeler")
            {
                this.FourWheelerSlots[slotNumber].isOccupied=true;
                return true;
            }
            if (type == "HeavyVehicle")
            {
                this.HeavyVehicleSlots[slotNumber].isOccupied=true;
                return true;
            }
            return false;
        }

        public bool ClearSlot(int slotNumber,string type)
        {
             if (type == "TwoWheeler")
            {
                this.TwoWheelerSlots[slotNumber].isOccupied=false;
                return true;
            }
            else if (type=="FourWheeler")
            {
                this.FourWheelerSlots[slotNumber].isOccupied=false;
                return true;
            }
            else if (type == "HeavyVehicle")
            {
                this.HeavyVehicleSlots[slotNumber].isOccupied=false;
                return true;
            }
            return false;
            
        }

        public int  GetSlotsStatus(string type)
        {
            if(type == "TwoWheeler")
            {
              return this.VacantSlots(TwoWheelerSlots);
            }
            if(type == "FourWheeler")
            {
                return this.VacantSlots(FourWheelerSlots);
            }
            if (type == "HeavyVehicle")
            {
                return this.VacantSlots(HeavyVehicleSlots);
            }
            return -1;
        }
       
        public bool InitializeSlots(string type,int size)
        {
            if (type == "TwoWheelerSlots")
            {
              this.CommenceSlots(TwoWheelerSlots,size,type);
              if (this.TwoWheelerSlots.Count == size)
              {
                    return true;
              }
              return false;
               
            }

            if(type == "FourWheelerSlots")
            {
               this.CommenceSlots(FourWheelerSlots,size,type);
               if (this.FourWheelerSlots.Count == size)
               {
                    return true;
               }
                return false;
             }

             if (type == "HeavyVehicleSlots"){
                
                   this.CommenceSlots(HeavyVehicleSlots,size,type);

                   if (this.HeavyVehicleSlots.Count == size)
                   {
                     return true;
                   }
                return false;
                
            }
            return false;
          
            
        }

        public int ViewVacantSlot(string type)
        {
            if (type == "TwoWheeler")
            {
                 return this.ReturnVacantSlot(TwoWheelerSlots);
            }
            if  (type == "FourWheeler"){
                return this.ReturnVacantSlot(FourWheelerSlots);
            }
             if (type == "HeavyVehicle") { 
               return this.ReturnVacantSlot(HeavyVehicleSlots);
            }
            return -1;
        }

        public int ReturnVacantSlot(List<Slot> Slot)
        {
            try { 
            int slotNumber = Slot.Where(n=>n.isOccupied==false)
                .Select(n=>n.slotNumber)
                .First();
                return slotNumber;
            }
            catch(Exception e)
            {
                return -1;
            }
        }

        public void CommenceSlots(List<Slot> SlotToBeCommenced,int Size,String type)
        {
            for(int i = 0; i < Size; i++)
            {
                 Slot tempSlot= new Slot();
                 tempSlot.isOccupied=false;
                 tempSlot.slotNumber=i;
                 tempSlot.slotType=type;
                SlotToBeCommenced.Add(tempSlot);
            }
        }

        public int VacantSlots(List<Slot> targetSlots)
        {
            int  vacantSlotCount=targetSlots.Where(n=>n.isOccupied==false).Count();
            return vacantSlotCount;
        }
    }
}
