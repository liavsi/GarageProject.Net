﻿using System;
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

    internal abstract class FuelVehicle : NonFuelVehicle
    {
        private FuelType m_FuelType;

        public FuelVehicle(FuelType i_FuelType, string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, int i_NumOfWheels, float i_MaxWheelPressure, string i_WheelsManufacture, float i_MaxEnergy)
            : base(i_ModelName,i_LicenseNumber, i_RemainingEnergyPercentage,i_NumOfWheels, i_MaxWheelPressure,i_WheelsManufacture,i_MaxEnergy)
        {
            m_FuelType = i_FuelType;
        }
    }
}