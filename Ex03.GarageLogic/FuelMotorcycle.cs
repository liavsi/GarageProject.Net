using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : FuelVehicle
    {
        private Motorcycle m_Motorcycle;


        public FuelMotorcycle(string i_LicenseNumber, List<string> i_ManufacturProparties)
            : base(i_LicenseNumber, i_ManufacturProparties)
        {

        }

        new public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            FuelVehicle.NeededProparties(ref io_NeededProparties);
            Motorcycle.NeededProparties(ref io_NeededProparties);

        }

    }
}

