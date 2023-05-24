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

        const string MODEL_NAME_STR = "Model Name";
        const string CURR_WHEEL_PRESSURE = "Current Wheel Pressure";
        const string CURR_ENERGY_PRECENT= "Current Energy Precentage";

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

        public virtual void SetProparties(Dictionary<string,string> i_PropartiesKeyValue)
        {
            // todo - check if valid input - else throw
            i_PropartiesKeyValue.TryGetValue(MODEL_NAME_STR, out m_ModelName);
            i_PropartiesKeyValue.TryGetValue(CURR_WHEEL_PRESSURE, out string currentWheelPressurStr);
            i_PropartiesKeyValue.TryGetValue(CURR_ENERGY_PRECENT, out string currentEnergyPrecentStr);

        }

        public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            io_NeededProparties.Add(MODEL_NAME_STR);
            io_NeededProparties.Add(CURR_WHEEL_PRESSURE);
            io_NeededProparties.Add(CURR_ENERGY_PRECENT);
        }


    }
}
