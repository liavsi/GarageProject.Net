using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    
    internal class ElectricCar : ElectricVehicle
    {

        private Car m_Car;
        private eVehicleType m_VehicleType = eVehicleType.ElectricCar;
        public ElectricCar(string i_LicenseNumber, List<string> i_ManufacturProparties)
            : base(i_LicenseNumber, i_ManufacturProparties)
        {

        }

        public override void SetProparties(Dictionary<string, string> i_PropartiesKeyValue)
        {
            base.SetProparties(i_PropartiesKeyValue);
            m_Car.SetProparties(i_PropartiesKeyValue);
        }

        new public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            ElectricVehicle.NeededProparties(ref io_NeededProparties);
            Car.NeededProparties(ref io_NeededProparties);

        }

        public override eVehicleType GetVehicleType()
        {
            return eVehicleType.ElectricCar;
        }


    }
}
