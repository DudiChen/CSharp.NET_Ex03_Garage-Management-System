using System;
using System.Collections.Generic;
using System.Text;
using eTicketStatus = Ex03.GarageLogic.Garage.eTicketStatus;
//using Ex03.ConsoleUI.UIManager;

namespace Ex03.ConsoleUI
{
    public static class Utils
    {
        public enum eMainMenuOptions
        {
            AddVehicle,
            ShowVehiclesLicensePlateNumbers,
            ChangeVehicleStatus,
            InflateWheels,
            FuelGasolineVehicle,
            ChargeElectricVehicle,
            GetVehicleInfoByLicensePlateNumber,
            QuitProgram
        }

        public static Dictionary<eMainMenuOptions, string> MainMenuOptionsMap =
            new Dictionary<eMainMenuOptions, string>()
                {
                    { eMainMenuOptions.AddVehicle, "Check-in a Vehicle to Garage" },
                    {
                        eMainMenuOptions.ShowVehiclesLicensePlateNumbers,
                        "Show License-Plate Number List of Vehicles in Garage"
                    },
                    {
                        eMainMenuOptions.ChangeVehicleStatus,
                        "Change Vehicle's Status in Garage By License-Plate Number"
                    },
                    { eMainMenuOptions.InflateWheels, "Fully inflate a Vehicle's Wheels By License-Plate Number" },
                    { eMainMenuOptions.FuelGasolineVehicle, "Add Fuel to a Gasoline Vehicle By License-Plate Number" },
                    {
                        eMainMenuOptions.ChargeElectricVehicle,
                        "Add Charge to a Electric Vehicle By License-Plate Number"
                    },
                    {
                        eMainMenuOptions.GetVehicleInfoByLicensePlateNumber,
                        "Get Vehicle Information By License-Plate Number"
                    },
                    { eMainMenuOptions.QuitProgram, "Exit Garage Program" }
                };


        private static string m_LineSeparatorThick =
            "==================================================================";
        private static string m_LineSeparatorThin =
            "------------------------------------------------------------------";
        private static readonly int sr_MainMenuNumberOfOptions = Enum.GetNames(typeof(eMainMenuOptions)).Length;

        private static string GetWelcomeMessage()
        {
            StringBuilder welcomeMessage = new StringBuilder();

            welcomeMessage.AppendFormat("{0}{1}{0}", m_LineSeparatorThick, Environment.NewLine);

            welcomeMessage.AppendFormat("\t\t:::\tGarage Management System\t:::{0}", Environment.NewLine);

            welcomeMessage.AppendFormat("{0}{1}", m_LineSeparatorThick, Environment.NewLine);
            return welcomeMessage.ToString();
        }

        public static void ShowMainMenu()
        {
            StringBuilder menuLinesConcatenator = new StringBuilder("\t\t:::::\tMain Menu\t:::::");

            menuLinesConcatenator.AppendFormat("{0}{0}Please choose from the below menu options:", Environment.NewLine);

            for (int i = 0; i < sr_MainMenuNumberOfOptions; i++)
            {
                menuLinesConcatenator.AppendFormat(
                    "{0}{1}. {2}.",
                    Environment.NewLine,
                    i + 1,
                    MainMenuOptionsMap[(eMainMenuOptions)i]);
            }

            Console.WriteLine(menuLinesConcatenator);
        }

        public static int GetUserMenuChoice()
        {
            int inputChoice;
            while (!int.TryParse(System.Console.ReadLine(), out inputChoice))
            {
                System.Console.WriteLine("Invalid input: Please try again...");
            }

            return inputChoice;
        }

        public static string GetLicensePlateNumber()
        {
            System.Console.WriteLine("Please provide Vehicle's License Plate Number:");
            return System.Console.ReadLine();
        }

        public static string GetOwnerName()
        {
            System.Console.WriteLine("Please provide the Vehicle's Owner Name:");
            return System.Console.ReadLine();
        }

        public static string GetOwnerPhoneNumber()
        {
            System.Console.WriteLine("Please provide the Vehicle's Owner Phone Number:");
            return System.Console.ReadLine();
        }


        //public static string GetVehicleType(string[] i_SupportedVehicleTypes)
        //{
        //    StringBuilder VehicleTypeMenu = new StringBuilder("Please choose the Vehicle Type from the following options:");

        //}
    }
}
