using System;

namespace Ex03.GarageLogic.Exceptions
{
    class GasolineTankExceededMaxCapacityException : Exception
    {
        private readonly float r_MaximumGasolineTankCapacity;
        private readonly float r_CurrentAmountOfGasoline;
        private readonly float r_AmountOfGasolineToAdd;

        public GasolineTankExceededMaxCapacityException(
            float i_MaximumGasolineTankCapacity,
            float i_CurrentAmountOfGasoline,
            float i_AmountOfGasolineToAdd)
            : base(
                string.Format("Error: Adding {0} Liters of Gasoline to Tank yields {1} which exceeds the Max Capacity of {2} Liters", 
                    i_AmountOfGasolineToAdd, i_CurrentAmountOfGasoline + i_AmountOfGasolineToAdd, i_MaximumGasolineTankCapacity))
        {
            r_MaximumGasolineTankCapacity = i_MaximumGasolineTankCapacity;
            r_CurrentAmountOfGasoline = i_CurrentAmountOfGasoline;
            r_AmountOfGasolineToAdd = i_AmountOfGasolineToAdd;
        }

        public GasolineTankExceededMaxCapacityException(
            Exception i_InnerException,
            float i_MaximumGasolineTankCapacity,
            float i_CurrentAmountOfGasoline,
            float i_AmountOfGasolineToAdd)
            : base(
                string.Format("Error: Adding {0} Liters of Gasoline to Tank yields {1} which exceeds the Max Capacity of {2} Liters",
                    i_AmountOfGasolineToAdd, i_CurrentAmountOfGasoline + i_AmountOfGasolineToAdd, i_MaximumGasolineTankCapacity),
                i_InnerException)
        {
            r_MaximumGasolineTankCapacity = i_MaximumGasolineTankCapacity;
            r_CurrentAmountOfGasoline = i_CurrentAmountOfGasoline;
            r_AmountOfGasolineToAdd = i_AmountOfGasolineToAdd;
        }
    }
}
