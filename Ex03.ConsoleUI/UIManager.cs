using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net.Security;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Exceptions;
using eMainMenuOptions = Ex03.ConsoleUI.Utils.eMainMenuOptions;
using eTicketStatus = Ex03.GarageLogic.Garage.eTicketStatus;
using ArgumentsCollection = Ex03.GarageLogic.ArgumentsUtils.ArgumentsCollection;
using Exception = System.Exception;

namespace Ex03.ConsoleUI
{
    public static class UIManager
    {
        private static GarageLogic.Garage m_Garage;

        public static void Run()
        {
            m_Garage = new Garage();

            bool terminateProgram = false;

            while (!terminateProgram)
            {
                Console.Clear();
                Utils.ShowMainMenu();
                int userChoice = Utils.GetUserMenuChoice(Enum.GetNames(typeof(eMainMenuOptions)).Length, 1) - 1;
                while (!Enum.IsDefined(typeof(eMainMenuOptions), userChoice))
                {
                    Console.WriteLine("Invalid input: Choice made not in range. Please try again...");
                }

                eMainMenuOptions mainMenuOption = (eMainMenuOptions)userChoice;

                switch (mainMenuOption)
                {
                    case eMainMenuOptions.AddVehicle:
                        {
                            try
                            {
                                AddVehicle();
                            }
                            catch (FormatException)
                            {
                                System.Console.WriteLine("Failed to Add vehicle: incorrect type was inserted");
                            }
                            catch (ValueOutOfRangeException valueOutOfRangeException)
                            {
                                System.Console.WriteLine("Failed to Add vehicle: {0}", valueOutOfRangeException.Message);
                            }
                            catch (ArgumentException)
                            {
                                System.Console.WriteLine("Failed to Add vehicle: input is invalid");
                            }

                            break;
                        }

                    case eMainMenuOptions.ShowVehiclesLicensePlateNumbers:
                        {
                            showVehiclesLicensePlateNumbers();
                            break;
                        }

                    case eMainMenuOptions.ChangeVehicleStatus:
                        {
                            try
                            {
                                changeVehicleStatus();
                            }
                            catch (KeyNotFoundException exception)
                            {
                                Console.WriteLine("Failed to change the vehicle's status: {0}", exception.Message);
                                ////System.Console.WriteLine("Failed to change vehicle status: vehicle does not exist");
                            }

                            break;
                        }

                    case eMainMenuOptions.InflateWheelsToMaximum:
                        {
                            try
                            {
                                inflateWheelsToMaximum();
                            }
                            catch (KeyNotFoundException exception)
                            {
                                Console.WriteLine("Error: Failed to inflate vehicle wheels: {0}", exception.Message);
                            }

                            break;
                        }

                    case eMainMenuOptions.FuelGasolineVehicle:
                        {
                            try
                            {
                                fuelGasolineVehicle();
                            }
                            catch(FormatException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                            catch(ArgumentException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }

                            break;
                        }

                    case eMainMenuOptions.ChargeElectricVehicle:
                        {
                            try
                            {
                                chargeElectricVehicle();
                            }
                            catch(ValueOutOfRangeException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                            catch (FormatException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                            catch (ArgumentException exception)
                            {
                                if (exception.ParamName.Equals(string.Empty))
                                {
                                    Console.WriteLine(exception.Message);
                                }
                                else
                                {
                                    throw;
                                }
                            }
                            
                            break;
                        }

                    case eMainMenuOptions.GetVehicleInfoByLicensePlateNumber:
                        {
                            try
                            {
                                getVehicleInfoByLicensePlateNumber();
                            }
                            catch (KeyNotFoundException exception)
                            {
                                System.Console.WriteLine("Failed to retrieve vehicle info: {0}", exception.Message);
                            }

                            break;
                        }

                    case eMainMenuOptions.QuitProgram:
                        {
                            terminateProgram = true;
                            break;
                        }
                }

                if (!terminateProgram)
                {
                    promptToContinue();
                }
            }
        }

        private static void promptToContinue()
        {
            Console.WriteLine("{0}Press Enter to continue...", Environment.NewLine);
            Console.Read();
            Console.Read();
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

                runArgumentsWithUser(vehicleArguments, licensePlateNumber);
                m_Garage.AddVehicleToGarage(vehicleArguments, vehicleTypeString, ownerName, ownerPhoneNumber);
                Console.WriteLine("The Vehicle was added Successfully.");
            }
        }

        public static string GetVehicleType()
        {
            string[] supportedVehicleTypes = m_Garage.GetSupportedVehicles();
            showSubMenu(supportedVehicleTypes, "Please choose the Vehicle's Type from the following options:");
            int userChoice = Utils.GetUserMenuChoice(supportedVehicleTypes.Length, 1);
            return supportedVehicleTypes[userChoice - 1];
        }

        public static string GetEnergyType()
        {
            string[] supportedEnergyTypes = m_Garage.GetSupportedEnergyTypes();
            showSubMenu(supportedEnergyTypes, "Please choose the Vehicle's Energy Type from the following options:");
            int userChoice = Utils.GetUserMenuChoice(supportedEnergyTypes.Length, 1);
            return supportedEnergyTypes[userChoice - 1];
        }

        public static string GetGasolineType()
        {
            string[] supportedGasolineTypes = m_Garage.GetSupportedGasolineTypes();
            showSubMenu(supportedGasolineTypes, "Please choose a Gasoline Type from the following options:");
            int userChoice = Utils.GetUserMenuChoice(supportedGasolineTypes.Length, 1);
            return supportedGasolineTypes[userChoice - 1];
        }

        private static void showSubMenu(string[] i_MenuOptions, string i_UserPromptMessage)
        {
            StringBuilder subMenu = new StringBuilder(i_UserPromptMessage);
            int rowCounter = 0;

            foreach (string option in i_MenuOptions)
            {
                subMenu.AppendFormat(
                    "{0}\t{1}. {2}",
                    Environment.NewLine,
                    ++rowCounter,
                    option);
            }

            Console.WriteLine(subMenu);
        }

        public static string GetVehicleStatus()
        {
            string[] vehicleStatusStrings = Enum.GetNames(typeof(eTicketStatus));
            showSubMenu(vehicleStatusStrings, "Please provide the Vehicle's status from the following options:");
            int userChoice = Utils.GetUserMenuChoice(vehicleStatusStrings.Length, 1);

            return vehicleStatusStrings[userChoice - 1];
        }

        private static void showVehiclesLicensePlateNumbers()
        {
            string[] promptOptions = new string[] { "Vehicle Status", "Retrieve all" };
            showSubMenu(promptOptions, "Retrieve License Plate Numbers by:");
            int userChoice = Utils.GetUserMenuChoice(promptOptions.Length, 1);
            string[] licensePlateNumberArray;
            List<string> licensePlateNumbersList = null;
            StringBuilder outputMessage = new StringBuilder();

            if (userChoice == 1)
            {
                string vehicleStatus = GetVehicleStatus();
                licensePlateNumbersList = m_Garage.GetListOfLicensePlateNumbers(vehicleStatus);
                licensePlateNumberArray = licensePlateNumbersList.ToArray();
                outputMessage.AppendFormat("Vehicle License Plate Numbers of status '{0}' found:", vehicleStatus);
            }
            else
            {
                licensePlateNumbersList = m_Garage.GetListOfLicensePlateNumbers();
                licensePlateNumberArray = licensePlateNumbersList.ToArray();
                outputMessage.AppendFormat("All available License Plate Numbers:");
            }

            showSubMenu(licensePlateNumberArray, outputMessage.ToString());
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

        private static void changeVehicleStatus()
        {
            string licensePlateNumber = Utils.GetLicensePlateNumber();

            if (!m_Garage.HasVehicleVisited(licensePlateNumber))
            {
                string message = string.Format(
                    "The License Plate Number'{0} was not found in the system",
                    licensePlateNumber);
                throw new KeyNotFoundException(message);
                ////System.Console.WriteLine("Vehicle number does not exist!");
                ////return;
            }

            string newStatus = GetVehicleStatus();
            changeVehicleStatus(licensePlateNumber, newStatus);
        }

        private static void inflateWheelsToMaximum()
        {
            string licensePlateNumber = Utils.GetLicensePlateNumber();

            if (m_Garage.HasVehicleVisited(licensePlateNumber))
            {
                m_Garage.InflateWheelsToMaximum(licensePlateNumber);
            }
            else
            {
                throw new KeyNotFoundException("Vehicle's License Plate Number was not found.");
            }
        }

        private static void fuelGasolineVehicle()
        {
            string licensePlateNumber = Utils.GetLicensePlateNumber();
            string gasolineType = GetGasolineType();
            string gasolineAmountString = Utils.GetGasolineAmountToAdd();
            float gasolineAmount;

            if (!float.TryParse(gasolineAmountString, out gasolineAmount))
            {
                throw new FormatException("Expected a float type value for Gasoline amount.");
            }

            m_Garage.FuelGasolineVehicle(licensePlateNumber, gasolineType, gasolineAmount);
            Console.WriteLine("The Vehicle's Gasoline Tank was successfully added with {0} Liters.", gasolineAmount);
        }

        private static void chargeElectricVehicle()
        {
            string licensePlateNumber = Utils.GetLicensePlateNumber();
            string electricityMinutesToAddString = Utils.GetElectricityAmountToAdd();
            float electricityMinutesToAdd;

            if (!float.TryParse(electricityMinutesToAddString, out electricityMinutesToAdd))
            {
                throw new FormatException("Error: Expected a float type for electricity number of minutes to add");
            }

            float electricityHoursToAdd = electricityMinutesToAdd / 60.0f;
            m_Garage.ChargeElectricVehicle(licensePlateNumber, electricityHoursToAdd);
            Console.WriteLine("The Vehicle's Battery was successfully added with {0} Working Minutes.", electricityMinutesToAdd);
        }

        private static void getVehicleInfoByLicensePlateNumber()
        {
            string licensePlateNumber = Utils.GetLicensePlateNumber();

            if (!m_Garage.HasVehicleVisited(licensePlateNumber))
            {
                string message = string.Format(
                    "The License Plate Number'{0} was not found in the system",
                    licensePlateNumber);
                throw new KeyNotFoundException(message);
                ////System.Console.WriteLine("Vehicle number does not exist!");
            }

            System.Console.WriteLine(m_Garage.GetVehicleInfoByLicensePlateNumber(licensePlateNumber));
        }

        private static void runArgumentsWithUser(ArgumentsCollection i_Arguments, string i_LicensePlateNumber)
        {
            System.Console.WriteLine("Please provide the following information:");
            for (int i = 0; i < i_Arguments.Length; i++)
            {
                ArgumentWrapper argument = i_Arguments[i];
                bool isInputRequired = true;

                if (argument.DisplayName == "License plate number")
                {
                    argument.InjectValue(i_LicensePlateNumber);
                    continue;
                }

                Console.WriteLine("{0}:", argument.DisplayName);
                if (argument.IsStrictToOptionalValues)
                {
                    showSubMenu(argument.OptionalValues, "Choose from the following options:");
                }

                while (isInputRequired)
                {
                    try
                    {
                        string inputString = Console.ReadLine();

                        if(argument.IsStrictToOptionalValues)
                        {
                            int inputInt;

                            if(!int.TryParse(inputString, out inputInt))
                            {
                                throw new FormatException();
                            }
                            else
                            {
                                inputString = argument.OptionalValues[inputInt - 1];
                            }
                        }

                        argument.InjectValue(inputString);
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
