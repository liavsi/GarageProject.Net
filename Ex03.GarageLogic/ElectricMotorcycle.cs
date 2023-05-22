using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    
    internal class ElectricMotorcycle : ElectricVehicle
    {
        private Motorcycle m_Motorcycle;


        public ElectricMotorcycle(Motorcycle i_Motorcycle, float i_MaxEnergy, string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, int i_NumOfWheels, float i_MaxWheelPressure, string i_WheelsManufacture)
            : base(i_MaxEnergy, i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_NumOfWheels, i_MaxWheelPressure, i_WheelsManufacture)
        {
            m_Motorcycle = i_Motorcycle;
        }

        public ElectricMotorcycle(string i_LicenseNumber)
            : base(i_LicenseNumber)
        {

        }
    }
}
