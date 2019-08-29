using System;


namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public enum eCarColors
        {
            WHITE, RED, BLACK, YELLOW
        }

        internal enum eNumberOfCarDoors
        {
            Two = 2, Three, Four, Five
        }

        private readonly eCarColors r_carColor;
        private readonly ushort r_NumberOfDoors;

        protected Car(string i_Model, string i_LicensePlateNumber, eCarColors i_CarColor, ushort i_NumberOfDoors) : base(i_Model, i_LicensePlateNumber)
        {
            r_carColor = i_CarColor;
            r_NumberOfDoors = i_NumberOfDoors;

        }

        public eCarColors Color
        {
            get
            {
                return r_carColor;
            }
        }

        public ushort NumberOfDoors
        {
            get
            {
                return r_NumberOfDoors;
            }
        }

    }
}