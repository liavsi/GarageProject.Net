using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        InRepair =1,
        Repaired,
        Paid
    }
    public enum eFuelType
    {
        octan95 = 1,
        octan96,
        octan98,
        soler
    }

    public enum eCarColor
    {
        white = 1,
        black,
        yellow,
        red
    }
    public enum eLicenseType
    {
        a1 = 1,
        a2,
        aa,
        b
    }


    public enum eVehicleType
    {
        FuelCar = 1,
        ElectricCar,
        FuelMotorcycle,
        ElectricMotorcycle,
        FuelTruck,
    }
}
