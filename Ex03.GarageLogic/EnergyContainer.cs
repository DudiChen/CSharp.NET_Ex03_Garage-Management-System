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

        protected void AddEnergy(ref float io_CurrentAmountOfEnergy, float i_AmountOfEnergyToAdd, float i_MaximumEnergyCapacity)
        {
            float sumCurrentAndAdditional = io_CurrentAmountOfEnergy + i_AmountOfEnergyToAdd;
            if (sumCurrentAndAdditional <= i_MaximumEnergyCapacity)
            {
                io_CurrentAmountOfEnergy += i_AmountOfEnergyToAdd;
            }
            else
            {
                string message = string.Format(
                    "The received energy amount in hours of '{0}' amounted to {1}, which exceeded the max allowed value of '{2}'",
                    i_AmountOfEnergyToAdd,
                    sumCurrentAndAdditional,
                    i_MaximumEnergyCapacity);
                throw new ValueOutOfRangeException(i_MaximumEnergyCapacity, 0, message);
            }
        }
    }
}
