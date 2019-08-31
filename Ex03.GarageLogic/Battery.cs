using System;
using Ex03.GarageLogic.Exceptions;
using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;

namespace Ex03.GarageLogic
{
    internal class Battery : EnergyContainer
    {
        private readonly float r_MaximumWorkingHours;
        private readonly eEnergyTypes[] r_SupportedElectricityTypes;
        private float m_RemainingWorkingHours;

        public Battery(eEnergyTypes[] i_SupportedElectricityTypes, float i_MaximumWorkingHours, float i_RemainingWorkingHours)
        {
            r_SupportedElectricityTypes = i_SupportedElectricityTypes;
            r_MaximumWorkingHours = i_MaximumWorkingHours;
            m_RemainingWorkingHours = i_RemainingWorkingHours;
        }

        public override eEnergyTypes[] GetSupportedEnergyTypes()
        {
            return r_SupportedElectricityTypes;
        }

        public override float GetMaxEnergyCapacity()
        {
            return r_MaximumWorkingHours;
        }

        public override float GetRemainingEnergyLevel()
        {
            return m_RemainingWorkingHours;
        }

        public override void Energize(Nullable<eEnergyTypes> i_ElectricityType, float i_EnergyAmountToAdd)
        {
            if (i_ElectricityType == null)
            {
                if(m_RemainingWorkingHours + i_EnergyAmountToAdd <= r_MaximumWorkingHours)
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
                throw new ArgumentException("Error: Expected 'null' value for EnergyType in Energize of Electric Type Motor");
            }
            ////bool isSupportedGasolineType = false;

            ////foreach (eEnergyTypes SupportedElectricityType in r_SupportedElectricityTypes)
            ////{
            ////    if (i_ElectricityType == SupportedElectricityType)
            ////    {
            ////        isSupportedGasolineType = true;
            ////        break;
            ////    }
            ////}

            ////if (isSupportedGasolineType)
            ////{
            ////    if (m_RemainingWorkingHours + i_EnergyAmountToAdd <= r_MaximumWorkingHours)
            ////    {
            ////        m_RemainingWorkingHours += i_EnergyAmountToAdd;
            ////    }
            ////    else
            ////    {
            ////        //throw new GasolineTankExceededMaxCapacityException(r_MaximumGasolineTankCapacity, m_CurrentAmountOfGasoline, i_AmountOfGasolineToAdd);
            ////    }
            ////}
            ////else
            ////{
            ////    //throw new GasolineTankGasolineTypesException(r_SupportedGasolineTypes, i_GasolineType);
            ////}
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

        public override string ToString()
        {
            return string.Format("\tBattery remaining: {0}", GetRemainingEnergyLevel());
        }
    }
}
