using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Views;
using static System.Reflection.Metadata.BlobBuilder;

namespace ParkingLot.Model
{
    internal class Slots
    {
        public  List<string> twoWheelerSlots=new List<string>();
        public List<string> fourWheelerSlots=new List<string>();
        public List<string> heavyVehicleSlots=new List<string>();
        public List<Ticketclass> twoWheelerTickets = new List<Ticketclass>();
        public List<Ticketclass> fourWheelerTickets = new List<Ticketclass>();
        public List<Ticketclass> heavyVehicleTickets = new List<Ticketclass>();
        ViewSlots view = new ViewSlots();

        public void InitializeSlots(int noOfTwoWheelers, int noOfFourWheelers, int noOfHeavyVehicles)
        {
            for (int i = 0; i < noOfTwoWheelers; i++)
            {
                twoWheelerSlots.Add("E");
            }

            for(int i = 0; i < noOfFourWheelers; i++)
            {
                fourWheelerSlots.Add("E");
            }

            for(int i = 0; i < noOfHeavyVehicles; i++)
            {
                heavyVehicleSlots.Add("E");
            }

            Console.Write("Slots initialized");

           
            this.view.ViewVehicleSlots(twoWheelerSlots);
            this.view.ViewVehicleSlots(fourWheelerSlots);
            this.view.ViewVehicleSlots(heavyVehicleSlots);
        }


        public int ViewVacantSlot( List<String> slotdata)
        {
            for(int i=0; i < slotdata.Count; i++)
            {
                if (string.Equals(slotdata[i],"E"))
                {
                    return i;
                }   
            }
            return -1;

        }
        public void  takeUserInput()
        {
            while (true)
            {
                Console.WriteLine("Enter the type of vehicle\n Enter 1 to Unpark \n Enter 2 for 2 wheeler \n Enter 3 for 4 wheeler \n Enter 4 for Heavy Vehicle \n Enter 0 to Exit");
                int userOption = Convert.ToInt32(Console.ReadLine());

                if (userOption == 1)
                {
                    //Code for unparking a vehicle 
                    bool unparkStatus = UnParkVehicle();
                    if (unparkStatus)
                    {
                        Console.WriteLine("Unparking Sucessfull");
                    }
                    else
                    {
                        Console.WriteLine("Unparking Failed ");
                    }
                }
                else if (userOption == 2)
                {
                    this.view.ViewVehicleSlots(twoWheelerSlots);
                    int temp = ViewVacantSlot(twoWheelerSlots);

                    if (temp == -1)
                    {
                        Console.WriteLine("No Empty Slots");

                    }

                    var userTicket = TakeTicketInfo(temp);
                    this.twoWheelerTickets.Add(userTicket);
                    this.twoWheelerSlots[temp] = "O";
                    this.view.ViewVehicleSlots(twoWheelerSlots);
                    ShowTicket(userTicket);
                    Console.WriteLine($" Please go to {temp + 1} to park the vehicle");



                }
                else if (userOption == 3)
                {
                    this.view.ViewVehicleSlots(fourWheelerSlots);
                    int temp = ViewVacantSlot(fourWheelerSlots);

                    if (temp == -1)
                    {
                        Console.WriteLine("No Empty Slots");

                    }
                    var userTicket = TakeTicketInfo(temp);
                    this.fourWheelerTickets.Add(userTicket);
                    this.fourWheelerSlots[temp]="O";
                    ShowTicket(userTicket);
                    Console.WriteLine($" Please go to {temp + 1} to park the vehicle");

                }
                else if (userOption == 4)
                {
                    this.view.ViewVehicleSlots(heavyVehicleSlots);
                    int temp = ViewVacantSlot(heavyVehicleSlots);

                    if (temp == -1)
                    {
                        Console.WriteLine("No Empty Slots");

                    }
                    var userTicket = TakeTicketInfo(temp);
                    this.heavyVehicleTickets.Add(userTicket);
                    this.heavyVehicleSlots[temp] = "O";
                    ShowTicket(userTicket);
                    Console.WriteLine($" Please go to {temp + 1} to park the vehicle");
                }
                else if (userOption == 0)
                {
                    break;  
                }
                else 
                {
                    Console.WriteLine("Invalid Input");
                    takeUserInput();
                }
            }
        }


        public Ticketclass TakeTicketInfo(int slotnumber)
        {
            
            Random random = new Random();
            int ticketNumber=random.Next(1000,9999);
            Console.WriteLine("Enter the Vehicle Number ");
            string vehicleNumber=Console.ReadLine();
            Console.WriteLine("Enter the In Time");
            string inTime=Console.ReadLine();
            Console.WriteLine("Enter the Outime");
            string outTime=Console.ReadLine();  
            Ticketclass temp=new Ticketclass(slotnumber,ticketNumber,vehicleNumber,inTime,outTime);
            return temp;

        }


       
        public bool UnParkVehicle()
        {
            Console.WriteLine("Enter the type of vehicle\n Enter 1 for Two Wheeler \n Enter 2 for Four Wheeler \n Enter 3 for Heavy Vehicle\n Enter 0 to Exit ");
            int option=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("PLease Enter the Ticket Id");
            int ticketid = Convert.ToInt32(Console.ReadLine());
            if (option == 0)
            {
                return false;
            }
            else if(option == 1)
            {
                Console.WriteLine(this.twoWheelerTickets.Count);
                for(int i = 0; i < this.twoWheelerTickets.Count; i++)
                {
                    if (twoWheelerTickets[i].ticketId == ticketid)
                    {
                        this.view.ViewVehicleSlots(twoWheelerSlots);
                        ShowTicket(twoWheelerTickets[i]);
                        
                        twoWheelerSlots[twoWheelerTickets[i].slotNumber] = "E";

                        twoWheelerTickets.RemoveAt(i);
                        this.view.ViewVehicleSlots(twoWheelerSlots);


                        return true;
                        break;
                    }
                }
            }else if (option == 2)
            {
                for (int i = 0; i < this.fourWheelerTickets.Count; i++)
                {
                    if (fourWheelerTickets[i].ticketId == ticketid)
                    {
                        
                        fourWheelerSlots[fourWheelerTickets[i].slotNumber] = "E";
                        fourWheelerTickets.RemoveAt(i);
                        

                        return true;
                    }
                }
            }
            else if (option == 3){
                for (int i = 0; i < this.heavyVehicleTickets.Count; i++)
                {
                    if (heavyVehicleTickets[i].ticketId == ticketid)
                    {
                        heavyVehicleTickets.RemoveAt(i);
                        heavyVehicleSlots[heavyVehicleTickets[i].slotNumber] = "E";
                        return true;
                    }
                }
            }
            return false;
        }

        public void ShowTicket(Ticketclass ticket)
        {
            Console.WriteLine($"************************************\n|    Slot Number ={ticket.slotNumber}               |\n|    Ticket Id = {ticket.ticketId}             |\n|    Vehicle Number = {ticket.vehicleNumber}    |\n|    In Time = {ticket.inTime}               |\n|    Out time = {ticket.outTime}              |\n************************************");

        }
    }
}
