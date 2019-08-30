using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Exceptions;
using eMainMenuOptions = Ex03.ConsoleUI.Utils.eMainMenuOptions;
using eTicketStatus = Ex03.GarageLogic.Garage.eTicketStatus;
using ArgumentsCollection = Ex03.GarageLogic.ArgumentsUtils.ArgumentsCollection;

namespace Ex03.ConsoleUI
{
    public static class UIManager
    {
        private static GarageLogic.Garage m_Garage;

        public static void Run()
        {
            m_Garage = new Garage();

            Utils.ShowMainMenu();
            int userChoice = Utils.GetUserMenuChoice() - 1;
            while (!Enum.IsDefined(typeof(eMainMenuOptions), userChoice))
            {
                Console.WriteLine("Invalid input: Choice made not in range. Please try again...");
            }
            eMainMenuOptions mainMenuOption = (eMainMenuOptions)userChoice;

            switch(mainMenuOption)
            {
                case eMainMenuOptions.AddVehicle:
                    {
                        AddVehicle();
                        break;
                    }

                case eMainMenuOptions.ShowVehiclesLicensePlateNumbers:
                    {
                        showVehiclesLicensePlateNumbers();
                        break;
                    }

                case eMainMenuOptions.ChangeVehicleStatus:
                    {
                        changeVehicleStatus();
                        break;
                    }
                case eMainMenuOptions.InflateWheels:
                    {
                        inflateWheels();
                        break;
                    }
                case eMainMenuOptions.FuelGasolineVehicle:
                    {
                        fuelGasolineVehicle();
                        break;
                    }
                case eMainMenuOptions.ChargeElectricVehicle:
                    {
                        chargeElectricVehicle();
                        break;
                    }
                case eMainMenuOptions.GetVehicleInfoByLicensePlateNumber:
                    {
                        getVehicleInfoByLicensePlateNumber();
                        break;
                    }
                case eMainMenuOptions.QuitProgram:
                    {

                        break;
                    }
            }
        }

        private static void AddVehicle()
        {
            string licensePlateNumber = Utils.GetLicensePlateNumber();
            if (m_Garage.HasVehicleVisited(licensePlateNumber))
            {
                Console.WriteLine("Vehicle under License Plate Number '{0}' already in the system.", licensePlateNumber);
                changeVehicleStatus(licensePlateNumber, eTicketStatus.InProgress.ToString());
            }
            else
            {
                string ownerName = Utils.GetOwnerName();
                string ownerPhoneNumber = Utils.GetOwnerPhoneNumber();
                string vehicleTypeString = GetVehicleType();
                ArgumentsCollection vehicleArguments = m_Garage.GetArgumentsByVehicleType(vehicleTypeString);
                RunArgumentsWithUser(vehicleArguments);
                m_Garage.AddVehicleToGarage(vehicleArguments, vehicleTypeString, ownerName, ownerPhoneNumber);
                Console.WriteLine("The Vehicle was added Successfully.");
            }
        }

        public static string GetVehicleType()
        {
            string[] supportedVehicleTypes = m_Garage.GetSupportedVehicles();
            showSupportedVehicleTypes(supportedVehicleTypes);
            int UserChoice = Utils.GetUserMenuChoice();
            return supportedVehicleTypes[UserChoice - 1];
        }

        private static void showSupportedVehicleTypes(string[] i_supportedVehicleTypes)
        {
            StringBuilder supportedVehicleTypesMenu = new StringBuilder("Please choose the Vehicle's Type from the following options:");
            for (int i = 0; i < i_supportedVehicleTypes.Length; i++)
            {
                supportedVehicleTypesMenu.AppendFormat(
                    "{0}{1}. {2}.",
                    Environment.NewLine,
                    i + 1,
                    i_supportedVehicleTypes[i]);
            }
            Console.WriteLine(supportedVehicleTypesMenu);
        }

        public static string GetVehicleStatus()
        {
            string[] vehicleStatusStrings = Enum.GetNames(typeof(eTicketStatus));
            showDesiredVehicleStatus(vehicleStatusStrings);
            int UserChoice = Utils.GetUserMenuChoice();
            return vehicleStatusStrings[UserChoice - 1];
        }

        public static void showDesiredVehicleStatus(string[] i_VehicleStatusStrings)
        {
            //string[] vehicleStatusStrings = Enum.GetNames(typeof(eTicketStatus));
            StringBuilder vehicleStatusMenu = new StringBuilder("Please provide the Vehicle's desired status from the following options:");
            for (int i = 0; i < i_VehicleStatusStrings.Length; i++)
            {
                vehicleStatusMenu.AppendFormat("{0}{1}. {2}.", Environment.NewLine, i + 1, i_VehicleStatusStrings[i]);
            }
            Console.WriteLine(vehicleStatusMenu);
        }

        private static void showVehiclesLicensePlateNumbers()
        {

        }

        private static void changeVehicleStatus(string i_LicensePlateNumber, string i_NewStatus)
        {
            bool hasChangedStatus = m_Garage.ChangeVehicleStatus(i_LicensePlateNumber, i_NewStatus);
            if (hasChangedStatus)
            {
                Console.WriteLine("Vehicle's Status was set to '{0}'", i_NewStatus);
            }
            else
            {
                Console.WriteLine("Vehicle's Status was already set to '{0}'", i_NewStatus);
            }
        }

        // TBD: Should we change method name ????
        private static void changeVehicleStatus()
        {
            string licensePlateNumber = Utils.GetLicensePlateNumber();
            string newStatus = GetVehicleStatus();
            changeVehicleStatus(licensePlateNumber, newStatus);
        }

        private static void inflateWheels()
        {

        }

        private static void fuelGasolineVehicle()
        {

        }

        private static void chargeElectricVehicle()
        {

        }

        private static void getVehicleInfoByLicensePlateNumber()
        {

        }

        // ?????
        private static void quitProgram()
        {

        }

        private static void RunArgumentsWithUser(ArgumentsCollection i_Arguments)
        {
            System.Console.WriteLine("Please provide the following information:");
            for (int i = 0; i < i_Arguments.Length; i++)
            //foreach (DictionaryEntry pairEntry in i_Arguments)
            {
                //ArgumentWrapper argument = pairEntry.Value as ArgumentWrapper;
                ArgumentWrapper argument = i_Arguments[i];
                bool isInputRequired = true;
                int choiceRowCounter = 1;
                StringBuilder argumentMessage = new StringBuilder();
                argumentMessage.AppendFormat("{0}:{1}", argument.DisplayName, Environment.NewLine);
                if(argument.IsStrictToOptionalValues)
                {
                    argumentMessage.AppendLine("Choose from the following options");
                    foreach (string option in argument.OptionalValues)
                    {
                        argumentMessage.AppendFormat("{0}.{1}{2}", choiceRowCounter++, option, Environment.NewLine);

                    }
                }
                while(isInputRequired)
                {

                    try
                    {
                        argument.InjectValue(System.Console.ReadLine());
                        isInputRequired = false;
                    }
                    catch (ValueOutOfRangeException valueOutOfRangeException)
                    {
                        System.Console.WriteLine("Error: {0}", valueOutOfRangeException.Message);
                    }
                
                }
            }
        }
    }
}
