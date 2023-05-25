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
    }
    
}
