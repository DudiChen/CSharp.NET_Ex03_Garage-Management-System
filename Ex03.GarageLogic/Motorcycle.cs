using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        internal const int k_NumberOfWheels = 2;

        internal enum eLicenseType
        {
            A, A1, AB, B1
        }

        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineVolume;

        internal Motorcycle(Motor i_Motor, Wheel[] i_Wheels, string i_Model, string i_LicensePlateNumber, eLicenseType i_LicenseType, int i_EngineVolume)
            : base(i_Motor, i_Wheels, i_LicensePlateNumber, i_Model)
        {
            r_LicenseType = i_LicenseType;
            r_EngineVolume = i_EngineVolume;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }

        public int EngineVolume
        {
            get
            {
                return r_EngineVolume;
            }
        }

        public override string ToString()
        {
            StringBuilder carDisplayString = new StringBuilder();
            carDisplayString.AppendLine(this.ToStringVehicle());
            carDisplayString.AppendFormat(
                @"Type of registration: {0}
Motor volume: {1}",
                r_LicenseType.ToString(),
                r_EngineVolume);

            return carDisplayString.ToString();
        }
    }
}
