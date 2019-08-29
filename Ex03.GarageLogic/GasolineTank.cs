using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    internal class GasolineTank
    {
        public enum eGasolineType
        {
            Octan98, Octan96, Octan95, Soler
        }

        private readonly float r_MaximumGasolineTankCapacity;
        private float m_CurrentAmountOfGasoline;
        private readonly eGasolineType r_GasolineType;

        internal GasolineTank(eGasolineType i_GasolineType, float i_MaximumGasolineTankCapacity)
        {
            
        }

        internal float MaximumGasolineTankCapacity
        {
            get
            {
                return r_MaximumGasolineTankCapacity;
            }
        }

        internal float CurrentAmountOfGasoline
        {
            get
            {
                return m_CurrentAmountOfGasoline;
            }
        }

        internal void FillTank(eGasolineType i_GasolineType, float i_AmountOfGasolineToAdd)
        {
            if (i_GasolineType == r_GasolineType)
            {
                if(m_CurrentAmountOfGasoline + i_AmountOfGasolineToAdd <= MaximumGasolineTankCapacity)
                {
                    m_CurrentAmountOfGasoline += i_AmountOfGasolineToAdd;
                }
                else
                {
                    throw new GasolineTankExceededMaxCapacityException(r_MaximumGasolineTankCapacity, m_CurrentAmountOfGasoline, i_AmountOfGasolineToAdd);
                }
            }
            else
            {
                throw new GasolineTankGasolineTypeException(r_GasolineType, i_GasolineType);
            }
        }
    }
}
