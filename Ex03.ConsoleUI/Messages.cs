using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class Messages
    {
        private string m_printWelcomeScreen = @"Welcome to Yuval and Liav garage!
  __________
 /___||__||__\\___
|________________|
  (O)        (O)";
        private string m_printMenu = @"How may we assist you today?
Press the number of the action desired:
1. Inlist a new vehicle
2. Present the vehicles license numbers currently at the garage
3. Change a vehicles' status at the garage
4. Inflate a vehicle tires to maximum capacity
5. Fual a vehicle with gas
6. Charge an electric vehicle
7. Present a vehicles' information
8. Exit system";
        private string m_ChooseTypeOfVehicle = @"Please choose a vehicle type:
1. Regular Car
2. Electric Car
3. Regular Motorcycle
4. Electric Motorcycle
5. Regular Truck";


        private string m_VehicleAlreadyInGarage = "This vehicle is already in our garage, and now in Repair";
        private string m_InvalidInput = "The input you have tried to submit is invalid";
        public string PrintWelcomeScreen
        {
            get
            {
                return m_printWelcomeScreen;
            }

        }
        public string PrintMenu
        {
            get
            {
                return m_printMenu;
            }
        }
        public string PrintVehicleIsAlreadyInGarage
        {
            get
            {
                return m_VehicleAlreadyInGarage;
            }
        }
        public string PrintVehiclesMenu
        {
            get
            {
               return m_ChooseTypeOfVehicle;
            }
        }
        public string PrintInvalidInput
        {
            get
            {
                return m_InvalidInput;
            }
        }
    }
}
