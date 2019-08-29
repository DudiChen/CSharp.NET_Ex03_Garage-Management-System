using System;
using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;

using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    internal class Battery : IEnergyContainer
    {
        private readonly float r_MaximumWorkingHours;
        private float m_RemainingWorkingHours;
        private readonly eEnergyTypes[] r_SupportedElectricityTypes;

        public Battery(eEnergyTypes[] i_SupportedElectricityTypes, float i_MaximumWorkingHours, float i_RemainingWorkingHours)
        {
            r_SupportedElectricityTypes = i_SupportedElectricityTypes;
            r_MaximumWorkingHours = i_MaximumWorkingHours;
            m_RemainingWorkingHours = i_RemainingWorkingHours;
        }

        public eEnergyTypes[] GetSupportedEnergyTypes()
        {
            return r_SupportedElectricityTypes;
        }

        public float GetMaxEnergyCapacity()
        {
            return r_MaximumWorkingHours;
        }

        public float GetRemainingEnergyLevel()
        {
            return m_RemainingWorkingHours;
        }

        public void Energize(eEnergyTypes i_ElectricityType, float i_EnergyAmountToAdd)
        {
            bool isSupportedGasolineType = false;
            foreach (eEnergyTypes SupportedElectricityType in r_SupportedElectricityTypes)
            {
                if (i_ElectricityType == SupportedElectricityType)
                {
                    isSupportedGasolineType = true;
                    break;
                }
            }

            if (isSupportedGasolineType)
            {
                if (m_RemainingWorkingHours + i_EnergyAmountToAdd <= r_MaximumWorkingHours)
                {
                    m_RemainingWorkingHours += i_EnergyAmountToAdd;
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

        public float RemainingWorkingHours
        {
            get
            {
                return m_RemainingWorkingHours;
            }
        }

        public void Charge(float i_HoursToAdd)
        {
            if (m_RemainingWorkingHours + i_HoursToAdd <= r_MaximumWorkingHours)
            {
                m_RemainingWorkingHours += i_HoursToAdd;
            }
            else
            {
                //throw new BatteryMaxWorkingHoursException(r_MaximumWorkingHours, m_RemainingWorkingHours, i_HoursToAdd);
            }
        }

    }
}
