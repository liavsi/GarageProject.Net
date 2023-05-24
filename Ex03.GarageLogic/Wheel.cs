using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufactur;
        private readonly float m_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Wheel(float i_maxAirPressure)
        {
            m_MaxAirPressure = i_maxAirPressure;
        }

        public string Manufactur
        { get { return m_Manufactur; } set { m_Manufactur = value; } }

        public void InflateWheel(float i_airAmount)
        {
            if (m_CurrentAirPressure + i_airAmount <=  m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_airAmount;
            }
            else
            {
                throw new ValueOutOfRangeException();
            }
        }
        public void InflateWheel()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }

        public override string ToString()
        {
            string wheelString = string.Format(@"Wheel:
Manufacture: {0}
Max Air Pressure: {1}
Current Air Pressure", m_Manufactur, m_MaxAirPressure, m_CurrentAirPressure);
            return wheelString;
        }
    }
}
