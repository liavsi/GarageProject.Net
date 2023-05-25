using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInfo
    {
        private string m_OwenerName;
        private string m_OwenerPhone;
        private eVehicleStatus m_VehicleStatus;

        const string OWNER_NAME = "Owner's Name";
        const string OWNER_PHONE = "Owner's Phone Number";
        private static readonly string[] r_PropartyNames = { OWNER_NAME, OWNER_PHONE };

        public VehicleInfo()
        {
            m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public static void NeededProparties(ref List<string> io_NeededProparties)
        {
            foreach (string PropartyName in r_PropartyNames)
            {
                io_NeededProparties.Add(PropartyName);
            }
        }

        public void SetProparties(Dictionary<string, string> i_PropartiesKeyValue)
        {
            if(i_PropartiesKeyValue.TryGetValue(OWNER_NAME, out m_OwenerName)
                && i_PropartiesKeyValue.TryGetValue(OWNER_PHONE, out m_OwenerPhone))
            {
                Validation.IsValidIdNumber(m_OwenerPhone);
            }
            else
            {
                throw new FormatException("didnt get needed input");
            }

        }


        public string OwenerName
        { 
            get
            { 
                return m_OwenerName;
            } 
            set 
            { 

                m_OwenerName = value;
            } 
        }

        public eVehicleStatus Status
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }
        public string OwenerPhone
        {   
            get
            { 
                return m_OwenerPhone;
            } 
            set
            {
                Validation.IsValidIdNumber(value);
                m_OwenerPhone = value;
            }
        }

        public override string ToString()
        {
            return String.Format(
@"Owner's Name: {0}
Owner's Phone Number: {1}
Vehicle Status {2}", m_OwenerName, m_OwenerPhone, VehicleStatus);
        }
        public eVehicleStatus VehicleStatus
        { get { return m_VehicleStatus; } set { m_VehicleStatus = value; } }
    }
}
