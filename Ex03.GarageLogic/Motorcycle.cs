using System;


namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A, A1, AB, B1
        }

        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineVolume;

        protected Motorcycle(string i_Model, string i_LicensePlateNumber, eLicenseType i_LicenseType, int i_EngineVolume, Motor i_Motor)
            : base(i_Model, i_LicensePlateNumber, i_Motor)
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

    }
}
