using Newtonsoft.Json.Linq;
using ParkingLot.Interfaces;
using ParkingLot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Services
{
    internal class SlotService : ISlot
    {
        public void BookSlot()
        {
            Console.WriteLine("Inside Book Slot function");
        }

        public void ClearSlot(int slotNumber)
        {
            throw new NotImplementedException();
        }

        public void  GetSlots(string type)
        {
            string json = File.ReadAllText("C:\\Users\\ivsds\\source\\repos\\ParkingLot\\Assests\\Slots.json");

            JObject obj = JObject.Parse(json);
            List<Slot> slotss = obj[type].ToObject<List<Slot>>();
            Console.WriteLine(slotss.Count);
            foreach(Slot s in slotss)
            {
                Console.WriteLine($"{s.slotNumber},{s.slotType},{s.isOccupied}");
            }


        }

        public void InitializeSlots(string type, int size)
        {
            string json = File.ReadAllText(".\\.\\Assests\\Slots.json");
            JObject jsonObject= JObject.Parse(json);

           
            for(int i = 0; i < size; i++)
            {
                jsonObject[type].Last.AddAfterSelf(new JObject(
                    new JProperty("slotType",type),
                    new JProperty("slotNumber",i),
                    new JProperty("isOccupied",false)
                    ));
                Console.WriteLine("Added");
            }

            string updatedJsonObject=json.ToString();
            File.WriteAllText("C:\\Users\\ivsds\\source\\repos\\ParkingLot\\Assests\\Slots.json",updatedJsonObject);

            Console.WriteLine($"Slots of {type} have been initialised successfully");
          
            
        }

        public int ViewVacantSlot()
        {
            throw new NotImplementedException();
        }
    }
}
