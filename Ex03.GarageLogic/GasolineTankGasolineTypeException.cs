using System;

using eGasolineType = Ex03.GarageLogic.GasolineTank.eGasolineType;

namespace Ex03.GarageLogic.Exceptions
{
    class GasolineTankGasolineTypeException : Exception
    {
        private readonly eGasolineType r_GasolineTypeExpected;
        private readonly eGasolineType r_GasolineTypeReceived;

        internal GasolineTankGasolineTypeException(
            eGasolineType i_GasolineTypeExpected,
            eGasolineType i_GasolineTypeReceived)
            : base(
                string.Format("Error: Gasoline-Type received was '{0}', expected '{1}'.", 
                    i_GasolineTypeReceived.ToString(), 
                    i_GasolineTypeExpected.ToString()))
        {
            r_GasolineTypeReceived = i_GasolineTypeReceived;
            r_GasolineTypeExpected = i_GasolineTypeExpected;
        }

        internal GasolineTankGasolineTypeException(
            eGasolineType i_GasolineTypeExpected,
            eGasolineType i_GasolineTypeReceived,
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

        public eGasolineType GasolineTypeExpected
        {
            get
            {
                return r_GasolineTypeExpected;
            }
        }
        public eGasolineType GasolineTypeReceived
        {
            get
            {
                return r_GasolineTypeReceived;
            }
        }
    }
}
