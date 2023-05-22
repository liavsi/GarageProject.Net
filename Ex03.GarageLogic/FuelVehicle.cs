using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum FuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }

    internal abstract class FuelVehicle : Vehicle
    {
        private FuelType m_FuelType;
        private float m_FuelTankCapacity;
        private float m_CurrentFuelLevel;

        public FuelVehicle(FuelType i_FuelType, float i_FuelTankCapacity, string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, int i_NumOfWheels, float i_MaxWheelPressure, string i_WheelsManufacture)
            : base(i_ModelName,i_LicenseNumber, i_RemainingEnergyPercentage,i_NumOfWheels, i_MaxWheelPressure,i_WheelsManufacture)
        {
            m_FuelType = i_FuelType;
            m_FuelTankCapacity = i_FuelTankCapacity;
            m_CurrentFuelLevel = i_RemainingEnergyPercentage * m_FuelTankCapacity;
        }

        protected FuelVehicle(FuelType i_FuelType, float i_FuelTankCapacity, int i_NumOfWheels, float i_MaxWheelPressure, string i_LicenseNumber)
            : base(i_NumOfWheels, i_MaxWheelPressure, i_LicenseNumber)
        {
            m_FuelType= i_FuelType;
            m_FuelTankCapacity = i_FuelTankCapacity;
        }


        public void Refuel(FuelType i_FuelType, float i_FuelAmount)
        {
            if (m_FuelType == i_FuelType)
            {
                if (m_CurrentFuelLevel + i_FuelAmount <= m_FuelTankCapacity)
                {
                    m_CurrentFuelLevel += i_FuelAmount;
                }
                else
                {
                    throw new ValueOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
