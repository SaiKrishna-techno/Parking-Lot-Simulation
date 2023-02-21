using ParkingLot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Model
{
    class Vehicle
    {
        public string vehicleNumber;

        public  Vehicle(string vehicleNumber)
        {
            this.vehicleNumber = vehicleNumber;
        }
    }
}
