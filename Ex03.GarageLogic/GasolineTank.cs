using System;
using System.Collections.Generic;
using System.Text;
//using System.Linq;
using Ex03.GarageLogic.Exceptions;
using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;

namespace Ex03.GarageLogic
{
    internal class GasolineTank : EnergyContainer
    {
        private readonly float r_MaximumGasolineTankCapacity;
        private float m_CurrentAmountOfGasoline;
        //private readonly List<eEnergyTypes> r_SupportedGasolineTypes;
        private readonly eEnergyTypes[] r_SupportedGasolineTypes;

        ////internal GasolineTank(List<eEnergyTypes> i_SupportedGasolineType, float i_MaximumGasolineTankCapacity, float i_CurrentAmountOfGasoline)
        internal GasolineTank(eEnergyTypes[] i_SupportedGasolineTypes, float i_MaximumGasolineTankCapacity, float i_CurrentAmountOfGasoline)
        {
            r_SupportedGasolineTypes = i_SupportedGasolineTypes;
            r_MaximumGasolineTankCapacity = i_MaximumGasolineTankCapacity;
            m_CurrentAmountOfGasoline = i_CurrentAmountOfGasoline;
        }

        public override eEnergyTypes[] GetSupportedEnergyTypes()
        {
            return r_SupportedGasolineTypes;
        }

        public override float GetMaxEnergyCapacity()
        {
            return r_MaximumGasolineTankCapacity;
        }

        ////internal float MaximumGasolineTankCapacity
        ////{
        ////    get
        ////    {
        ////        return r_MaximumGasolineTankCapacity;
        ////    }
        ////}

        public override float GetRemainingEnergyLevel()
        {
            return m_CurrentAmountOfGasoline;
        }
        ////internal float CurrentAmountOfGasoline
        ////{
        ////    get
        ////    {
        ////        return m_CurrentAmountOfGasoline;
        ////    }
        ////}

        public override void Energize(eEnergyTypes i_GasolineType, float i_AmountOfGasolineToAdd)
        {
            ////bool isSupportedGasolineType = r_SupportedGasolineTypes.Contains(i_GasolineType);
            bool isSupportedGasolineType = false;
            foreach (eEnergyTypes SupportedGasolineType in r_SupportedGasolineTypes)
            {
                if (i_GasolineType == SupportedGasolineType)
                {
                    isSupportedGasolineType = true; 
                    break;
                }
            }

            if (isSupportedGasolineType)
            {
                if(m_CurrentAmountOfGasoline + i_AmountOfGasolineToAdd <= r_MaximumGasolineTankCapacity)
                {
                    m_CurrentAmountOfGasoline += i_AmountOfGasolineToAdd;
                }
                else
                {
                    //throw new GasolineTankExceededMaxCapacityException(r_MaximumGasolineTankCapacity, m_CurrentAmountOfGasoline, i_AmountOfGasolineToAdd);
                }
            }
            else
            {
                //throw new GasolineTankGasolineTypesException(r_SupportedGasolineTypes, i_GasolineType);
            }
        }

        private string toStringSupportedFuelTypes()
        {
            StringBuilder supportedTypeStringBuilder= new StringBuilder();
            
            for(int i =0;i<r_SupportedGasolineTypes.Length;i++)    
            {
                if(i != 0)
                {
                    supportedTypeStringBuilder.Append(", ");
                }
                supportedTypeStringBuilder.Append(r_SupportedGasolineTypes[i].ToString());
            }

            return supportedTypeStringBuilder.ToString();
        }
        public override string ToString()
        {
            return string.Format(
                @"Gasoline Type: [{0}]
Fuel remaining: {1}",
                toStringSupportedFuelTypes(),
                GetRemainingEnergyLevel());
        }
    }
}
