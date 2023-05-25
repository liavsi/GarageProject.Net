using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{

 
    internal class Car
    {
        private eCarColor m_CarColor;
        private int m_NumOfDoors;

        public eCarColor CarColor
        { get { return m_CarColor; } set { m_CarColor = value; } }

        public int NumOfDoors
        { get { return m_NumOfDoors; } set { m_NumOfDoors = value;} }

        const string COLOR = "Color";
        const string NUMBER_OF_DOORS = "Number Of Doors";


        public void SetProparties(Dictionary<string, string> i_PropartiesKeyValue)
        {
            if (!(Enum.TryParse<eCarColor>(i_PropartiesKeyValue[COLOR], out m_CarColor) &&
            (int.TryParse(i_PropartiesKeyValue[NUMBER_OF_DOORS], out m_NumOfDoors))))
            {
                throw new FormatException("couldnt Parse this input");
            }
        }

        public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            io_NeededProparties.Add("Color");
            io_NeededProparties.Add("Number Of Doors");
        }
        public override string ToString()
        {
            return string.Format(@"
Number Of Doors: {0}
Color: {1}
",m_NumOfDoors, m_CarColor.ToString());
        }
    }
}
