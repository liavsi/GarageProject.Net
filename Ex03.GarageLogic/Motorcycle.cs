﻿using System;
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
        private int m_EngineVolume;
        private LicenseType m_LicenseType;

        const string LICENSE_TYPE = "License Type";
        const string ENGINE_VOLUME = "Engine Volume";

        public void SetProparties(Dictionary<string, string> i_PropartiesKeyValue)
        {
            if (!(Enum.TryParse<LicenseType>(i_PropartiesKeyValue[LICENSE_TYPE], out m_LicenseType) &&
            (int.TryParse(i_PropartiesKeyValue[ENGINE_VOLUME], out m_EngineVolume))))
            {
                throw new ArgumentException();
            }
        }
        public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            io_NeededProparties.Add(LICENSE_TYPE);
            io_NeededProparties.Add(ENGINE_VOLUME);
        }
    }
}