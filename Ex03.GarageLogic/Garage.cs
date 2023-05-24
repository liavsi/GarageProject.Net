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
        private Dictionary<string, VehicleInfo> m_VehicleStatus;

        public Garage()
        {
            VehicleFactory.InitializeVehicleSettings();
            m_Vehicles = new Dictionary<string, Vehicle>();
        }

        public bool TryEnterVehicleByLicense(string i_License)
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
         public void MoveToRepair(ref Vehicle io_vehicle)
        {
            
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
