using System;
using eCarColors = Ex03.GarageLogic.Car.eCarColors;
using eNumberOfCarDoors = Ex03.GarageLogic.Car.eNumberOfCarDoors;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        ////internal enum eCarColors
        ////{
        ////    Black, White, Red, Yellow
        ////}

        private static readonly int[] r_CarNumberOfWindows = { 2, 3, 4, 5 };

        internal enum eVehicleType
        {
            Electric, Gasoline
        }

        ////internal enum eNumberOfCarDoors
        ////{
        ////    Two = 2, Three, Four, Five
        ////}

        internal enum eSupportedVehicles
        {
            GasolineCar = 1, ElectricCar, GasolineMotorcycle, ElectricMotorcycle, Truck
        }

        internal static Vehicle BuildCar(eVehicleType i_VehicleType, eCarColors i_Color, eNumberOfCarDoors i_NumberOfDoors)
        {
            switch(i_VehicleType)
            {
                case eVehicleType.Electric:
                    {
                        return new ElectricCar();
                        break;
                    }

                case eVehicleType.Gasoline:
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
