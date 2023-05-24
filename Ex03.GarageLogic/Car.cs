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

        public CarColor CarColor
        { get { return m_CarColor; } set { m_CarColor = value; } }

        public int NumOfDoors
        { get { return m_NumOfDoors; } set { m_NumOfDoors = value;} }

        const string COLOR = "Color";
        const string NUMBER_OF_DOORS = "Number Of Doors";

        public Car(CarColor i_CarColor, int i_NumOfDoors)
        {
            m_CarColor = i_CarColor;
            m_NumOfDoors = i_NumOfDoors;
        }
        public void SetProparties(Dictionary<string, string> i_PropartiesKeyValue)
        {
            if (!(Enum.TryParse<CarColor>(i_PropartiesKeyValue[COLOR], out m_CarColor) &&
            (int.TryParse(i_PropartiesKeyValue[NUMBER_OF_DOORS], out m_NumOfDoors))))
            {
                throw new ArgumentException();
            }
        }

        public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            io_NeededProparties.Add("Color");
            io_NeededProparties.Add("Number Of Doors");
        }
    }
}
