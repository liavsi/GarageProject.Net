using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string m_Manufactur;
        private readonly float m_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Wheel(string i_manufacturerName, float i_maxAirPressure)
        {
            m_Manufactur = i_manufacturerName;
            m_MaxAirPressure = i_maxAirPressure;
        }

        public void InflateWheel(float i_airAmount)
        {
            if (m_CurrentAirPressure + i_airAmount <=  m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_airAmount;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
