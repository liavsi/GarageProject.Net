using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelTruck: FuelVehicle
    {
        private Truck m_Truck;

        public FuelTruck(string i_LicenseNumber, List<string> i_ManufacturProparties)
            : base(i_LicenseNumber, i_ManufacturProparties)
        {
            m_Truck = new Truck();
        }
        public override void SetProparties(Dictionary<string, string> i_PropartiesKeyValue)
        {
            base.SetProparties(i_PropartiesKeyValue);
            m_Truck.SetProparties(i_PropartiesKeyValue);
        }
        new public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            FuelVehicle.NeededProparties(ref io_NeededProparties);
            Truck.NeededProparties(ref io_NeededProparties);
        }

        public override eVehicleType GetVehicleType()
        {
            return eVehicleType.FuelTruck;
        }

        public override string ToString()
        {
            string FuelTruckStr = base.ToString() + m_Truck.ToString();
            return FuelTruckStr;
        }
    }
}
