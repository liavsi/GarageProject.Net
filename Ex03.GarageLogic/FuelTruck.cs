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

        }

        new public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            FuelVehicle.NeededProparties(ref io_NeededProparties);
            Truck.NeededProparties(ref io_NeededProparties);
        }
    }
}
