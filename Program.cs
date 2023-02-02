using ParkingLot.Model;


namespace Parkinglot
{
    class ParkingLot
    {
         static void Main()
        {
            Console.WriteLine("Please enter the number of Two Wheeler slots");
             int  numberOfTwoWheelerSlots = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the number of Four Wheeler slots");
            int numberOfFourWheelerSlots = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the number of Heavy Vehicle  slots");
            int numberOfHeavyVehicleSlots = Convert.ToInt32(Console.ReadLine());

             Slots slots = new Slots();
             slots.InitializeSlots(numberOfTwoWheelerSlots, numberOfFourWheelerSlots, numberOfHeavyVehicleSlots);
             slots.takeUserInput();

        }
    }
}
