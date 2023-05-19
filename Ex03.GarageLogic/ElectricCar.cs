using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    enum CarColor
    {
        White,
        Black,
        Yellow,
        Red
    }
    internal class ElectricCar : NonFuelVehicle
    {
        int m_NumOfDoors;
        CarColor m_eCarColor;


        public ElectricCar(int i_NumOfDoors, CarColor i_CarColor, string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, int i_NumOfWheels, float i_MaxWheelPressure, string i_WheelsManufacture, float i_MaxEnergy)
            : base(i_ModelName,i_LicenseNumber, i_RemainingEnergyPercentage,i_NumOfWheels,i_MaxWheelPressure,i_WheelsManufacture,i_MaxEnergy)
        {
            m_NumOfDoors = i_NumOfDoors;
            m_eCarColor = i_CarColor;
        }
    }
}
