using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class ConsoleUI
    {
        private GarageManager m_Garage = new GarageManager();
        private Validation m_validation = new Validation();
        public void GarageUI()
        {
            int usersChoice;
            bool isUserUsingSystem = true;

            PrintWelcomeScreen();
            while (isUserUsingSystem)
            { 
                PrintMenu();
                usersChoice = GetUsersChoice();
                switch (usersChoice)
                {
                    case 1:
                        InlistNewVehicle();
                        break;
                    case 2:
                        GetLicenseNumbersInGarage();
                        break;
                    case 3:
                        ChanegeVehicleStatus();
                        break;
                    case 4:
                        InflateTiresToMaxCapacity();
                        break;
                    case 5:
                        FuelVehicle();
                        break;
                    case 6:
                        ChargeVehicle();
                        break;
                    case 7:
                        GetVehicleInfo();
                        break;
                    case 8:
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
        private int GetUsersChoice()
        {
            string usersChoice = Console.ReadLine();
            return int.Parse(usersChoice);
        }
        private void InlistNewVehicle()
        {
            string licenseNumber;

            Console.WriteLine("You chose to inlist a new vehicle");
            Console.WriteLine("Please enter the vehicles' license number:");
            licenseNumber = Console.ReadLine();
            m_Garage.InlistNewVehicle(licenseNumber);
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
            m_Garage.InlistNewVehicle(licenseNumber);
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
