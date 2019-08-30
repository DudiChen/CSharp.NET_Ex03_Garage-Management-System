using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Ex03.GarageLogic.ArgumentsUtils;
//using eCarColors = Ex03.GarageLogic.eVehicleFactory.eCarColors;

//using eNumberOfCarDoors = Ex03.GarageLogic.Car.eNumberOfCarDoors;

namespace Ex03.GarageLogic
{


    public static class VehicleFactory
    {
        internal enum eSupportedVehicles
        {
            GasolineCar = 1, ElectricCar, GasolineMotorcycle, ElectricMotorcycle, Truck,
            GasolineTruck,
            ElectricTruck
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
        internal enum eArgumentKeys
        {
            LicensePlate, Model, VehicleType, Color, NumberOfDoors, WheelCurrentPressure, WheelMaxPressure, wheelmanufacturer,
            CurrentAmountOfGasoline,
            LicenseType,
            EngineVolume,
            HazardousMaterials,
            HaulVolume
        }
        private static  Dictionary<eSupportedVehicles,eEnergyTypes[]> EnergyTypesDictionary = new Dictionary<eSupportedVehicles, eEnergyTypes[]>()
        {
            {eSupportedVehicles.ElectricCar, new eEnergyTypes[] { eEnergyTypes.Electricity } },
            {eSupportedVehicles.ElectricMotorcycle,new eEnergyTypes[] {eEnergyTypes.Electricity} },
            {eSupportedVehicles.GasolineCar,new eEnergyTypes[] {eEnergyTypes.Octan95} },
            {eSupportedVehicles.GasolineMotorcycle,new eEnergyTypes[] {eEnergyTypes.Octan96} },
            {eSupportedVehicles.GasolineTruck,new eEnergyTypes[] {eEnergyTypes.Soler} },
            {eSupportedVehicles.ElectricTruck,new eEnergyTypes[] {eEnergyTypes.Electricity} }
        };

        private static void WheelsArgumentsCollectionCreator(ArgumentsCollection i_ArgumentsCollection, int i_NumberOfWheels)
        {
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                i_ArgumentsCollection.AddArgument(eArgumentKeys.wheelmanufacturer, i, new ArgumentWrapper(
                    "Tire manufacturerer", null, false, typeof(string)));
                i_ArgumentsCollection.AddArgument(eArgumentKeys.WheelMaxPressure, i, new ArgumentWrapper(
                    "Tire max air pressure", null, false, typeof(float)));
                i_ArgumentsCollection.AddArgument(eArgumentKeys.WheelCurrentPressure, i, new ArgumentWrapper(
                    "Tire current air pressure", null, false, typeof(float)));
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
            i_ArgumentsCollection.AddArgument(eArgumentKeys.HaulVolume, new ArgumentWrapper(
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

        private static Wheel[] WheelsCollectionBuilder(ArgumentsCollection i_ArgumentsCollection, int i_NumberOfWheels)
        {
            Wheel[] wheels = new Wheel[i_NumberOfWheels];
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                string wheelManufacturer = (string)i_ArgumentsCollection[string.Format(
                    "{0}{1}",
                    eArgumentKeys.wheelmanufacturer.ToString(),
                    i).ToString()].Response;
                float wheelMaxWheelPressure = (float)i_ArgumentsCollection[string.Format(
                    "{0}{1}",
                    eArgumentKeys.WheelMaxPressure.ToString(),
                    i).ToString()].Response;
                float wheelWheelPressure = (float)i_ArgumentsCollection[string.Format(
                    "{0}{1}",
                    eArgumentKeys.WheelCurrentPressure.ToString(),
                    i).ToString()].Response;
               wheels[i] = new Wheel(wheelManufacturer,wheelMaxWheelPressure,wheelWheelPressure);
            }

            return wheels;
        }

        private static Car CreateCar(ArgumentsCollection i_Arguments, Motor i_Motor)
        {
            string licensePlate = (string)i_Arguments[eArgumentKeys.LicensePlate].Response;
            string model = (string)i_Arguments[eArgumentKeys.Model].Response;
            eNumberOfCarDoors numberOfDoors = (eNumberOfCarDoors)i_Arguments[eArgumentKeys.NumberOfDoors].Response;
            eCarColors carColor = (eCarColors)i_Arguments[eArgumentKeys.Color].Response;
            Wheel[] wheels = WheelsCollectionBuilder(i_Arguments,Car.k_NumberOfWheels);
            return new Car(i_Motor,wheels,licensePlate,model,carColor,numberOfDoors);
        }


        private static Motorcycle CreateMotorcycle(ArgumentsCollection i_Arguments, Motor i_Motor)
        {
            string licensePlate = (string)i_Arguments[eArgumentKeys.LicensePlate].Response;
            string model = (string)i_Arguments[eArgumentKeys.Model].Response;
            Motorcycle.eLicenseType licenseType = (Motorcycle.eLicenseType)i_Arguments[eArgumentKeys.LicenseType].Response;
            int engineVolume = (int)i_Arguments[eArgumentKeys.EngineVolume].Response;
            Wheel[] wheels = WheelsCollectionBuilder(i_Arguments, Motorcycle.k_NumberOfWheels);
            return new Motorcycle(i_Motor, wheels, licensePlate, model,licenseType, engineVolume);
        }

        private static Truck CreatTruck(ArgumentsCollection i_Arguments, Motor i_Motor)
        {
            string licensePlate = (string)i_Arguments[eArgumentKeys.LicensePlate].Response;
            string model = (string)i_Arguments[eArgumentKeys.Model].Response;
            bool isCarryingHazardousMaterials = (bool)i_Arguments[eArgumentKeys.HazardousMaterials].Response;
            int haulingVolume = (int)i_Arguments[eArgumentKeys.HaulVolume].Response;
            Wheel[] wheels = WheelsCollectionBuilder(i_Arguments, Motorcycle.k_NumberOfWheels);
            return new Truck(i_Motor, wheels, licensePlate, model, isCarryingHazardousMaterials, haulingVolume);
        }

        internal static Vehicle GetGasolineCar(ArgumentsCollection i_Arguments)
        {
            float currentAmountOfGasoline = (float)i_Arguments[eArgumentKeys.CurrentAmountOfGasoline].Response;
            GasolineTank gasolineTank = new GasolineTank(EnergyTypesDictionary[eSupportedVehicles.GasolineCar],Car.k_MaxGasTank,currentAmountOfGasoline);
            Motor motor = new Motor(gasolineTank,eMotorType.Gasoline);
            return CreateCar(i_Arguments,motor);
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

        internal static Vehicle BuildCar(
            eSupportedVehicles i_VehicleType,
            eCarColors i_Color,
            eNumberOfCarDoors i_NumberOfDoors)
        {
            switch (i_VehicleType)
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
                        vehicle = GetGasolineCar(i_ArgumentsCollection);
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
