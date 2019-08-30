using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Linq;
//using System.Security.AccessControl;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Exceptions;
using eMainMenuOptions = Ex03.ConsoleUI.Utils.eMainMenuOptions;

namespace Ex03.ConsoleUI
{
    public static class UIManager
    {
        //public enum eMainMenuOptions
        //{
        //    AddVehicle,
        //    ShowVehiclesLicensePlateNumbers,
        //    ChangeVehicleStatus,
        //    InflateWheels,
        //    FuelGasolineVehicle,
        //    ChargeElectricVehicle,
        //    GetVehicleInfoByLicensePlateNumber,
        //    QuitProgram
        //}

        //public static Dictionary<eMainMenuOptions, string> MainMenuOptionsMap = new Dictionary<eMainMenuOptions, string>
        //    () {
        //        {eMainMenuOptions.AddVehicle, "Check-in a Vehicle to Garage"},
        //        {eMainMenuOptions.ShowVehiclesLicensePlateNumbers, "Show License-Plate Number List of Vehicles in Garage"},
        //        {eMainMenuOptions.ChangeVehicleStatus, "Change Vehicle's Status in Garage By License-Plate Number"},
        //        {eMainMenuOptions.InflateWheels, "Fully inflate a Vehicle's Wheels By License-Plate Number"},
        //        {eMainMenuOptions.FuelGasolineVehicle, "Add Fuel to a Gasoline Vehicle By License-Plate Number"},
        //        {eMainMenuOptions.ChargeElectricVehicle, "Add Charge to a Electric Vehicle By License-Plate Number"},
        //        {eMainMenuOptions.GetVehicleInfoByLicensePlateNumber, "Get Vehicle Information By License-Plate Number"},
        //        {eMainMenuOptions.QuitProgram, "Exit Garage Program"}
        //    };

        //private static string m_LineSeparatorThick = "==================================================================";
        //private static string m_LineSeparatorThin = "------------------------------------------------------------------";
        //private static readonly int sr_MainMenuNumberOfOptions = Enum.GetNames(typeof(eMainMenuOptions)).Length;

        //private static string GetWelcomeMessage()
        //{
        //    StringBuilder welcomeMessage = new StringBuilder();
        //    welcomeMessage.AppendFormat(
        //        "{0}{1}{0}", m_LineSeparatorThick,
        //        Environment.NewLine);
        //    welcomeMessage.AppendFormat("\t\t:::\tGarage Management System\t:::{0}", Environment.NewLine);
        //    welcomeMessage.AppendFormat("{0}{1}", m_LineSeparatorThick, Environment.NewLine);

        //    return welcomeMessage.ToString();
        //}

        public static void MenuHandler()
        {
            Utils.ShowMainMenu();
            int userChoice = Utils.GetUserMenuChoice();
            while (!Enum.IsDefined(typeof(eMainMenuOptions), userChoice))
            {
                Console.WriteLine("Invalid input: Choice made not in range. Please try again...");
            }
            eMainMenuOptions mainMenuOption = (eMainMenuOptions)userChoice;

            switch(mainMenuOption)
            {
                case eMainMenuOptions.AddVehicle:
                    {

                        break;
                    }

                case eMainMenuOptions.ShowVehiclesLicensePlateNumbers:
                    {

                        break;
                    }

                case eMainMenuOptions.ChangeVehicleStatus:
                    {

                        break;
                    }
                case eMainMenuOptions.InflateWheels:
                    {

                        break;
                    }
                case eMainMenuOptions.FuelGasolineVehicle:
                    {

                        break;
                    }
                case eMainMenuOptions.ChargeElectricVehicle:
                    {

                        break;
                    }
                case eMainMenuOptions.GetVehicleInfoByLicensePlateNumber:
                    {

                        break;
                    }
                case eMainMenuOptions.QuitProgram:
                    {

                        break;
                    }
            }

        }

        //public static void ShowMainMenu()
        //{
        //    StringBuilder menuLinesConcatenator = new StringBuilder("\t\t:::::\tMain Menu\t:::::");

        //    menuLinesConcatenator.AppendFormat("{0}{0}Please choose from the below menu options:", Environment.NewLine);

        //    for(int i = 0; i <= sr_MainMenuNumberOfOptions; i++)
        //    {
        //        menuLinesConcatenator.AppendFormat("{0}{1}. {2}.", Environment.NewLine, i + 1, MainMenuOptionsMap[(eMainMenuOptions)i]);
        //    }

        //    Console.WriteLine(menuLinesConcatenator);

        //    //System.Console.Clear();

        //    //int menuRowCounter = 1;
        //    //////int inputChoice;
        //    //StringBuilder menuDisplayStringBuilder = new StringBuilder();
        //    //menuDisplayStringBuilder.AppendLine("Choose a option from the garage:");
        //    //menuDisplayStringBuilder.AppendFormat("{0}.Add a new Vehicle to garage{1}", menuRowCounter++, Environment.NewLine);
        //    //menuDisplayStringBuilder.AppendFormat("{0}.Show all vehicles in the garage{1}", menuRowCounter++, Environment.NewLine);
        //    //menuDisplayStringBuilder.AppendFormat("{0}.Show vehicles in the garage by status{1}", menuRowCounter++, Environment.NewLine);
        //    //menuDisplayStringBuilder.AppendFormat("{0}.Change vehicle's status{1}", menuRowCounter++, Environment.NewLine);
        //    //menuDisplayStringBuilder.AppendFormat("{0}.Fill vehicle's wheels{1}", menuRowCounter++, Environment.NewLine);
        //    //menuDisplayStringBuilder.AppendFormat("{0}.Full Gasoline vehicle{1}", menuRowCounter++, Environment.NewLine);
        //    //menuDisplayStringBuilder.AppendFormat("{0}.Charge electric vehicle{1}", menuRowCounter++, Environment.NewLine);
        //    ////menuDisplayStringBuilder.AppendFormat("{0}.Full Gasoline vehicle{1}", menuRowCounter++, Environment.NewLine);
        //    //menuDisplayStringBuilder.AppendFormat("{0}.Show car information{1}", menuRowCounter++, Environment.NewLine);


        //    ////while(!int.TryParse(System.Console.ReadLine(), out inputChoice))
        //    ////{
        //    ////    System.Console.WriteLine("Input incorrect reenter input:");
        //    ////}

        //    ////return inputChoice;
        //}

        //public static int GetUserMenuChoice()
        //{
        //    string inputChoiceStr = System.Console.ReadLine();
        //    int inputChoice;
        //    while (!int.TryParse(System.Console.ReadLine(), out inputChoice))
        //    {
        //        System.Console.WriteLine("Invalid input: Please try again...");
        //    }

        //    return inputChoice;
        //}

        public static void RunArgumentsWithUser(OrderedDictionary i_Arguments)
        {
            System.Console.WriteLine("Please provide the following information:");
            foreach(DictionaryEntry pairEntry in i_Arguments)
            {
                ArgumentWrapper argument = pairEntry.Value as ArgumentWrapper;
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
}
