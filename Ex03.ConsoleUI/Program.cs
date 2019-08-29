using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {

        }

        public void Runner()
        {
            GarageLogic.Garage garage = new Garage();

            while(true)
            {
                int userChoice = UIManager.ShowMenu();
                switch(userChoice)
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
