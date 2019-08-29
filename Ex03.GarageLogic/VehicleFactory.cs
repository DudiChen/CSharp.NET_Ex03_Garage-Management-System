using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Ex03.GarageLogic.ArgumentsUtils;
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

        internal enum eArgumentKeys
        {
            LicensePlate, Model, VehicleType, Color, NumberOfDoors, WheelCurrentPressure, WheelMaxPressure, wheelmanufacturer,
            CurrentAmountOfGasoline,
            LicenseType,
            EngineVolume,
            HazardousMaterials
        }

        private static void WheelsArgumentsCollectionCreator(ArgumentsCollection i_ArgumentsCollection, int i_NumberOfWheels)
        {
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                i_ArgumentsCollection.AddArgument(eArgumentKeys.wheelmanufacturer, i, new ArgumentWrapper(
                    "Tire manufacturerer", null, false, typeof(string)));
                i_ArgumentsCollection.AddArgument(eArgumentKeys.WheelMaxPressure, i, new ArgumentWrapper(
                    "Tire max air pressure", null, false, typeof(string)));
                i_ArgumentsCollection.AddArgument(eArgumentKeys.WheelCurrentPressure, i, new ArgumentWrapper(
                    "Tire current air pressure", null, false, typeof(string)));
            }
        }

        private static void VehicleArgumentsCollection(
            ArgumentsCollection i_ArgumentsCollection)
        {
            i_ArgumentsCollection.AddArgument(eArgumentKeys.LicensePlate, new ArgumentWrapper(
                "License plate", null, false, typeof(string)));
            i_ArgumentsCollection.AddArgument(eArgumentKeys.Model, new ArgumentWrapper(
                "Model", null, false, typeof(string)));
            i_ArgumentsCollection.AddArgument(eArgumentKeys.NumberOfDoors, new ArgumentWrapper(
                "Number of doors", Enum.GetNames(typeof(eNumberOfCarDoors)), true, typeof(eNumberOfCarDoors)));

        }

        private static void CarArgumentsCollection(
           ArgumentsCollection i_ArgumentsCollection)
        {
            WheelsArgumentsCollectionCreator(i_ArgumentsCollection, Car.k_NumberOfWheels);
            i_ArgumentsCollection.AddArgument(eArgumentKeys.Color, new ArgumentWrapper(
                "Exterior color", Enum.GetNames(typeof(eCarColors)), true, typeof(string)));
            i_ArgumentsCollection.AddArgument(eArgumentKeys.NumberOfDoors, new ArgumentWrapper(
                "Number of doors", Enum.GetNames(typeof(eNumberOfCarDoors)), true, typeof(string)));
        }

        private static void MotorcycleArgumentsCollection(
            ArgumentsCollection i_ArgumentsCollection)
        {
            WheelsArgumentsCollectionCreator(i_ArgumentsCollection, Motorcycle.k_NumberOfWheels);
            i_ArgumentsCollection.AddArgument(eArgumentKeys.LicenseType, new ArgumentWrapper(
                "License type", Enum.GetNames(typeof(Motorcycle.eLicenseType)), true, typeof(Motorcycle.eLicenseType)));
            i_ArgumentsCollection.AddArgument(eArgumentKeys.EngineVolume, new ArgumentWrapper(
                "Engine volume in cubic centimeter", null, true, typeof(float)));
        }

        private static void TruckArgumentsCollection(
            ArgumentsCollection i_ArgumentsCollection)
        {
            WheelsArgumentsCollectionCreator(i_ArgumentsCollection, Truck.k_NumberOfWheels);
            i_ArgumentsCollection.AddArgument(eArgumentKeys.HazardousMaterials, new ArgumentWrapper(
                "Contains hazardous materials", new [] {"True","False"}, true, typeof(Motorcycle.eLicenseType)));
            i_ArgumentsCollection.AddArgument(eArgumentKeys.EngineVolume, new ArgumentWrapper(
                "Engine volume in cubic centimeter", null, true, typeof(float)));
        }

        private static void GasVehicleArgumentsCollection(
             ArgumentsCollection i_ArgumentsCollection)
        {
            i_ArgumentsCollection.AddArgument(VehicleFactory.eArgumentKeys.CurrentAmountOfGasoline, new ArgumentWrapper<int>("Current amount of fuel in liters", null, false));
        }

        private static void ElectricVehicleArgumentsCollection(
            ArgumentsCollection i_ArgumentsCollection)
        {
            i_ArgumentsCollection.AddArgument(VehicleFactory.eArgumentKeys.CurrentAmountOfGasoline, new ArgumentWrapper(
                "Current amount of hours remaining in battery", null, false, typeof(int)));
        }

        internal static ArgumentsUtils.ArgumentsCollection GetGasolineCarArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            VehicleArgumentsCollection(argumentsCollection);
            GasVehicleArgumentsCollection(argumentsCollection);
            CarArgumentsCollection(argumentsCollection);
            return argumentsCollection;
        }

        internal static ArgumentsUtils.ArgumentsCollection GetElectricCarArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            VehicleArgumentsCollection(argumentsCollection);
            ElectricVehicleArgumentsCollection(argumentsCollection);
            CarArgumentsCollection(argumentsCollection);
            return argumentsCollection;
        }

        internal static ArgumentsUtils.ArgumentsCollection GetGasolineMotorcycleArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            VehicleArgumentsCollection(argumentsCollection);
            GasVehicleArgumentsCollection(argumentsCollection);
            MotorcycleArgumentsCollection(argumentsCollection);
            return argumentsCollection;
        }

        internal static ArgumentsUtils.ArgumentsCollection GetElectricMotorcycleArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            VehicleArgumentsCollection(argumentsCollection);
            ElectricVehicleArgumentsCollection(argumentsCollection);
            MotorcycleArgumentsCollection(argumentsCollection);
            return argumentsCollection;
        }

        internal static ArgumentsUtils.ArgumentsCollection GetElectricTruckArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            VehicleArgumentsCollection(argumentsCollection);
            ElectricVehicleArgumentsCollection(argumentsCollection);
            TruckArgumentsCollection(argumentsCollection);
            return argumentsCollection;
        }

        internal static ArgumentsUtils.ArgumentsCollection GetGasolineTruckArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            VehicleArgumentsCollection(argumentsCollection);
            GasVehicleArgumentsCollection(argumentsCollection);
            TruckArgumentsCollection(argumentsCollection);
            return argumentsCollection;
        }



        private static Car CreateCar(ArgumentsCollection i_Arguments, IMotor i_Motor)
        {
            string licensePlate = (string)i_Arguments[eArgumentKeys.LicensePlate].Response;
            string model = (string)i_Arguments[eArgumentKeys.Model].Response;
            eNumberOfCarDoors numberOfDoors = (eNumberOfCarDoors)i_Arguments[eArgumentKeys.NumberOfDoors].Response;
            eCarColors carColors = (eCarColors)i_Arguments[eArgumentKeys.Color].Response;
            return new Car(licensePlate,model,i_Motor,carColors,numberOfDoors);
        }


  


        internal static Vehicle GetGasolineCar(ArgumentsCollection i_Arguments)
        {
            
            return CreateCar(i_Arguments,));
        }

        internal static Vehicle GetElectricCar()
        {

            return new Car();
        }

        internal static Vehicle GetGasolineMotorcycle()
        {

            return  new Motorcycle();
        }

        internal static Vehicle GetElectricMotorcycle()
        {

            return new Motorcycle();
        }

        internal static Vehicle GetElectricTruck()
        {

            return new Truck();
        }

        internal static Vehicle GetGasolineTruck()
        {

            return new Truck();
        }


        ////private static Dictionary<eArgumentKeys, ArgumentWrapper> argumentDictionary = new Dictionary<eArgumentKeys, ArgumentWrapper>
        ////                                                                                  {
        ////                                                                                      {eArgumentKeys.LicensePlate,
        ////                                                                                          new ArgumentWrapper("license plate",
        ////                                                                                              null,
        ////                                                                                              false,
        ////                                                                                              typeof(string),
        ////                                                                                              null,
        ////                                                                                              null)},
        ////                                                                                      { }
        ////                                                                                  };
        private static readonly int[] r_CarNumberOfWindows = { 2, 3, 4, 5 };

        internal enum eVehicleType
        {
            Electric,
            Gasoline
        }

        ////internal enum eNumberOfCarDoors
        ////{
        ////    Two = 2, Three, Four, Five
        ////}

        internal enum eSupportedVehicles
        {
            GasolineCar = 1,
            ElectricCar,
            GasolineMotorcycle,
            ElectricMotorcycle,
            Truck,
            GasolineTruck,
            ElectricTruck
        }

        internal static Vehicle BuildCar(
            eVehicleType i_VehicleType,
            eCarColors i_Color,
            eNumberOfCarDoors i_NumberOfDoors)
        {
            switch (i_VehicleType)
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


        internal static Vehicle BuildVehicle(
            eSupportedVehicles i_SupportedVehicle,
            ArgumentsCollection i_ArgumentsCollection)
        {
            Vehicle vehicle;
            switch (i_SupportedVehicle)
            {
                case eSupportedVehicles.ElectricCar:
                    {
                        
                        break;
                    }

                case eSupportedVehicles.GasolineCar:
                    {
                        
                        break;
                    }
                case eSupportedVehicles.ElectricMotorcycle:
                    {

                        break;
                    }
                case eSupportedVehicles.GasolineMotorcycle:
                    {

                        break;
                    }
                case eSupportedVehicles.GasolineTruck:
                    {

                        break;
                    }
                case eSupportedVehicles.ElectricTruck:
                    {

                        break;
                    }
                default:
                    {

                        break;
                    }
            }

            return vehicle;
        }

    }
}
