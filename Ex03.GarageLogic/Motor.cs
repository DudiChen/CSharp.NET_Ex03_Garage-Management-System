using System;
using System.Collections.Generic;
using eMotorType = Ex03.GarageLogic.VehicleFactory.eMotorType;
using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;

namespace Ex03.GarageLogic
{
    internal class Motor : IEnergyManagement
    {
        protected readonly eMotorType r_MotorType;
        protected EnergyContainer m_EnergyContainer;

        protected internal Motor(EnergyContainer i_EnergyContainer, eMotorType i_MotorType)
        {
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
            return (m_EnergyContainer.GetRemainingEnergyLevel() / m_EnergyContainer.GetMaxEnergyCapacity()) / 100;
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

        public void Energize(Nullable<eEnergyTypes> i_EnergyType, float i_EnergyAmountToAdd)
        {
            m_EnergyContainer.Energize(i_EnergyType, i_EnergyAmountToAdd);
        }

        public override string ToString()
        {
            return m_EnergyContainer.ToString();
        }
    }
}
