using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Validation
    {
        const int c_MaxId = 99999999;
        const int c_MinId = 0;


        public static void IsValidIdNumber(string i_NumberStr)
        {
            if (int.TryParse(i_NumberStr, out int number))
            {
                if (number < c_MinId || number > c_MaxId)
                {
                    throw new ValueOutOfRangeException(number, c_MinId, c_MaxId);
                }
            }
            else
            {
                throw new FormatException("couldnt parse this input" + i_NumberStr);
            }
        }
        public static bool IsValidNumberChoice(out int o_choice)
        {
            bool isValid = false;

            if(!int.TryParse(Console.ReadLine(), out o_choice))
            {
                throw new FormatException("the input is not a number");
            }
            else if(!Enum.IsDefined(typeof(eVehicleType), o_choice))
            {
                throw new ValueOutOfRangeException("the input is out of the requested range");
            }
            else
            {
                isValid = true;
                return isValid;
            }
           
        }
        public static void IsValidOwner(string i_phoneNumber, string i_ownerName)
        {
            int o_phoneNumber;

            if (!int.TryParse(i_phoneNumber, out o_phoneNumber))
            {
                throw new FormatException("the phone number is not a number");
            }
            else if(IsContainedNumbers(i_ownerName))
            {
                throw new FormatException("the owners' name is invalid");
            }
        }
        public static bool IsContainedNumbers(string i_stringToCheck)
        {
            foreach (char c in i_stringToCheck)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsValidWheelPressure(string i_currentWheelPressurStr, out float o_currentWheelPressure)
        {
            bool isValid = false;

            if(!float.TryParse(i_currentWheelPressurStr, out o_currentWheelPressure))
            {
                throw new FormatException(i_currentWheelPressurStr + " doesn't match the requested format");
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }
        public static void IsValidEnergyPrecentage(string i_currentEnergyPrecentStr, out float o_currentEnergyPrecent, ref float io_remainingEnergyPercentage)
        {
            if (!float.TryParse(i_currentEnergyPrecentStr, out o_currentEnergyPrecent))
            {
                throw new FormatException(i_currentEnergyPrecentStr + " doesn't match the requested format");
            }
            else
            {
                if (o_currentEnergyPrecent > 0f && o_currentEnergyPrecent < 100f)
                {
                    io_remainingEnergyPercentage = o_currentEnergyPrecent;
                }
                else
                {
                    throw new ValueOutOfRangeException(i_currentEnergyPrecentStr + " is out of range");
                }
            }
        }
    }
    
}
