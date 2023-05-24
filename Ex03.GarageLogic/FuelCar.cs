using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelCar : FuelVehicle
    {

        Car m_Car;



        public FuelCar(string i_LicenseNumber, List<string> i_ManufacturProparties)
            : base(i_LicenseNumber, i_ManufacturProparties)
        {

        }

        new public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            FuelVehicle.NeededProparties(ref io_NeededProparties);
            Car.NeededProparties(ref io_NeededProparties);
        }

    }
}
