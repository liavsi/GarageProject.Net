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


        const string DANGEROUS = "Dangerous (yes,no)";
        const string CARGO_VOLUME = "Cargo Volume";

        public Truck(bool i_IsDangarouse, float i_CargoVolume)
        {
            m_IsDangarouse = i_IsDangarouse;
            m_CargoVolume = i_CargoVolume;
        }
        public void SetProparties(Dictionary<string, string> i_PropartiesKeyValue)
        {
            if(!(float.TryParse(i_PropartiesKeyValue[CARGO_VOLUME], out m_CargoVolume)))
            {
                throw new ArgumentException();
            }
            if (i_PropartiesKeyValue.ContainsKey(DANGEROUS))
            {
                switch (i_PropartiesKeyValue[DANGEROUS])
                {
                    case "no":
                        m_IsDangarouse = false;
                        break;
                    case "yes":
                        m_IsDangarouse = true;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            else
                throw new ArgumentException();
        }

        public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            io_NeededProparties.Add(DANGEROUS);
            io_NeededProparties.Add(CARGO_VOLUME);
        }
    }
}
