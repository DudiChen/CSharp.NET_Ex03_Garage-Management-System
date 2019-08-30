using System;

using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;

namespace Ex03.GarageLogic.Exceptions
{
    class GasolineTankGasolineTypeException : Exception
    {
        private readonly eEnergyTypes r_GasolineTypeExpected;
        private readonly eEnergyTypes r_GasolineTypeReceived;

        internal GasolineTankGasolineTypeException(
            eEnergyTypes i_GasolineTypeExpected,
            eEnergyTypes i_GasolineTypeReceived)
            : base(
                string.Format("Error: Gasoline-Type received was '{0}', expected '{1}'.", 
                    i_GasolineTypeReceived.ToString(), 
                    i_GasolineTypeExpected.ToString()))
        {
            r_GasolineTypeReceived = i_GasolineTypeReceived;
            r_GasolineTypeExpected = i_GasolineTypeExpected;
        }

        internal GasolineTankGasolineTypeException(
            eEnergyTypes i_GasolineTypeExpected,
            eEnergyTypes i_GasolineTypeReceived,
            Exception i_InnerException)
            : base(
                string.Format(
                    "Error: Gasoline-Type received was '{0}', expected '{1}'.",
                    i_GasolineTypeReceived.ToString(),
                    i_GasolineTypeExpected.ToString()),
                i_InnerException)
        {
            r_GasolineTypeReceived = i_GasolineTypeReceived;
            r_GasolineTypeExpected = i_GasolineTypeExpected;
        }

        public eEnergyTypes GasolineTypeExpected
        {
            get
            {
                return r_GasolineTypeExpected;
            }
        }
        public eEnergyTypes GasolineTypeReceived
        {
            get
            {
                return r_GasolineTypeReceived;
            }
        }
    }
}
