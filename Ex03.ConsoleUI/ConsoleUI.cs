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
        Messages messageToConsole = new Messages();
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
                        ReFuelVehicle();
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
            Console.WriteLine(messageToConsole.PrintWelcomeScreen);
        }
        private void PrintMenu()
        {
            Console.WriteLine(messageToConsole.PrintMenu);
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
            bool isValidNumber = false;
            
            Console.WriteLine("You chose to inlist a new vehicle");
            while (!isValidNumber)
            {
                try
                {
                    Console.WriteLine("Please enter the vehicles' license number:");
                    licenseNumber = Console.ReadLine();
                    Validation.IsValidLicenseNumber(licenseNumber);
                    if (m_Garage.TryEnterVehicleByLicense(licenseNumber))
                    {
                        Console.WriteLine(messageToConsole.PrintVehicleIsAlreadyInGarage);
                    }
                    else
                    {
                        inputNewVehicle(licenseNumber);
                    }
                    isValidNumber = true;
                }
                catch (ValueOutOfRangeException ex_outOfRange)
                {
                    Console.WriteLine(ex_outOfRange.Message);
                }
                catch(ArgumentException ex_Argument)
                {
                    Console.WriteLine(ex_Argument.Message);
                }
            }
        }

        private void inputNewVehicle(string i_LicenseNumber)
        {
            int choice;
            bool isValidNumber = false;

            while (!isValidNumber)
            {
                try
                {
                    Console.WriteLine(messageToConsole.PrintVehiclesMenu);
                    if (int.TryParse(Console.ReadLine(), out choice) && Enum.IsDefined(typeof(eVehicleType), choice))
                    {
                        if (choice > 5 || choice < 1)
                        {
                            throw new ValueOutOfRangeException(choice, 1, 5);
                        }
                        eVehicleType vehicleType = (eVehicleType)choice;
                        Dictionary<string, string> PropartiesKeyValue = getPropartiesFromUser(vehicleType);
                        m_Garage.CreateVehicle(i_LicenseNumber, vehicleType, PropartiesKeyValue);
                        isValidNumber = true;
                    }
                    else
                    {
                        Console.WriteLine(messageToConsole.PrintInvalidInput);
                    }
                }
                catch(ValueOutOfRangeException ex_outOfRange)
                {
                    Console.WriteLine(ex_outOfRange.Message);
                }
                    
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
            m_Garage.GetAllLicenseNumbers();
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
            m_Garage.InflateWheelsToMax(licenseNumber);
        }
        public void ReFuelVehicle()
        {
            Console.WriteLine("You chose to ReFuel vehicle");
            Console.WriteLine("Please enter the vehicles' license number Gas type and Liters:");
            string licenseNumber = Console.ReadLine();
            Enum.TryParse<eFuelType>(Console.ReadLine(),out eFuelType fuelType);
            float LitersToAdd = float.Parse(Console.ReadLine());
            m_Garage.ReFuelVehicle(licenseNumber, fuelType, LitersToAdd);
       
        }
        public void ChargeVehicle()
        {

            Console.WriteLine("You chose to charge vehicle");
            Console.WriteLine("Please enter the vehicles' license number and how many minutes to charge:");
            string licenseNumber = Console.ReadLine();
            float hoursToAdd = float.Parse(Console.ReadLine());
            m_Garage.ChargeVehicle(licenseNumber, hoursToAdd);
           

        }
        public void GetVehicleInfo()
        {
            string licenseNumber;

            Console.WriteLine("You chose to present a vehicles' information");
            Console.WriteLine("Please enter the vehicles' license number:");
            licenseNumber = Console.ReadLine();
            string vehicleAsString = m_Garage.GetVehicleAsString(licenseNumber);
            Console.WriteLine(vehicleAsString);
        }
    }
}
