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

        public static void IsValidLicenseNumber(string i_NumberStr)
        {
            if(int.TryParse(i_NumberStr,out int number))
            {
                if (number < 0)
                    throw new ArgumentException();
            }
            else
            {
                throw new ArgumentException("the number is not a number");
            }
        }


    }
    
}
