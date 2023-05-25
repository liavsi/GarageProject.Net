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
            Exit,
            BadInput
        }

        public void GarageUI()
        {
            bool isUserUsingSystem = true;
            
            while (isUserUsingSystem)
            {
                PrintWelcomeScreen();
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
                        ChanegeVehicleStatusInGarage();
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
                        Console.WriteLine(Messages.InvalidInput);
                        break;
                }
                ClearScrean();
            }
        }
        private void PrintWelcomeScreen()
        {
            Console.WriteLine(Messages.WelcomeScreen);
        }
        private void PrintMenu()
        {
            Console.WriteLine(Messages.Menu);
        }
        private void ClearScrean()
        {
            Console.WriteLine(Messages.PressEnterToContinue);
            Console.ReadLine();
            Ex02.ConsoleUtils.Screen.Clear();
        }
        private eUserSelect GetUsersChoice()
        {
            eUserSelect usersChoice = eUserSelect.BadInput;
            try
            {
                if (!Enum.TryParse<eUserSelect>(Console.ReadLine(), out usersChoice))
                {
                    usersChoice = eUserSelect.BadInput;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return usersChoice;


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
                    Validation.IsValidIdNumber(licenseNumber);
                    if (m_Garage.TryEnterVehicleByLicense(licenseNumber))
                    {
                        Console.WriteLine(Messages.VehicleIsAlreadyInGarage);
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
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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
                    Console.WriteLine(Messages.VehiclesMenu);
                    if (Validation.IsValidNumberChoice(out choice))
                    {
                        eVehicleType vehicleType = (eVehicleType)choice;
                        Dictionary<string, string> PropartiesKeyValue = getPropartiesFromUser(vehicleType);
                        m_Garage.CreateVehicle(i_LicenseNumber, vehicleType, PropartiesKeyValue);
                        isValidNumber = true;
                    }
                }
                catch (ValueOutOfRangeException ex_outOfRange)
                {
                    Console.WriteLine(ex_outOfRange.Message);
                }
                catch (FormatException e_format)
                {
                    Console.WriteLine(e_format.Message);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Ex02.ConsoleUtils.Screen.Clear();
            }
            
        }

        private Dictionary<string,string> getPropartiesFromUser(eVehicleType i_VehicleType)
        {
            List<string> Proparties = m_Garage.GetNeededProparties(i_VehicleType);
            Dictionary<string, string> PropartiesKeyValue = new Dictionary<string, string>();
            bool isValidInput = false;

            while(!isValidInput)
            {
                PropartiesKeyValue.Clear();
                try
                {
                    foreach (string proparty in Proparties)
                    {
                        Console.WriteLine("Please enter {0}", proparty);
                        string input = Console.ReadLine();
                        if(proparty == "Color" || proparty == "License Type")
                        {
                            input= input.ToLower();
                        }
                        else if(proparty == "Engine Volume")
                        {
                            if(!(int.TryParse(input, out int engineVolume) && engineVolume>0))
                            {
                                throw new ValueOutOfRangeException("engine volume is invalid");
                            }
                        }
                        PropartiesKeyValue.Add(proparty, input);
                    }
                    isValidInput = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            return PropartiesKeyValue;
        }

        private void GetLicenseNumbersInGarage()
        {
            Console.WriteLine("You chose to present all the license numbers in the garage");
            m_Garage.GetAllLicenseNumbers();
        }
        private void ChanegeVehicleStatusInGarage()
        {
            bool isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    Console.WriteLine("You chose to change a vehicles' status");
                    Console.WriteLine("Please enter the vehicles' license number:");
                    string licenseNumber = Console.ReadLine();
                    Console.WriteLine("Please enter new status for the vehicle: Paid | Repaired | InRepair");
                    Enum.TryParse<eVehicleStatus>(Console.ReadLine(), out eVehicleStatus vehicleStatus);
                    m_Garage.ChangeVehicleStatus(licenseNumber, vehicleStatus);
                    isValidInput = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
        public void InflateTiresToMaxCapacity()
        {
            string licenseNumber;
            Console.WriteLine("You chose to inflate the tires to the maximum capacity");
            Console.WriteLine("Please enter the vehicles' license number:");
            try
            {
                licenseNumber = Console.ReadLine();
                m_Garage.InflateWheelsToMax(licenseNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ReFuelVehicle()
        {
            Console.WriteLine("You chose to ReFuel vehicle");
             
            try
            {
                Console.WriteLine("Please enter the vehicles' license number:");
                string licenseNumber = Console.ReadLine();
                Validation.IsValidIdNumber(licenseNumber);
                if(m_Garage.GetVehicleByLicense(licenseNumber).GetType().Name == "ElectricCar")
                {
                    throw new ArgumentException("This car is on fuel");
                }
                Console.WriteLine("Please enter the gas type:");
                if(!Enum.TryParse<eFuelType>(Console.ReadLine(), out eFuelType fuelType))
                {
                    throw new ArgumentException("type of fuel does not fit");
                }
                Console.WriteLine("Please enter the amount to add:");
                float LitersToAdd = float.Parse(Console.ReadLine());
                m_Garage.ReFuelVehicle(licenseNumber, fuelType, LitersToAdd);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {

                Console.WriteLine(e.Message);
            }

       
        }
        public void ChargeVehicle()
        {

            Console.WriteLine("You chose to charge vehicle");
            Console.WriteLine("Please enter the vehicles' license number and how many minutes to charge:");
            try
            {
                string licenseNumber = Console.ReadLine();
                float hoursToAdd = float.Parse(Console.ReadLine());
                m_Garage.ChargeVehicle(licenseNumber, hoursToAdd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
        public void GetVehicleInfo()
        {
            string licenseNumber;

            Console.WriteLine("You chose to present a vehicles' information");
            Console.WriteLine("Please enter the vehicles' license number:");
            try
            {
                licenseNumber = Console.ReadLine();
                string vehicleAsString = m_Garage.GetVehicleAsString(licenseNumber);
                Console.WriteLine(vehicleAsString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
