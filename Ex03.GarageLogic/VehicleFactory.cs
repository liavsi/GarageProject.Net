using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class VehicleFactory
    {
        public static Vehicle CreateVehicle(string i_LicsenseNumber, string i_VehicleEnergyType, string i_VehicleType, string i_VehicleState)
        {
            Vehicle vehicle = null;

            // Check the vehicle type and create the corresponding instance
            if (i_VehicleEnergyType == "Electric")
            {
                if(i_VehicleType == "Car")
                {
                    vehicle = new ElectricCar(i_LicsenseNumber);
                    vehicle.ParseChangeState(i_VehicleState);
                }
                else if(i_VehicleType=="Motorcycle")
                {
                    vehicle = new ElectricMotorcycle(i_LicenseNumber);
                    vehicle.ParseChangeState(i_VehicleState);
                }
            }
            if (i_VehicleEnergyType == "Fuel")
            {
                if (i_VehicleType == "Car")
                {
                    vehicle = new FuelCar(i_LicsenseNumber);
                    vehicle.ParseChangeState(i_VehicleState);
                }
                else if (i_VehicleType == "Motorcycle")
                {
                    vehicle = new FuelMotorcycle(i_LicsenseNumber);
                    vehicle.ParseChangeState(i_VehicleState);
                }
                else if(i_VehicleType == "Truck")
                {
                    vehicle = new FuelTruck(i_LicsenseNumber);
                    vehicle.ParseChangeState(i_VehicleState);
                }
            }

            return vehicle;
        }
    }
}
