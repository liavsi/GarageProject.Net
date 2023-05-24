using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Validation
    {
        public static void ValidFuelVehicle(Vehicle i_Vehicle)
        {
            if (!(i_Vehicle.Engine is FuelEngine))
            {
                throw new ArgumentException("The vehicle is not fuel based");
            }
        }
    }
    
}
