using FinalWindow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.VehicleFactoryPattern
{
    class VehicleFactory
    {
        public static Vehicle CreateVehicle(string type)
        {
            if (type == "Car")
            {
                return new Car();
            }
            else if (type == "Motor")
            {
                return new Motor();
            }
            else if (type == "Truck")
            {
                return new Truck();
            }
            else
            {
                throw new ArgumentException("Unsupported type vehicle.");
            }
        }
    }
}
