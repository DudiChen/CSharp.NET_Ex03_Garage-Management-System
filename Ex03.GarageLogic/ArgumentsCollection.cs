using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic.ArgumentsUtils
{
    public class ArgumentsCollection
    {
        private readonly OrderedDictionary r_argumentOrderedDictionaryDictionary;

        internal ArgumentsCollection()
        {
            r_argumentOrderedDictionaryDictionary = new OrderedDictionary();
        }

        internal void AddArgument(string i_ArgumentKeyString, ArgumentWrapper i_Argument)
        {
            r_argumentOrderedDictionaryDictionary.Add(i_ArgumentKeyString, i_Argument);
        }

        internal void AddArgument(VehicleFactory.eArgumentKeys i_ArgumentKey, int i_MultipleInputCounter, ArgumentWrapper i_Argument)
        {
            r_argumentOrderedDictionaryDictionary.Add(string.Format("{0}{1}", i_ArgumentKey, i_MultipleInputCounter), i_Argument);
        }

        internal void AddArgument(VehicleFactory.eArgumentKeys i_ArgumentKeyString, ArgumentWrapper i_Argument)
        {
            r_argumentOrderedDictionaryDictionary.Add(i_ArgumentKeyString.ToString(), i_Argument);
        }

        internal ArgumentWrapper this[string i_ArgumentKey]
        {
            get
            {
                return (ArgumentWrapper)r_argumentOrderedDictionaryDictionary[i_ArgumentKey];
            }
        }

        internal ArgumentWrapper this[VehicleFactory.eArgumentKeys i_ArgumentKey]
        {
            get
            {
                return (ArgumentWrapper)r_argumentOrderedDictionaryDictionary[i_ArgumentKey.ToString()];
            }
        }
    }
}
