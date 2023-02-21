using ParkingLot.Injector;
using ParkingLot.Interfaces;
using ParkingLot.Model;
using ParkingLot.Services;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using static System.Reflection.Metadata.BlobBuilder;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

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

           bool twoWheelerSlotStatus= injector.InitializeSlots("TwoWheelerSlots", numberOfTwoWheelerSlots);
            bool fourWheelerSlotStatus= injector.InitializeSlots("FourWheelerSlots", numberOfFourWheelerSlots);
             bool heavyVehicleSlotStatus=injector.InitializeSlots("HeavyVehicleSlots", numberOfHeavyVehicleSlots);

            if (!twoWheelerSlotStatus|| !fourWheelerSlotStatus || !heavyVehicleSlotStatus)
            {
                Console.WriteLine("There has been an error in initializing the Slots");
            }
            else
            {
                Console.WriteLine("Successfully Initialiazed the slots");
            }
           




            while (true)
            {
                Console.WriteLine("\nOptions:\n Enter 1 to Unpark \n Enter 2 for 2 wheeler \n Enter 3 for 4 wheeler \n Enter 4 for Heavy Vehicle \n Enter 0 to Exit");
                int userOption = Convert.ToInt32(Console.ReadLine());

                if(userOption == 1)
                {
                    Console.WriteLine("Enter the type of vehicle\n Enter 1 for 2 wheeler \n Enter 2 for 4 wheeler \n Enter 3 for Heavy Vehicle \n Enter 0 to Exit");
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nPlease Enter the Ticket Id");
                    int ticketId=Convert.ToInt32(Console.ReadLine());
                    if(userInput == 1)
                    {
                     int ticketDeleteid=injector.DeleteTicket(ticketId,"TwoWheeler");
                      if (ticketDeleteid!=-1)
                      {
                           bool status= injector.ClearSlot(ticketDeleteid,"TwoWheeler");
                            if (status)
                            {
                                Console.WriteLine("Sucessfully CLeared Slot");
                                Console.WriteLine("Unparking Successful");

                            }
                            else
                            {
                                Console.WriteLine("Could not Clear SLot");
                            }
                           
                      }
                      else
                      {
                            Console.WriteLine("Unparking was UnSuccessful");
                      }
                      
                    }
                    else if (userInput == 2)
                    {
                         int ticketDeleteid=injector.DeleteTicket(ticketId,"FourWheeler");
                      if (ticketDeleteid!=-1)
                      {
                               bool status= injector.ClearSlot(ticketDeleteid,"FourWheeler");
                            if (status)
                            {
                                Console.WriteLine("Sucessfully CLeared Slot");
                                Console.WriteLine("Unparking Successful");

                            }
                            else
                            {
                                Console.WriteLine("Could not Clear SLot");
                            }
                            
                      }
                      else
                      {
                            Console.WriteLine("Unparking was UnSuccessful");
                      }
                    }
                    else if (userInput == 3)
                    {
                         int ticketDeleteid=injector.DeleteTicket(ticketId,"HeavyVehicle");
                      if (ticketDeleteid!=-1)
                      {
                            bool status= injector.ClearSlot(ticketDeleteid,"HeavyVehicle");
                            if (status)
                            {
                                Console.WriteLine("Sucessfully CLeared Slot");
                                Console.WriteLine("Unparking Successful");
                            }
                            else
                            {
                                Console.WriteLine("Could not Clear SLot");
                            }
                            
                      }
                      else
                      {
                            Console.WriteLine("Unparking was UnSuccessful");
                      }
                    }
                }
                else if (userOption == 2)
                {
                    
                    int  vacantSlot=injector.ViewVacantSlot("TwoWheeler");
                    if(vacantSlot == -1)
                    {
                        Console.WriteLine("Sorry No Vacant Slots");
                        continue;
                    }
                    else
                    {
                          Random random = new Random();
                          int ticketNumber=random.Next(1000,9999);
                          Console.WriteLine("Please Enter the Vehicle Number");
                          string vehicleId=Console.ReadLine();
                       

                         DateTime inTime=DateTime.Now;
                        Console.WriteLine("Enter the number of minutes you wish to Stay");
                        int duration= Convert.ToInt32(Console.ReadLine());
                        DateTime outTime=inTime.AddHours(duration/60).AddMinutes(duration%60);
                        
                          Ticket userticket = new Ticket(vacantSlot,ticketNumber,vehicleId,inTime.ToString("t"),outTime.ToString("t"));
                         bool ticketStatus=injector.CreateTicket(userticket,"TwoWheeler");
                        if (ticketStatus)
                        {
                            Console.WriteLine("Ticket Created successfully");
                            Console.WriteLine($"\nHere are your Ticket Details \n Slot Number : {userticket.slotNumber+1}\n Ticket Id : {userticket.ticketId} \nVehicle Number {userticket.vehicleNumber} \n Intime : {userticket.inTime} \n OutTime : {userticket.outTime} \n ");
                            Console.WriteLine($"\nPlease Go to Slot Number {userticket.slotNumber+1} to park your Vehicle");
                        }
                        else
                        {
                            Console.WriteLine("Ticket Could Not be Created");
                        }
                        bool slotStatus=injector.BookSlot(vacantSlot,"TwoWheeler");
                        if (slotStatus)
                        {
                            Console.WriteLine("Slot Booked Successfully");
                             int noOfVacantSlots=injector.GetSlotsStatus("TwoWheeler");
                            Console.WriteLine($"\n No of Vacant Slots : {noOfVacantSlots} \n No of Occupied Slots : {numberOfHeavyVehicleSlots-noOfVacantSlots} \n Total Number of Slots : {numberOfHeavyVehicleSlots}");
                        }
                        else
                        {
                            Console.WriteLine("Slot Could not be Booked");
                        }
                    }

                }
                else if(userOption == 3)
                {
                     int  vacantSlot=injector.ViewVacantSlot("FourWheeler");
                    if(vacantSlot == -1)
                    {
                        Console.WriteLine("Sorry No Vacant Slots");
                        continue;
                    }
                    else
                    {
                          Random random = new Random();
                          int ticketNumber=random.Next(1000,9999);
                          Console.WriteLine("Please Enter the Vehicle Number");
                          string vehicleId=Console.ReadLine();
                        

                         DateTime inTime=DateTime.Now;
                        Console.WriteLine("Enter the number of minutes you wish to Stay");
                        int duration= Convert.ToInt32(Console.ReadLine());
                        DateTime outTime=inTime.AddHours(duration/60).AddMinutes(duration%60);

                        Ticket userticket = new Ticket(vacantSlot,ticketNumber,vehicleId,inTime.ToString("t"),outTime.ToString("t"));
                         bool ticketStatus=injector.CreateTicket(userticket,"FourWheeler");
                        if (ticketStatus)
                        {
                            Console.WriteLine("Ticket Created successfully");
                             Console.WriteLine($"\nHere are your Ticket Details \n Slot Number : {userticket.slotNumber+1}\n Ticket Id : {userticket.ticketId} \nVehicle Number {userticket.vehicleNumber} \n Intime : {userticket.inTime} \n OutTime : {userticket.outTime} \n ");
                            Console.WriteLine($"\nPlease Go to Slot Number {userticket.slotNumber+1} to park your Vehicle");
                        }
                        else
                        {
                            Console.WriteLine("Ticket Could Not be Created");
                        }
                        bool slotStatus=injector.BookSlot(vacantSlot,"FourWheeler");
                        if (slotStatus)
                        {
                            Console.WriteLine("Slot Booked Successfully");
                             int noOfVacantSlots=injector.GetSlotsStatus("FourWheeler");
                            Console.WriteLine($"\n No of Vacant Slots : {noOfVacantSlots} \n No of Occupied Slots : {numberOfHeavyVehicleSlots-noOfVacantSlots} \n Total Number of Slots : {numberOfHeavyVehicleSlots}");
                        }
                        else
                        {
                            Console.WriteLine("Slot Could not be Booked");
                        }
                     }
                     
                }
                else if (userOption == 4)
                {
                         int  vacantSlot=injector.ViewVacantSlot("HeavyVehicle");
                    if(vacantSlot == -1)
                    {
                        Console.WriteLine("Sorry No Vacant Slots");
                        continue;
                    }
                    else
                    {
                          Random random = new Random();
                          int ticketNumber=random.Next(1000,9999);
                          Console.WriteLine("Please Enter the Vehicle Number");
                          string vehicleId=Console.ReadLine();
                        
                          DateTime inTime=DateTime.Now;
                        Console.WriteLine("Enter the number of minutes you wish to Stay");
                        int duration= Convert.ToInt32(Console.ReadLine());
                        DateTime outTime=inTime.AddHours(duration/60).AddMinutes(duration%60);
                          Ticket userticket = new Ticket(vacantSlot,ticketNumber,vehicleId,inTime.ToString("t"),outTime.ToString("t"));
                          bool ticketStatus=injector.CreateTicket(userticket,"HeavyVehicle");
                        if (ticketStatus)
                        {
                            Console.WriteLine("Ticket Generated successfully");
                            Console.WriteLine($"\nHere are your Ticket Details \n Slot Number : {userticket.slotNumber+1}\n Ticket Id : {userticket.ticketId} \nVehicle Number {userticket.vehicleNumber} \n Intime : {userticket.inTime} \n OutTime : {userticket.outTime} \n ");
                            Console.WriteLine($"\nPlease Go to Slot Number {userticket.slotNumber+1} to park your Vehicle");
                        }
                        else
                        {
                            Console.WriteLine("Ticket Could Not be Created");
                        }
                        bool slotStatus=injector.BookSlot(vacantSlot,"HeavyVehicle");
                        if (slotStatus)
                        {
                            Console.WriteLine("Slot Booked Successfully");
                             int noOfVacantSlots=injector.GetSlotsStatus("HeavyVehicle");
                            Console.WriteLine($"\n No of Vacant Slots : {noOfVacantSlots} \n No of Occupied Slots : {numberOfHeavyVehicleSlots-noOfVacantSlots} \n Total Number of Slots : {numberOfHeavyVehicleSlots}");
                        }
                        else
                        {
                            Console.WriteLine("Slot Could not be Booked");
                        }

                    }
                }
                else if (userOption == 0)
                {
                    break;
                }
            }

         }
    }
}
