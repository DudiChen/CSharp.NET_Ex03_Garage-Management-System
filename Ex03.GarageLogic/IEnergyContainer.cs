using System;
using Ex03.GarageLogic.Exceptions;
using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;

namespace Ex03.GarageLogic
{
    internal abstract class EnergyContainer
    {
        public abstract void Energize(Nullable<eEnergyTypes> i_EnergyType, float i_EnergyAmountToAdd);

        public abstract float GetMaxEnergyCapacity();

        public abstract float GetRemainingEnergyLevel();

        public abstract eEnergyTypes[] GetSupportedEnergyTypes();

        public abstract override string ToString();

        protected void AddEnergy(ref float io_CurrentAmountOfEnergy,float i_AmountOfEnergyToAdd, float i_MaximumEnergyCapacity)
        {
            if (io_CurrentAmountOfEnergy + i_AmountOfEnergyToAdd <= i_MaximumEnergyCapacity)
            {
                io_CurrentAmountOfEnergy += i_AmountOfEnergyToAdd;
            }
            else
            {
                //throw new GasolineTankExceededMaxCapacityException(r_MaximumGasolineTankCapacity, m_CurrentAmountOfGasoline, i_AmountOfGasolineToAdd);
                throw new ValueOutOfRangeException(i_MaximumEnergyCapacity,0,"Energy");
            }
        }
    }
}
