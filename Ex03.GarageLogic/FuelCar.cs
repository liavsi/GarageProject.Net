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
            m_Car = new Car();
        }
        public override void SetProparties(Dictionary<string, string> i_PropartiesKeyValue)
        {
            base.SetProparties(i_PropartiesKeyValue);
            m_Car.SetProparties(i_PropartiesKeyValue);
        }
        new public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            FuelVehicle.NeededProparties(ref io_NeededProparties);
            Car.NeededProparties(ref io_NeededProparties);
        }

        public override eVehicleType GetVehicleType()
        {
            return eVehicleType.FuelCar;
        }
        public override string ToString()
        {
            return base.ToString() + m_Car.ToString();
        }

    }
}
