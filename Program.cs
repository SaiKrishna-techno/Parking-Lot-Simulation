using ParkingLot.Injector;
using ParkingLot.Interfaces;
using ParkingLot.Model;
using ParkingLot.Services;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Parkinglot
{
    class Parkinglot
    {

         static void Main()
         {  

                 Parkinglot parkingLot = new Parkinglot();
                 Console.WriteLine("Please enter the number of Two Wheeler slots and Four Wheeler Slots and Heavy Vehicle Slots");

                 int numberOfTwoWheelerSlots = 0;
                 int numberOfFourWheelerSlots = 0;
                 int numberOfHeavyVehicleSlots = 0;
           
                 SlotInitialisation:
                 try
                 {
                      numberOfTwoWheelerSlots = Convert.ToInt32(Console.ReadLine());
                      numberOfFourWheelerSlots = Convert.ToInt32(Console.ReadLine());
                      numberOfHeavyVehicleSlots = Convert.ToInt32(Console.ReadLine());
                 }
                 catch (Exception ex)
                 {
                      Console.WriteLine(ex.Message +"Please Try Again");
                      goto SlotInitialisation;
              
                 }
             

            // Dealing With Dependency Injection and Creating injector object
                 ISlot slot = new SlotService();
                 ITicket ticket = new TicketService();
                 Injector injector= new Injector(slot, ticket);

                 //Initializing The Slots
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
           




                 // Main FUnctionality Starts From Here
                 while (true)
                 {
                          Console.WriteLine("\nOptions:\n Enter 1 to Unpark \n Enter 2 for 2 wheeler \n Enter 3 for 4 wheeler \n Enter 4 for Heavy Vehicle \n Enter 0 to Exit");
                          int userOption = Convert.ToInt32(Console.ReadLine());

                          switch (userOption) { 
                    // Case Dealing with the Unparking of Vehicle
                              case 1:
                                    {  
                                         
                                         Console.WriteLine("\nPlease Enter the Ticket Id");
                            int ticketId = 0;
                            try
                            {
                                 ticketId = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Invalid Ticket Format");
                            }
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
                                                   Console.WriteLine("Ticket Does Not Exist \n Please Try Again");

                                         }

                                                   break;
                   
                                    }
                        // Case Dealing with the Parking of Vehicle
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
                                               bool ticketStatus=injector.CreateTicket(userTicket);
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
                                               
                                               int  vacantSlot=injector.ViewVacantSlot("FourWheeler");
                                               if(vacantSlot == -1)
                                               {
                                                       Console.WriteLine("Sorry No Vacant Slots");
                                                       continue;
                                               }
                                               else
                                               {
                         
                                                       Ticket userTicket = parkingLot.TakeTicketInput(vacantSlot,"FourWheeler");
                                                       bool ticketStatus=injector.CreateTicket(userTicket);
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
                                            int  vacantSlot=injector.ViewVacantSlot("HeavyVehicle");
                                            if(vacantSlot == -1)
                                            {
                                                    Console.WriteLine("Sorry No Vacant Slots");
                                                    continue;
                                            }
                                            else
                                            {

                                                    Ticket userTicket = parkingLot.TakeTicketInput(vacantSlot,"HeavyVehicle");
                                                    bool ticketStatus=injector.CreateTicket(userTicket);
                                            
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

        //Method to Take the Required Information to Create a Ticket 
        public Ticket TakeTicketInput(int vacantSlot,string type)
        {
         
             Random random = new Random();
             int ticketNumber=random.Next(1000,9999);
             Console.WriteLine("Please Enter the Vehicle Number");
             string vehicleId=Console.ReadLine();           
             DateTime inTime=DateTime.Now;
             UserInput:
             Console.WriteLine("Enter the number of minutes you wish to Stay");
            int duration=0;
            try
            {
                duration =Convert.ToInt32(Console.ReadLine());
                if(duration < 10)
                {
                    Console.WriteLine("Minimum Time Should be 10 Minutes");
                    goto UserInput;
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("Incorrect Input\n Please try again");
                goto UserInput;
                
            }
             DateTime outTime=inTime.AddHours(duration/60).AddMinutes(duration%60);
             Ticket userticket = new Ticket(vacantSlot,ticketNumber,type,vehicleId,inTime.ToString("t"),outTime.ToString("t"));
             return userticket;
        }

        // Method to Print The Ticket 
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
