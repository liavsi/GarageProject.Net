using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles;
        //to do: VehicleInfo class - ownerName(string) owenerPhone(string) and carState(enum)
        //private Dictionary<string, VehicleInfo> m_VehicleStatus;

        public Garage()
        {
            VehicleFactory.InitializeVehicleSettings();
            m_Vehicles = new Dictionary<string, Vehicle>();
        }

        public bool TryEnterCarByLicense(string i_License)
        {
            bool isEntered = m_Vehicles[i_License] != null;
            if (isEntered)
            { 
                // MoveToRepair(i_License); 
            }
            return isEntered;
        }

        public Vehicle GetVehicleByLicense(string i_License)
        {
            m_Vehicles.TryGetValue(i_License, out Vehicle vehicle);
            return vehicle;
        }

        public List<string> GetNeededProparties(eVehicleType i_VehicleType)
        {
            List<string> result = VehicleFactory.GetNeededProparties(i_VehicleType);
            return result;
        }

        public void CreateVehicle(string i_License, eVehicleType i_VehicleType, Dictionary<string,string> i_PropartiesKeyValue)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle(i_License, i_VehicleType, i_PropartiesKeyValue);
            if (vehicle == null)
            {
                throw new Exception("no car made");
            }
            m_Vehicles.Add(i_License, vehicle);
        }

        public void UpdateVehicleState(Vehicle i_vehicle, eVehicleType i_VehicleType, Dictionary<string, string> i_PropartiesKeyValue)
        {
            VehicleFactory.UpdateVehicleState(i_vehicle,  i_VehicleType, i_PropartiesKeyValue);
        }

        public bool ChargeVehicle(string i_LicenseNumber, float i_HoursToAdd)
        {
            bool isElectricCar = false;
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                Vehicle vehicle  = m_Vehicles[i_LicenseNumber];
                if(vehicle is ElectricVehicle)
                {
                    (vehicle as ElectricVehicle).ChargeBattary(i_HoursToAdd);
                    isElectricCar = true;
                }
            }
            return isElectricCar;
        }

        public bool ReFuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_LitersToAdd)
        {
            bool isFueledVehicle = false;
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                Vehicle vehicle = m_Vehicles[i_LicenseNumber];
                if (vehicle is FuelVehicle)
                {
                    (vehicle as FuelVehicle).Refuel(i_FuelType, i_LitersToAdd);
                    isFueledVehicle = true;
                }
            }
            return isFueledVehicle;
        }

        public bool InflateWheelsToMax(string i_LicenseNumber)
        {
            bool isInflated = false;
            if(m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                Vehicle vehicle = m_Vehicles[i_LicenseNumber];
                vehicle.InflateWheelsToMax();
                isInflated = true;
            }

            return isInflated;
        }

    }
}
