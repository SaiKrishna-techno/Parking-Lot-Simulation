using ParkingLot.Injector;
using ParkingLot.Interfaces;
using ParkingLot.Model;
using ParkingLot.Services;
using System.Runtime.CompilerServices;

namespace Parkinglot
{
    class Parkinglot
    {

         static void Main()
         {  

                 Parkinglot parkingLot = new Parkinglot();
             
                 Console.WriteLine("Please enter the number of Two Wheeler slots");
                 int numberOfTwoWheelerSlots = Convert.ToInt32(Console.ReadLine());

                 Console.WriteLine("Please enter the number of Four Wheeler slots");
                 int numberOfFourWheelerSlots = Convert.ToInt32(Console.ReadLine());

                 Console.WriteLine("Please enter the number of Heavy Vehicle  slots");
                 int numberOfHeavyVehicleSlots = Convert.ToInt32(Console.ReadLine());

             
                 ISlot slot = new SlotService();
                 ITicket ticket = new TicketService();
               

                 Injector injector= new Injector(slot, ticket);

                 bool twoWheelerSlotStatus= injector.InitializeSlots("TwoWheeler", numberOfTwoWheelerSlots);
                 bool fourWheelerSlotStatus= injector.InitializeSlots("FourWheeler", numberOfFourWheelerSlots);
                 bool heavyVehicleSlotStatus=injector.InitializeSlots("HeavyVehicle", numberOfHeavyVehicleSlots);

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

                          switch (userOption) { 
                              case 1:
                                    {
                                         Console.WriteLine("Inside 0");   
                                         Console.WriteLine("\nPlease Enter the Ticket Id");
                                         int ticketId=Convert.ToInt32(Console.ReadLine());
                                         int ticketDeleteid=injector.DeleteTicket(ticketId);
                                         if (ticketDeleteid!=-1)
                                         {
                                               bool status= injector.ClearSlot(ticketDeleteid);
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

                                                   break;
                   
                                    }
                              case 2:
                                   {
                                         int  vacantSlot=injector.ViewVacantSlot("TwoWheeler");
                                         if(vacantSlot == -1)
                                         {
                                               Console.WriteLine("Sorry No Vacant Slots");
                                               continue;
                                         }
                                         else
                                         {

                                               Ticket userTicket = parkingLot.TakeTicketInput(vacantSlot,"TwoWheeler");
                                               bool ticketStatus=injector.CreateTicket(userTicket,"TwoWheeler");
                                               if (ticketStatus)
                                               {
                          
                                                    parkingLot.PrintTicket(userTicket);
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
                                                     Console.WriteLine($"\n No of Vacant Slots : {noOfVacantSlots} \n No of Occupied Slots : {numberOfTwoWheelerSlots-noOfVacantSlots} \n Total Number of Slots : {numberOfTwoWheelerSlots}");
                                               }
                                               else
                                               {
                                                     Console.WriteLine("Slot Could not be Booked");
                                               }
                                         }
                                                break;

                                   }
                             case 3:
                                   {
                                               Console.WriteLine("Inside 3");
                                               int  vacantSlot=injector.ViewVacantSlot("FourWheeler");
                                               if(vacantSlot == -1)
                                               {
                                                       Console.WriteLine("Sorry No Vacant Slots");
                                                       continue;
                                               }
                                               else
                                               {
                         
                                                       Ticket userTicket = parkingLot.TakeTicketInput(vacantSlot,"FourWheeler");
                                                       bool ticketStatus=injector.CreateTicket(userTicket,"FourWheeler");
                                                       if (ticketStatus)
                                                       {
                                                                parkingLot.PrintTicket(userTicket);
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
                                                            Console.WriteLine($"\n No of Vacant Slots : {noOfVacantSlots} \n No of Occupied Slots : {numberOfFourWheelerSlots-noOfVacantSlots} \n Total Number of Slots : {numberOfFourWheelerSlots}");
                                                       }
                                                       else
                                                       {
                                                            Console.WriteLine("Slot Could not be Booked");
                                                       }
                                               }
                                                        break;    
                                   }

                             case 4:
                                   {
                                            Console.WriteLine("Inside 4 ");
                                            int  vacantSlot=injector.ViewVacantSlot("HeavyVehicle");
                                            if(vacantSlot == -1)
                                            {
                                                    Console.WriteLine("Sorry No Vacant Slots");
                                                    continue;
                                            }
                                            else
                                            {

                                                    Ticket userTicket = parkingLot.TakeTicketInput(vacantSlot,"HeavyVehicle");
                                                    bool ticketStatus=injector.CreateTicket(userTicket,"HeavyVehicle");
                                            
                                                    if (ticketStatus)
                                                    {

                                                         parkingLot.PrintTicket(userTicket);
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
                                            break;
                                   }
                                   case 0:
                                         { 
                                        return;
                                         }
                                   default:
                                          {
                                           Console.WriteLine("InValid Input Please Try Again");
                                           break;
                                          }
                          }
                 }

         }

        public Ticket TakeTicketInput(int vacantSlot,string type)
        {
             Random random = new Random();
             int ticketNumber=random.Next(1000,9999);
             Console.WriteLine("Please Enter the Vehicle Number");
             string vehicleId=Console.ReadLine();           
             DateTime inTime=DateTime.Now;
             Console.WriteLine("Enter the number of minutes you wish to Stay");
             int duration= Convert.ToInt32(Console.ReadLine());
             DateTime outTime=inTime.AddHours(duration/60).AddMinutes(duration%60);
             Ticket userticket = new Ticket(vacantSlot,ticketNumber,type,vehicleId,inTime.ToString("t"),outTime.ToString("t"));
            return userticket;
        }

        public void PrintTicket(Ticket ticket)
        {
            Console.WriteLine("Ticket Created Successfully");
            Console.WriteLine("\n Below are your Ticket Details");
            Console.WriteLine(new String('-',33));
            Console.WriteLine($" \n|    Slot Number : {ticket.slotNumber+1}            |\n|    Ticket Id : {ticket.ticketId}           |\n|    Vehicle Type : {ticket.vehicleType}  |\n|    Vehicle Number : {ticket.vehicleNumber}  |\n|    Intime : {ticket.inTime}             |\n|    OutTime : {ticket.outTime}            | ");
            Console.WriteLine(new String('-',33));
            Console.WriteLine($"\nPlease Go to Slot Number {ticket.slotNumber+1}   to park your Vehicle");


        }
    }
}
