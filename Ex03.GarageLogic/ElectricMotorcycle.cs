using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    
    internal class ElectricMotorcycle : ElectricVehicle
    {
        private Motorcycle m_Motorcycle;


        public ElectricMotorcycle(string i_LicenseNumber, List<string> i_ManufacturProparties)
            : base(i_LicenseNumber, i_ManufacturProparties)
        {

        }
        new public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            ElectricVehicle.NeededProparties(ref io_NeededProparties);
            Motorcycle.NeededProparties(ref io_NeededProparties);
        }

    }
}
