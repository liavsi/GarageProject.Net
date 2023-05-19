using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class NonFuelVehicle : Vehicle
    {
        private float m_CurrentEnergy = 0;
        private float m_MaxEnergy;


        public NonFuelVehicle(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, int i_NumOfWheels, float i_MaxWheelPressure, string i_WheelsManufacture, float i_MaxEnergy)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_NumOfWheels, i_MaxWheelPressure, i_WheelsManufacture)
        {
            m_MaxEnergy = i_MaxEnergy; 
        }
    }
}
