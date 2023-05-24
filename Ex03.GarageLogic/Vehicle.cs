using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected readonly string r_LicenseNumber;
        protected float m_RemainingEnergyPercentage;
        protected List<Wheel> m_Wheels;

        // NEEDED PROPARTIES BY STRING
        const string MODEL_NAME_STR = "Model Name";
        const string CURR_WHEEL_PRESSURE = "Current Wheel Pressure";
        const string WHEEL_MANUFACTURE = "Wheel Manufacture Name";
        const string CURR_ENERGY_PRECENT = "Current Energy Precentage";
        private static readonly string[] r_PropartyNames = { MODEL_NAME_STR, CURR_WHEEL_PRESSURE, WHEEL_MANUFACTURE, CURR_ENERGY_PRECENT };
    

        public Vehicle(string i_LicenseNumber, List<string> i_ManufacturProparties)
        {
            string numOfWheelsStr = i_ManufacturProparties[VehicleFactory.NumOfWheelIndex];
            string maxWheelPressureStr = i_ManufacturProparties[VehicleFactory.MaxWheelPressureIndex];
            r_LicenseNumber = i_LicenseNumber;
            if (int.TryParse(numOfWheelsStr, out int numOfWheels) && int.TryParse(maxWheelPressureStr, out int maxWheelPressure))
            {
                for (int i = 0; i < numOfWheels; i++)
                {
                    Wheel wheel = new Wheel(maxWheelPressure);
                    m_Wheels.Add(wheel);
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
            if((i_PropartiesKeyValue.TryGetValue(MODEL_NAME_STR, out m_ModelName)) &&
            (i_PropartiesKeyValue.TryGetValue(CURR_WHEEL_PRESSURE, out string currentWheelPressurStr)) &&
            (i_PropartiesKeyValue.TryGetValue(CURR_ENERGY_PRECENT, out string currentEnergyPrecentStr)) &&
            i_PropartiesKeyValue.TryGetValue(WHEEL_MANUFACTURE, out string wheelManufacture))
            {
                if (float.TryParse(currentWheelPressurStr, out float currentWheelPressure))
                {
                    foreach (Wheel wheel in m_Wheels)
                    {
                        wheel.InflateWheel(currentWheelPressure);
                        wheel.Manufactur = wheelManufacture;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
                if(float.TryParse(currentEnergyPrecentStr, out float currentEnergyPrecent))
                {
                    m_RemainingEnergyPercentage = currentEnergyPrecent;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

        }

        public override string ToString()
        {
            string vehicleString = string.Format(
           @"License Number: {0}
Model: {1}
Tires specifications:{3}
Energy Percentage: {4:0.00}%", r_LicenseNumber, m_ModelName, m_Wheels[0].ToString(), m_RemainingEnergyPercentage);

            return vehicleString;
        }
        public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            foreach(string PropartyName in r_PropartyNames)
            {
                io_NeededProparties.Add(PropartyName);  
            }
        }

        public void InflateWheelsToMax()
        {
            foreach(Wheel wheel in m_Wheels)
            {
                if(wheel != null)
                {
                    wheel.InflateWheel();
                }
            }
        }
        public abstract eVehicleType GetVehicleType();

    }
}
