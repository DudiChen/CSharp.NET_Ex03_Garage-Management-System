using System;
using System.Collections.Generic;
using eMotorType = Ex03.GarageLogic.VehicleFactory.eMotorType;
using eEnergyTypes  = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;

namespace Ex03.GarageLogic
{
    internal class Motor : IEnergyManagement
    {
        ////private readonly List<eEnergyTypes> m_SupportedEnergyType;
        protected IEnergyContainer m_EnergyContainer;
        protected readonly eMotorType r_MotorType;
        ////private readonly eEnergyTypes[] r_SupportedGasolineTypes;

        ////protected internal Motor(List<eEnergyTypes> i_SupportedEnergyType, IEnergyContainer i_EnergyContainer, eMotorType i_MotorType)
        //protected internal Motor(eMotorType i_MotorType)
        protected internal Motor(IEnergyContainer i_EnergyContainer, eMotorType i_MotorType)
        {
            ////m_SupportedEnergyType = i_SupportedEnergyType;
            m_EnergyContainer = i_EnergyContainer;
            r_MotorType = i_MotorType;
        }

        internal eMotorType MotorType
        {
            get
            {
                return r_MotorType;
            }   
        }

        internal float CalculateRemainingEnergyPercentage()
        {
            return ((m_EnergyContainer.GetRemainingEnergyLevel() / m_EnergyContainer.GetMaxEnergyCapacity()) / 100);
        }

        public eEnergyTypes[] GetSupportedEnergyTypes()
        {
            return m_EnergyContainer.GetSupportedEnergyTypes();
        }

        public float GetMaxEnergyCapacity()
        {
            return m_EnergyContainer.GetMaxEnergyCapacity();
        }

        public float GetRemainingEnergyLevel()
        {
            return m_EnergyContainer.GetRemainingEnergyLevel();
        }

        public void Energize(eEnergyTypes i_EnergyType, float i_EnergyAmountToAdd)
        {
            m_EnergyContainer.Energize(i_EnergyType, i_EnergyAmountToAdd);
        }
    }
}
