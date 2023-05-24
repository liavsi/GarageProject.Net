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
                        FuelVehicles();
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

            Console.WriteLine("You chose to inlist a new vehicle");
            Console.WriteLine("Please enter the vehicles' license number:");
            licenseNumber = Console.ReadLine();
            if(m_Garage.TryEnterCarByLicense(licenseNumber))
            {
                Console.WriteLine("This car is already in our garage, and now in Repair");
            }
            else
            {
                inputNewCar(licenseNumber);
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
                List<string> Proparties = m_Garage.GetNeededProparties(vehicleType);
                Dictionary<string, string> PropartiesKeyValue = new Dictionary<string, string>();
                foreach (string proparty in Proparties)
                {
                    Console.WriteLine("Please enter {0}", proparty);
                    string input = Console.ReadLine();
                    PropartiesKeyValue.Add(input, proparty);
                }
                m_Garage.CreateVehicle(i_LicenseNumber, vehicleType, PropartiesKeyValue);
            }
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
            m_Garage.TryEnterCarByLicense(licenseNumber);
            Console.WriteLine("Please enter the vehicles' new status:");
            vehicleStatus = Console.ReadLine();
            //need to overload to parse or something
            //m_garage.ChangeVehicleStatus(vehicleStatus); 
        }
        public void InflateTiresToMaxCapacity()
        {
            string licenseNumber;

            Console.WriteLine("You chose to inflate the tires to the maximum capacity");
            Console.WriteLine("Please enter the vehicles' license number:");
            licenseNumber = Console.ReadLine();
            m_Garage.InflateTiresToMaxCapacity(licenseNumber);
        }
        public void ReuelVehicle()
        {
            string carInfoToFuel="", currentInput, licenseNumber;
            bool isCorrectInput = false;
            Vehicle vehicle;

            Console.WriteLine("You chose to fuel vehicle");
            Console.WriteLine("Please enter the vehicles' license number:");
            licenseNumber = Console.ReadLine();
            bool isVehicleExists = m_Garage.TryGetVehicle(licenseNumber, out vehicle);

            if(isVehicleExists)
            {
                if(vehicle is FuelVehicle)
                {

                }
            }
            while (!isCorrectInput)
            {
                try
                {
                    
                    isCorrectInput = true; // Break out of the loop if input is valid
                
                }
            }
            carInfoToFuel += currentInput;
                Console.WriteLine("Please enter the type of fuel:");
                currentInput = Console.ReadLine();
                carInfoToFuel += currentInput;
                Console.WriteLine("Please enter the amount of fuel:");
                currentInput = Console.ReadLine();
                carInfoToFuel += currentInput;
                m_garage.FuelVehicle(carInfoToFuel);
                
                catch (ValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again:");
                }
            
            
        }
        public void ChargeVehicle()
        {
            string carInfoToCharge;

            Console.WriteLine("You chose to charge vehicle");
            Console.WriteLine("Please enter the vehicles' license number and how many minutes to charge:");
            carInfoToCharge = Console.ReadLine();
            m_garage.ChargeVehicle(carInfoToCharge);
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
