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
        Octan95 = 1,
        Octan96,
        Octan98,
        Soler
    }

    public enum eCarColor
    {
        White = 1,
        Black,
        Yellow,
        Red
    }
    public enum eLicenseType
    {
        A = 1,
        A1,
        AA,
        B
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
