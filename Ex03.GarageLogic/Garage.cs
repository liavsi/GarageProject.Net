using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles;
        private Dictionary<eVehicleStatus, List<Vehicle>> m_VehicleStatuses = new Dictionary<eVehicleStatus, List<Vehicle>>();
        //to do: VehicleInfo class - ownerName(string) owenerPhone(string) and carState(enum)
        //private Dictionary<string, VehicleInfo> m_VehicleStatus;

        public Garage()
        {
            VehicleFactory.InitializeVehicleSettings();
            m_Vehicles = new Dictionary<string, Vehicle>();
        }

        public bool TryEnterVehicleByLicense(string i_License)
        {
            bool isEntered =m_Vehicles.ContainsKey(i_License);
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

        public void ChargeVehicle(string i_LicenseNumber, float i_HoursToAdd)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                Vehicle vehicle  = m_Vehicles[i_LicenseNumber];
                if(vehicle is ElectricVehicle)
                {
                    (vehicle as ElectricVehicle).ChargeBattary(i_HoursToAdd);
                }
                throw new ArgumentException(i_LicenseNumber);
            }
            else
            {
                throw new ValueOutOfRangeException();
            }
        }

        public void ReFuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_LitersToAdd)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                Vehicle vehicle = m_Vehicles[i_LicenseNumber];
                if (vehicle is FuelVehicle)
                {
                    (vehicle as FuelVehicle).Refuel(i_FuelType, i_LitersToAdd);
                }
                else
                {
                    throw new ArgumentException(i_LicenseNumber);
                }
            }
            else
            {
                throw new ValueOutOfRangeException();
            }
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            if(m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                Vehicle vehicle = m_Vehicles[i_LicenseNumber];
                vehicle.InflateWheelsToMax();
            }
            else
            {
                throw new ArgumentException(i_LicenseNumber);
            }

        }

        public string GetVehicleAsString(string i_LicenseNumber)
        {
            string vehicleString = "";
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                Vehicle vehicle = m_Vehicles[i_LicenseNumber];
                vehicleString += vehicle.ToString();
            }
            else
            {
                throw new ValueOutOfRangeException();
            }
            return vehicleString;
        }

        public void GetAllLicenseNumbers()
        {
            foreach (string key in m_Vehicles.Keys)
            {
                Console.WriteLine(key);
            }
        }

    }
}
