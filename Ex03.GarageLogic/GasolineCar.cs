using System;


namespace Ex03.GarageLogic
{
    public class GasolineCar : Car
    {
        public GasolineCar(string i_CarModel, string i_LicensePlateNumber, eCarColors i_CarColor, ushort i_NumberOfDoors)
            : base(i_CarModel, i_LicensePlateNumber, i_CarColor, i_NumberOfDoors)
        {}

        protected override Motor CreateMotor()
        {
            throw new NotImplementedException();
        }
    }
}
