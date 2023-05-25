using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        private float m_CurrentEnergy = 0;
        private float m_MaxCharge; //in hours


        public ElectricVehicle(string i_LicenseNumber, List<string> i_ManufacturProparties)
            : base(i_LicenseNumber, i_ManufacturProparties)
        {
            string maxChargestr = i_ManufacturProparties[VehicleFactory.MaxChargeIndex];
            if (!(float.TryParse(maxChargestr, out m_MaxCharge)))
            {
                throw new FormatException("couldnt Parse this input" + maxChargestr);
            }
        }
        public override void SetProparties(Dictionary<string, string> i_PropartiesKeyValue)
        {
            base.SetProparties(i_PropartiesKeyValue);
            m_CurrentEnergy = m_MaxCharge * m_RemainingEnergyPercentage * 0.01f;
        }
        new public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            Vehicle.NeededProparties(ref io_NeededProparties); 
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            string electricString = string.Format(@"
Engine: Electric
Max Battery Life: {0}
Current Hours Remain: {1}", m_MaxCharge, m_CurrentEnergy);
            stringBuilder.Append(electricString);
            return stringBuilder.ToString();
        }

        public void ChargeBattary(float i_HoursToAdd)
        {
            if (m_CurrentEnergy + i_HoursToAdd > m_MaxCharge)
            {
                throw new ValueOutOfRangeException(i_HoursToAdd, 0f, m_MaxCharge-m_CurrentEnergy);
            }
            m_CurrentEnergy += i_HoursToAdd;
        }
        public override abstract eVehicleType GetVehicleType();
        
        
    }
}
