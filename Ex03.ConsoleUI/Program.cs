using System;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
     public class Program
    {
        public static void Main()
        {
            runner();
        }

        private static void runner()
        {
            GarageLogic.Garage garage = new Garage();

            while(true)
            {
                UIManager.ShowMainMenu();
                int userChoice = UIManager.GetUserMenuChoice();
                //switch ((UIManager.eMainMenuOptions)userChoice)
                switch (userChoice)
                {
                    case 1:
                        {
                            
                        }
                        break;
                    case 2:
                        { }
                        break;
                    case 3:
                        { }
                        break;
                    case 4:
                        { }
                        break;
                    case 5:
                        { }
                        break;
                    case 6:
                        { }
                        break;
                }


            }
        }
    }
}
