using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Model
{
    internal class FourWheeler: Vehicle
    {
        public string vehicleType = "FourWheeler";

        public FourWheeler(string vehicleId) : base(vehicleId)
        {
            this.vehicleNumber = vehicleId;
        }
    }
}
