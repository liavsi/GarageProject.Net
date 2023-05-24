using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{

    public enum CarColor
    {
        White,
        Black,
        Yellow,
        Red
    }
    internal class Car
    {
        private CarColor m_CarColor;
        private int m_NumOfDoors;

        public Car(CarColor i_CarColor, int i_NumOfDoors)
        {
            m_CarColor = i_CarColor;
            m_NumOfDoors = i_NumOfDoors;
        }

        public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            io_NeededProparties.Add("Color");
            io_NeededProparties.Add("Number Of Doors");
        }
    }
}
