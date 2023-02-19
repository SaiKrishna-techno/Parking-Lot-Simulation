using ParkingLot.Injector;
using ParkingLot.Interfaces;
using ParkingLot.Model;
using ParkingLot.Services;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using static System.Reflection.Metadata.BlobBuilder;
using System.Security.Cryptography.X509Certificates;

namespace Parkinglot
{
    class ParkingLot
    {
         static void Main()
        {
            
                 Console.WriteLine("Please enter the number of Two Wheeler slots");
                 int numberOfTwoWheelerSlots = Convert.ToInt32(Console.ReadLine());

                 Console.WriteLine("Please enter the number of Four Wheeler slots");
                 int numberOfFourWheelerSlots = Convert.ToInt32(Console.ReadLine());

                 Console.WriteLine("Please enter the number of Heavy Vehicle  slots");
                 int numberOfHeavyVehicleSlots = Convert.ToInt32(Console.ReadLine());

             
                 ISlot slot = new SlotService();
                 ITicket ticket = new TicketService();
                 IPark park = new ParkingService();

            Injector injector= new Injector(slot, ticket, park);

            injector.InitializeSlots("TwoWheelerSlots", numberOfTwoWheelerSlots);
            injector.InitializeSlots("FourWheelerSlots", numberOfFourWheelerSlots);
            injector.InitializeSlots("HeavyVehicleSlots", numberOfHeavyVehicleSlots);


            while (true) 
            {
                Console.WriteLine("Enter the type of vehicle\n Enter 1 to Unpark \n Enter 2 for 2 wheeler \n Enter 3 for 4 wheeler \n Enter 4 for Heavy Vehicle \n Enter 0 to Exit");
                int userOption = Convert.ToInt32(Console.ReadLine());

                if(userOption == 1)
                {
                    
                }
                else if (userOption == 2)
                {
                    

                }
            }
                
             

            
            

           /* var slots = File.ReadAllText("C:\\Users\\ivsds\\source\\repos\\ParkingLot\\Assests\\Slots.json");
            var allslots = JsonConvert.DeserializeObject<List<Slot>>(slots);
            Console.WriteLine(allslots[0].slotNumber);
            var tempslot=allslots[0];
            tempslot.slotNumber = 99;
            Console.WriteLine(tempslot.slotNumber);
            Console.WriteLine(allslots[0].slotNumber);
            var k = JsonConvert.SerializeObject(tempslot);
            Console.WriteLine(k);
            StreamWriter writer = new StreamWriter("C:\\Users\\ivsds\\source\\repos\\ParkingLot\\Assests\\Slots.json");
            writer.Write(k);
            var slotss = File.ReadAllText("C:\\Users\\ivsds\\source\\repos\\ParkingLot\\Assests\\Slots.json");
            var allfslots = JsonConvert.DeserializeObject<List<Slot>>(slots);
            Console.WriteLine(allfslots[0].slotNumber);

            Console.WriteLine(allslots[0].slotNumber);*/


        }
    }
}
