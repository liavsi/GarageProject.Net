﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles;
        //to do: VehicleInfo class - ownerName(string) owenerPhone(string) and carState(enum)
        // private Dictionary<string, VehicleInfo> m_VehicleStatus;

        public Garage()
        {
            VehicleFactory.InitializeVehicleSettings();
        }

        public bool TryEnterCarByLicense(string i_License)
        {
            bool isEntered = m_Vehicles.TryGetValue(i_License, out Vehicle vehicle);
            if (isEntered)
            { 
                // MoveToRepair(i_License); 
            }
            return isEntered;
        }

        public List<string> GetNeededProparties(VehicleFactory.eVehicleType i_VehicleType)
        {
            List<string> result = VehicleFactory.GetNeededProparties(i_VehicleType);
            return result;
        }

        public void CreateVehicle(string i_License, VehicleFactory.eVehicleType i_VehicleType, Dictionary<string,string> i_PropartiesKeyValue)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle(i_License, i_VehicleType, i_PropartiesKeyValue);
            if (vehicle == null)
            {
                throw new Exception("no car made");
            }
            m_Vehicles.Add(i_License, vehicle);
        }
    }
}