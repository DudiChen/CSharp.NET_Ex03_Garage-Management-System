using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        internal enum eCarColors
        {
            Black, White, Red, Yellow
        }

        private static readonly int[] r_CarNumberOfWindows = { 2, 3, 4, 5 };

        internal enum eVehicleType
        {
            Electric, Gas
        }

        internal enum eCarNumberOfDoor
        {
            Two = 2, Three, Four, Five
        }

        internal enum eSupportedVehicles
        {
            GasCar = 1, ElectricCar, GasMotorcycle, ElectricMotorcycle, Truck
        }

        internal static Vehicle BuildCar(eVehicleType i_VehicleType, eCarColors i_Color, eCarNumberOfDoor i_NumberOfDoors)
        {
            switch(i_VehicleType)
            {
                case eVehicleType.Electric:
                    {
                        return new ElectricCar();
                        break;
                    }

                case eVehicleType.Gas:
                    {
                        return new GasCar();
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
