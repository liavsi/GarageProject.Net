using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        //private VehicleInfo m_VehicleInfo;
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, int i_NumOfWheels, float i_MaxWheelPressure, string i_WheelsManufacture)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergyPercentage = i_RemainingEnergyPercentage;
            m_Wheels = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel wheel = new Wheel(i_WheelsManufacture, i_MaxWheelPressure);
                m_Wheels.Add(wheel);
            } 
        }
        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public List<Wheel> WheelsList
        {
            get
            {
                return r_WheelsList;
            }
        }
        public VehicleOwner Owner
        {
            get
            {
                return m_Owner;
            }

            set
            {
                m_Owner = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public eVehicleType VehicleType
        {
            get
            {
                return m_VehicleType;
            }

            set
            {
                m_VehicleType = value;
            }
        }
    }
}
