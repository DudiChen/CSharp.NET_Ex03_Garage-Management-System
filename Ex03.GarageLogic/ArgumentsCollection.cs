using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
namespace Ex03.GarageLogic.ArgumentsUtils
{
    internal class ArgumentsCollection
    {
        private OrderedDictionary argumentOrderedDictionaryDictionary;
        

        internal ArgumentsCollection()
        {
            argumentOrderedDictionaryDictionary = new OrderedDictionary();
        }

        internal void AddArgument(string i_ArgumentKeyString, ArgumentWrapper i_Argument)
        {
            argumentOrderedDictionaryDictionary.Add(i_ArgumentKeyString, i_Argument);
        }

        internal void AddArgument(VehicleFactory.eArgumentKeys i_ArgumentKey,int i_MultipleInputCounter, ArgumentWrapper i_Argument)
        {
            argumentOrderedDictionaryDictionary.Add(string.Format("{0}{1}", i_ArgumentKey,i_MultipleInputCounter), i_Argument);
        }

        internal void AddArgument(VehicleFactory.eArgumentKeys i_ArgumentKeyString, ArgumentWrapper i_Argument)
        {
            argumentOrderedDictionaryDictionary.Add(i_ArgumentKeyString.ToString(), i_Argument);

        }
    }
}
