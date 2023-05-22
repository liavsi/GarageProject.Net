using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        private float m_CurrentEnergy = 0;
        private float m_MaxEnergy;


        public ElectricVehicle(float i_MaxEnergy, string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, int i_NumOfWheels, float i_MaxWheelPressure, string i_WheelsManufacture)
            : base(i_ModelName,i_LicenseNumber, i_RemainingEnergyPercentage,i_NumOfWheels, i_MaxWheelPressure,i_WheelsManufacture)
        {
            m_MaxEnergy = i_MaxEnergy; 
        }

        public ElectricVehicle(string i_LicenseNumber)
            :base(i_LicenseNumber)
        {

        }

        public float CurrentEnergy
        { get { return m_CurrentEnergy; } set { m_CurrentEnergy = value; } }

        public float MaxEnergy
        { get { return m_MaxEnergy; } set { m_MaxEnergy = value; } }

        public void ChargeBattary(float i_HoursToAdd)
        {
            if (m_CurrentEnergy + i_HoursToAdd > MaxEnergy)
            {
                throw new ArgumentException("more hours than maximum");
            }
            m_CurrentEnergy += i_HoursToAdd;
        }
    }
}
