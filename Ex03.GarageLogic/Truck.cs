using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck
    {
        private bool m_IsDangarouse;
        private float m_CargoVolume;

        public Truck(bool i_IsDangarouse, float i_CargoVolume)
        {
            m_IsDangarouse = i_IsDangarouse;
            m_CargoVolume = i_CargoVolume;
        }
        
        public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            io_NeededProparties.Add("Dangerous (yes,no)");
            io_NeededProparties.Add("Cargo Volume");
        }
    }
}
