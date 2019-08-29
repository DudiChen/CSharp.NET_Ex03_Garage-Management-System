using System;
////using eCarColors = Ex03.GarageLogic.Car.eCarColors;
////using eNumberOfCarDoors = Ex03.GarageLogic.Car.eNumberOfCarDoors;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        internal enum eSupportedVehicles
        {
            GasolineCar = 1, ElectricCar, GasolineMotorcycle, ElectricMotorcycle, Truck
        }

        internal enum eMotorType
        {
            Gasoline, Electric
        }

        internal enum eEnergyTypes
        {
            Octan98, Octan96, Octan95, Soler, Electricity
        }

        public enum eCarColors
        {
            White, Red, Black, Yellow
        }

        internal enum eNumberOfCarDoors
        {
            Two = 2, Three, Four, Five
        }

        ////private static readonly int[] r_CarNumberOfWindows = { 2, 3, 4, 5 };


        internal static Vehicle BuildElectricCar(eSupportedVehicles i_VehicleType, eCarColors i_Color, eNumberOfCarDoors i_NumberOfDoors)
        {
            switch(i_VehicleType)
            {
                case eSupportedVehicles.ElectricCar:
                    {
                        return new ElectricCar();
                        break;
                    }

                case eSupportedVehicles.GasolineCar:
                    {
                        return new GasolineCar();
                        break;
                    }

                default:
                    {

                        break;
                    }
            }

        }
    }
}
