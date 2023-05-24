using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class FuelVehicle : Vehicle
    {
        protected eFuelType m_FuelType;
        protected float m_FuelTankCapacity;
        protected float m_CurrentFuelLevel;

        public FuelVehicle(string i_LicenseNumber, List<string> i_ManufacturProparties)
            : base(i_LicenseNumber, i_ManufacturProparties)
        {
            string fuelTypeStr = i_ManufacturProparties[VehicleFactory.FuelTypeIndex];
            string fuelTankCapacityStr = i_ManufacturProparties[VehicleFactory.FuelTankIndex];
            if (!(Enum.TryParse<eFuelType>(fuelTypeStr, out m_FuelType) && float.TryParse(fuelTankCapacityStr,out m_FuelTankCapacity)))
            {
                throw new Exception("coudnt read");
            }
        }
        public override void SetProparties(Dictionary<string, string> i_PropartiesKeyValue)
        {
            base.SetProparties(i_PropartiesKeyValue);
            m_CurrentFuelLevel = m_FuelTankCapacity * m_RemainingEnergyPercentage;

        }

        new public static void NeededProparties(ref List<string> io_NeededProparties) 
        {
            Vehicle.NeededProparties(ref io_NeededProparties);
        }

        public override eVehicleType GetVehicleType()
        {
            return eVehicleType.RegularCar;
        }
        public void Refuel(eFuelType i_FuelType, float i_FuelAmount)
        {
            if (m_FuelType == i_FuelType)
            {
                if (m_CurrentFuelLevel + i_FuelAmount <= m_FuelTankCapacity)
                {
                    m_CurrentFuelLevel += i_FuelAmount;
                }
                else
                {
                    throw new ValueOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public override string ToString()
        {
            string FuelString = base.ToString() + string.Format(@"Engine: Fuel
FuelType: {0}
Fuel Tank Capacity: {1}
Current Liters Remain: {2}", m_FuelType, m_FuelTankCapacity, m_CurrentFuelLevel);
            return FuelString;
        }
    }
}
