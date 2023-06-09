﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {

        private static Dictionary<eVehicleType, List<string>> m_FactoryVehicleSettings;

        public const int NumOfWheelIndex = 0;
        public const int MaxWheelPressureIndex = 1;
        public const int FuelTypeIndex = 2;
        public const int MaxChargeIndex = 2;
        public const int FuelTankIndex = 3;

        public static void InitializeVehicleSettings()
        {
            m_FactoryVehicleSettings = new Dictionary<eVehicleType, List<string>>();
            //format for Fueled (NumOfWheels, maxwheelspressure, FuelType, TankSize)
            m_FactoryVehicleSettings.Add(eVehicleType.FuelMotorcycle, new List<string> {"2","31","Octan98","6.4"});
            m_FactoryVehicleSettings.Add(eVehicleType.FuelCar, new List<string> { "5", "33", "Octan95", "46" });
            m_FactoryVehicleSettings.Add(eVehicleType.FuelTruck, new List<string> { "14", "26", "Soler", "135" });
            //format for Electric (NumOfWheels, maxwheelspressure,maxTimeInCharge)
            m_FactoryVehicleSettings.Add(eVehicleType.ElectricMotorcycle, new List<string> { "2", "31", "2.6"});
            m_FactoryVehicleSettings.Add(eVehicleType.ElectricCar, new List<string> { "5", "33", "5.2" });
        }

        public static List<string> GetVehicleSettings(eVehicleType i_VehicleType)
        {
            return m_FactoryVehicleSettings[i_VehicleType];
        }



        public static List<string> GetNeededProparties(eVehicleType i_VehicleType)
        {
            List<string> needed_Proparties = new List<string>();
            // Check the vehicle type and create the corresponding instance
            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    FuelCar.NeededProparties(ref needed_Proparties);
                    break;
                case eVehicleType.ElectricCar:
                    ElectricCar.NeededProparties(ref needed_Proparties);
                    break;
                case eVehicleType.FuelMotorcycle:
                    FuelMotorcycle.NeededProparties(ref needed_Proparties);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    ElectricMotorcycle.NeededProparties(ref needed_Proparties);
                    break;
                case eVehicleType.FuelTruck:
                    FuelTruck.NeededProparties(ref needed_Proparties);
                    break;
                default:
                    throw new ArgumentException("invalid car type");
            }
            return needed_Proparties;
        }


        public static Vehicle CreateVehicle(string i_LicenseNumber, eVehicleType i_VehicleType, Dictionary<string, string> i_PropartiesKeyValue)
        {
            Vehicle vehicle = null;
            List<string> defaultSetting = m_FactoryVehicleSettings[i_VehicleType];
            // Check the vehicle type and create the corresponding instance
            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    vehicle = new FuelCar(i_LicenseNumber, defaultSetting);
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = new ElectricCar(i_LicenseNumber, defaultSetting);
                    break;
                case eVehicleType.FuelMotorcycle:
                    vehicle = new FuelMotorcycle(i_LicenseNumber, defaultSetting);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle(i_LicenseNumber, defaultSetting);
                    break;
                case eVehicleType.FuelTruck:
                    vehicle = new FuelTruck(i_LicenseNumber, defaultSetting);
                    break;
                default:
                    throw new ArgumentException("invalid car type");
            }
            vehicle.SetProparties(i_PropartiesKeyValue);
            return vehicle;
        }

       

    }
}
