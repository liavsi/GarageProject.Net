using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class ConsoleUI
    {

        private Garage m_Garage = new Garage();
        public enum eUserSelect
        {
            AddNewVehicle = 1,
            DisplayLicensePlates,
            ChangeVehicleState,
            FillAirInWheels,
            ReFuelVehicle,
            ChargeVehicle,
            DisplayCarDetails,
            Exit
        }

        public void GarageUI()
        {
            bool isUserUsingSystem = true;
            PrintWelcomeScreen();

            while (isUserUsingSystem)
            { 
                PrintMenu();
                eUserSelect userSelect = GetUsersChoice();
                switch (userSelect)
                {
                    case eUserSelect.AddNewVehicle:
                        InlistNewVehicle();
                        break;
                    case eUserSelect.DisplayLicensePlates:
                        GetLicenseNumbersInGarage();
                        break;
                    case eUserSelect.ChangeVehicleState:
                        ChanegeVehicleStatus();
                        break;
                    case eUserSelect.FillAirInWheels:
                        InflateTiresToMaxCapacity();
                        break;
                    case eUserSelect.ReFuelVehicle:
                        ReFuelVehicles();
                        break;
                    case eUserSelect.ChargeVehicle:
                        ChargeVehicle();
                        break;
                    case eUserSelect.DisplayCarDetails:
                        GetVehicleInfo();
                        break;
                    case eUserSelect.Exit:
                        Console.WriteLine("Goodbye");
                        isUserUsingSystem = false;
                        break;
                    default:
                        Console.WriteLine("Invalid number.");
                        break;
                }
            }
        }
        private void PrintWelcomeScreen()
        {
            Console.WriteLine("Welcome to Yuval and Liav garage!");
            Console.WriteLine("  __________");
            Console.WriteLine(" /___||__||__\\___");
            Console.WriteLine("|________________|");
            Console.WriteLine("  (O)        (O)");
        }
        private void PrintMenu()
        {
            Console.WriteLine("How may we assist you today?");
            Console.WriteLine("Press the number of the action desired:");
            Console.WriteLine("1. Inlist a new vehicle");
            Console.WriteLine("2. Present the vehicles license numbers currently at the garage");
            Console.WriteLine("3. Change a vehicles' status at the garage");
            Console.WriteLine("4. Inflate a vehicle tires to maximum capacity");
            Console.WriteLine("5. Fual a vehicle with gas");
            Console.WriteLine("6. Charge an electric vehicle");
            Console.WriteLine("7. Present a vehicles' information");
            Console.WriteLine("8. Exit system");
        }
        private eUserSelect GetUsersChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int usersChoice))
            {
                // Validation.checkRange(usersChoice, 1, 8);
            }
            return (eUserSelect)usersChoice;
        }
        private void InlistNewVehicle()
        {
            string licenseNumber;
            try
            {
                Console.WriteLine("You chose to inlist a new vehicle");
                Console.WriteLine("Please enter the vehicles' license number:");
                licenseNumber = Console.ReadLine();
                Validation.IsValidLicenseNumber(licenseNumber);
                if(m_Garage.TryEnterCarByLicense(licenseNumber))
                {
                    Console.WriteLine("This car is already in our garage, and now in Repair");
                }
                else
                {
                    inputNewCar(licenseNumber);
                }
            }
            catch (ArgumentException ex)
            {
                
            }
            

        }

        private void inputNewCar(string i_LicenseNumber)
        {
            Console.WriteLine("Please choose a vehicle type:");
            Console.WriteLine("1. Regular Car");
            Console.WriteLine("2. Electric Car");
            Console.WriteLine("3. Regular Motorcycle");
            Console.WriteLine("4. Electric Motorcycle");
            Console.WriteLine("5. Regular Truck");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && Enum.IsDefined(typeof(eVehicleType), choice))
            {
                eVehicleType vehicleType = (eVehicleType)choice;
                Dictionary<string, string> PropartiesKeyValue = getPropartiesFromUser(vehicleType);
                m_Garage.CreateVehicle(i_LicenseNumber, vehicleType, PropartiesKeyValue);
            }
        }

        private Dictionary<string,string> getPropartiesFromUser(eVehicleType i_VehicleType)
        {
            List<string> Proparties = m_Garage.GetNeededProparties(i_VehicleType);
            Dictionary<string, string> PropartiesKeyValue = new Dictionary<string, string>();
            foreach (string proparty in Proparties)
            {
                Console.WriteLine("Please enter {0}", proparty);
                string input = Console.ReadLine();
                PropartiesKeyValue.Add(proparty, input);
            }
            return PropartiesKeyValue;
        }

        private void GetLicenseNumbersInGarage()
        {
            Console.WriteLine("You chose to present all the license numbers in the garage");
            //go through the collection
        }
        private void ChanegeVehicleStatus()
        {
            string licenseNumber;
            string vehicleStatus;

            Console.WriteLine("You chose to change a vehicles' status");
            Console.WriteLine("Please enter the vehicles' license number:");
            licenseNumber = Console.ReadLine();
            Vehicle vehicle = m_Garage.GetVehicleByLicense(licenseNumber);
            eVehicleType vehicleType = vehicle.GetVehicleType();
            Dictionary<string, string> PropartiesKeyValue = getPropartiesFromUser(vehicleType);
            m_Garage.UpdateVehicleState(vehicle, vehicleType, PropartiesKeyValue);
        }
        public void InflateTiresToMaxCapacity()
        {
            string licenseNumber;

            Console.WriteLine("You chose to inflate the tires to the maximum capacity");
            Console.WriteLine("Please enter the vehicles' license number:");
            licenseNumber = Console.ReadLine();
            m_Garage.InflateTiresToMaxCapacity(licenseNumber);
        }
        public void ReFuelVehicle()
        {
            Console.WriteLine("You chose to ReFuel vehicle");
            Console.WriteLine("Please enter the vehicles' license number Gas type and Liters:");
            string licenseNumber = Console.ReadLine();
            Enum.TryParse<eFuelType>(Console.ReadLine(),out eFuelType fuelType);
            float LitersToAdd = float.Parse(Console.ReadLine());
            if (!m_Garage.ReFuelVehicle(licenseNumber, fuelType, LitersToAdd))
            {
                throw new ArgumentException("This License Number is not of an electric car in our garage");
            }


        }
        public void ChargeVehicle()
        {

            Console.WriteLine("You chose to charge vehicle");
            Console.WriteLine("Please enter the vehicles' license number and how many minutes to charge:");
            string licenseNumber = Console.ReadLine();
            float hoursToAdd = float.Parse(Console.ReadLine());
            if(!m_Garage.ChargeVehicle(licenseNumber, hoursToAdd))
            {
                throw new ArgumentException("This License Number is not of an electric car in our garage");
            }

        }
        public void GetVehicleInfo()
        {
            string licenseNumber;

            Console.WriteLine("You chose to present a vehicles' information");
            Console.WriteLine("Please enter the vehicles' license number:");
            licenseNumber = Console.ReadLine();
            m_garage.ShowVehicleInfo(licenseNumber);
        }
    }
}
