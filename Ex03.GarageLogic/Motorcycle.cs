using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum LicenseType
    {
        A1,
        A2,
        AA,
        B1
    }
    internal class Motorcycle
    {
        private readonly int m_EngineVolume;
        private LicenseType m_LicenseType;
    }
}
