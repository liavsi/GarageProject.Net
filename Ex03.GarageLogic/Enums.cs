using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        UNDER_REPAIR =1,
        REPAIRED,
        PAIED
    }
    public enum eFuelType
    {
        OCTANE95 = 1,
        OCTANE96,
        OCTANE98,
        SOLER
    }

    public enum eColor
    {
        RED = 1,
        BLUE,
        BLACK,
        GRAY
    }
    public enum eLicenseType
    {
        A = 1,
        A1,
        AA,
        B
    }

    public enum eNumOfDoors
    {
        TWO = 2,
        THREE,
        FOUR,
        FIVE
    }
    public enum eVehicleType
    {
        RegularCar = 1,
        ElectricCar,
        RegularMotorcycle,
        ElectricMotorcycle,
        RegularTruck,
    }
}
