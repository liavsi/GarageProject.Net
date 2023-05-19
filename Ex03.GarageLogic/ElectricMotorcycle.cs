using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    enum LicenseType
    {
        A1,
        A2,
        AA,
        B1
    }
    internal class ElectricMotorcycle : NonFuelVehicle
    {
        private readonly int m_EngineVolume;
        private LicenseType m_LicenseType;


        public ElectricMotorcycle(int i_EngineVolume, LicenseType i_LicenseType, string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, int i_NumOfWheels, float i_MaxWheelPressure, string i_WheelsManufacture, float i_MaxEnergy)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_NumOfWheels, i_MaxWheelPressure, i_WheelsManufacture, i_MaxEnergy)
        {
            m_EngineVolume = i_EngineVolume;
            m_LicenseType = i_LicenseType;
        }
    }
}
