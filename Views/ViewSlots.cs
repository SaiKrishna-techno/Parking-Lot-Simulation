using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Model;

namespace ParkingLot.Views
{
    internal class ViewSlots
    {


        public void ViewVehicleSlots(List<string> temp )
        {
            Console.WriteLine(" \n  Slot Status  ");
            string topBar = "";
            for( int i = 0; i < temp.Count; i++)
            {
                topBar = topBar + "----";

            }
            Console.WriteLine(topBar);

            foreach (string slot in temp)
            {
               
                Console.Write($" |{slot}|");
            }
            Console.WriteLine();
            Console.WriteLine(topBar);
        }

        
    }
}
