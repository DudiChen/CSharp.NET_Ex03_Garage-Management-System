using System;
using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;

namespace Ex03.GarageLogic
{
    internal abstract class EnergyContainer
    {
        public abstract void Energize(eEnergyTypes i_EnergyType, float i_EnergyAmountToAdd);

        public abstract float GetMaxEnergyCapacity();

        public abstract float GetRemainingEnergyLevel();

        public abstract eEnergyTypes[] GetSupportedEnergyTypes();

        public abstract override string ToString();
    }
}
