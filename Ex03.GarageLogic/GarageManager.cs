using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {

        private readonly Dictionary<string, Vehicle> r_Garage = new Dictionary<string, Vehicle>();
        
        public bool TryGetVehicle(string i_licenseNumber, out Vehicle o_vehicle)
        {
            return r_Garage.TryGetValue(i_licenseNumber, out o_vehicle);
        }
        public void InlistNewVehicle(Vehicle i_vehicle)
        {
            bool isAddedVehicle = !IsVehicleExist(i_vehicle.LicenseNumber);

            if (isAddedVehicle)
            {
                r_Garage.Add(i_vehicle.LicenseNumber, i_vehicle);
            }

            return isAddedVehicle;
            
        }
        public bool ChangeVehicleStatus(string i_licenseNumber, eVehicleStatus i_newStatus)
        {
            Vehicle vehicle;
            bool vehicleInGarage = TryGetVehicle(i_licenseNumber, out vehicle);

            if (vehicleInGarage)
            {
                vehicle.VehicleStatus = i_newStatus;
            }

            return vehicleInGarage;
        }
        public bool IsVehicleExist(string i_licenseNumber)
        {
            return r_Garage.ContainsKey(i_licenseNumber);
        }
        public bool InflateTiresToMaxCapacity(string i_licenseNumber)
        {
            Vehicle vehicle;
            bool vehicleInGarage = TryGetVehicle(i_licenseNumber, out vehicle);

            if (vehicleInGarage)
            {
                vehicle.InflateTiresToMax();
            }

            return vehicleInGarage;
        }
        public bool FuelVehicle(string i_carInfoToFuel)
        {
            Vehicle vehicle;
            bool vehicleInGarage = TryGetVehicle(i_LicenseNumber, out vehicle);

            Validation.ValidFuelVehicle(vehicle);
            (vehicle.Engine as FuelEngine).Refuel(i_FuelAmountToAdd, i_FuelType);

            return vehicleInGarage;
        }
        public void ChargeVehicle(string i_carInfoToCharge)
        {
            //parsing
        }
        public void ShowVehicleInfo (string i_licenseNumber)
        {
            //parsing and get from vehicles
        }


    }
}
