using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    
    internal class ElectricMotorcycle : NonFuelVehicle
    {
        private Motorcycle m_Motorcycle;


        public ElectricMotorcycle(Motorcycle i_Motorcycle, string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, int i_NumOfWheels, float i_MaxWheelPressure, string i_WheelsManufacture, float i_MaxEnergy)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_NumOfWheels, i_MaxWheelPressure, i_WheelsManufacture, i_MaxEnergy)
        {
            m_Motorcycle = i_Motorcycle;
        }
    }
}
