using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UIManager
    {
        
        
        public static void ShowMenu()
        {
            System.Console.Clear();
            int menuRowCounter = 1;
            StringBuilder menuDisplayStringBuilder = new StringBuilder();
            

            

            menuDisplayStringBuilder.AppendFormat("{0}.Add a new Vehicle to garage{1}", menuRowCounter++, Environment.NewLine);
            menuDisplayStringBuilder.AppendFormat("{0}.Show all vehicles in the garage{1}", menuRowCounter++, Environment.NewLine);
            menuDisplayStringBuilder.AppendFormat("{0}.Show vehicles in the garage by status{1}", menuRowCounter++, Environment.NewLine);
            menuDisplayStringBuilder.AppendFormat("{0}.Change vehicle's status{1}", menuRowCounter++, Environment.NewLine);
            menuDisplayStringBuilder.AppendFormat("{0}.Fill vehicle's wheels{1}", menuRowCounter++, Environment.NewLine);
            menuDisplayStringBuilder.AppendFormat("{0}.Full Gasoline vehicle{1}", menuRowCounter++, Environment.NewLine);
            menuDisplayStringBuilder.AppendFormat("{0}.Charge electric vehicle{1}", menuRowCounter++, Environment.NewLine);
            menuDisplayStringBuilder.AppendFormat("{0}.Full Gasoline vehicle{1}", menuRowCounter++, Environment.NewLine);
            menuDisplayStringBuilder.AppendFormat("{0}.Show car information{1}", menuRowCounter++, Environment.NewLine);

            
        }

        public static void RunArgumentsWithUser(ArgumentWrapper[] i_Arguments)
        {
            foreach(ArgumentWrapper argument in i_Arguments)
            {
                bool isInputRequired = true;
                int choiceRowCounter = 1;
                StringBuilder argumentMessage = new StringBuilder();
                argumentMessage.AppendFormat("Please enter the {0}{1}", argument.DisplayName, Environment.NewLine);
                if(argument.IsStrictToOptionalValues)
                {
                    argumentMessage.AppendLine("choose from the following options");
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
