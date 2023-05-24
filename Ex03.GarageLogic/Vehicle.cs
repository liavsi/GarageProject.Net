using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private readonly string r_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;


        public Vehicle(string i_LicenseNumber, List<string> i_ManufacturProparties)
        {
            string numOfWheelsStr = i_ManufacturProparties[VehicleFactory.NumOfWheelIndex];
            string maxWheelPressureStr = i_ManufacturProparties[VehicleFactory.MaxWheelPressureIndex];
            r_LicenseNumber = i_LicenseNumber;
            if (int.TryParse(numOfWheelsStr, out int numOfWheels) && int.TryParse(maxWheelPressureStr, out int maxWheelPressure))
            {
                for (int i = 0; i < numOfWheels; i++)
                {
                    // todo
                    //Wheel wheel = new Wheel(maxWheelPressure);
                    //m_Wheels.Add(wheel);
                }
            }
            else
            {
                throw new Exception("bad manufacture settings");
            }
        }


    }
}
