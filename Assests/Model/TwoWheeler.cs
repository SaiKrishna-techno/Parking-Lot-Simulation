using ParkingLot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Model
{
    internal class TwoWheeler : Vehicle
    {
        public string vehicleType = "TwoWheeler";

        public TwoWheeler(string vehicleId) : base(vehicleId)
        {
            this.vehicleNumber = vehicleId;
        }

    }
}
