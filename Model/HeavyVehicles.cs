using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Model
{
    internal class HeavyVehicles:Vehicle
    {
        public string vehicleType = "HeavyVehicle";

        public HeavyVehicles(string vehicleId) : base(vehicleId)

        {
            this.vehicleNumber = vehicleId;
        }
    }
}
