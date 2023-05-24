using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }

    internal abstract class FuelVehicle : Vehicle
    {
        private eFuelType m_FuelType;
        private float m_FuelTankCapacity;
        private float m_CurrentFuelLevel;

        public FuelVehicle(string i_LicenseNumber, List<string> i_ManufacturProparties)
            : base(i_LicenseNumber, i_ManufacturProparties)
        {
            string fuelTypeStr = i_ManufacturProparties[VehicleFactory.FuelTypeIndex];
            string fuelTankCapacityStr = i_ManufacturProparties[VehicleFactory.FuelTankIndex];
            if (!(Enum.TryParse<eFuelType>(fuelTypeStr, out m_FuelType) && float.TryParse(fuelTankCapacityStr,out m_FuelTankCapacity)))
            {
                throw new Exception("coudnt read");
            }
        }


        public void Refuel(eFuelType i_FuelType, float i_FuelAmount)
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
