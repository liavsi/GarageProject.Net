using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum VehicleStatus
        {
            UNDER_REPAIR,
            REPAIRED,
            PAIED
        }
        public void InlistNewVehicle(string i_licenseNumber)
        {
            //requires exaptions!!
            if(IsVehicleExist(i_licenseNumber))
            {
                ChangeVehicleStatus(VehicleStatus.UNDER_REPAIR);
            }
            else
            {
                string typeOfVehicle;
                Console.WriteLine("Please enter the type of vehicle: ");
                Console.WriteLine("Electric/non electric car, Electric/non electric motorcycle or truck");
                typeOfVehicle = Console.ReadLine();
                //create new vehicle method
            }
        }
        public void ChangeVehicleStatus(VehicleStatus i_status)
        {

        }
        public bool IsVehicleExist(string i_licenseNumber)
        {
            return true;//check if the vehicle is in the garage
        }
        public void InflateTiresToMaxCapacity(string i_licenseNumber)
        {

        }
        public void FuelVehicle(string i_carInfoToFuel)
        {
            //parsing
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
