using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelCar : FuelVehicle
    {

        Car m_Car;


        public FuelCar(Car i_Car, FuelType i_FuelType, float i_FuelTankCapacity, string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, int i_NumOfWheels, float i_MaxWheelPressure, string i_WheelsManufacture)
            : base(i_FuelType, i_FuelTankCapacity, i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_NumOfWheels, i_MaxWheelPressure, i_WheelsManufacture)
        {
            m_Car = i_Car;
        }
    }
}
