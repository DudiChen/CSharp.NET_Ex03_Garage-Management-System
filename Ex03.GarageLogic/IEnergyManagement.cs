using System;
using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;

namespace Ex03.GarageLogic
{
    internal interface IEnergyManagement
    {
        eEnergyTypes[] GetSupportedEnergyTypes();

        float GetMaxEnergyCapacity();

        float GetRemainingEnergyLevel();

        void Energize(Nullable<eEnergyTypes> i_EnergyType, float i_EnergyAmountToAdd);
    }
}
