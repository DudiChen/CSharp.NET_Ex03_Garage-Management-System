using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Ex03.GarageLogic.ArgumentsUtils;

namespace Ex03.GarageLogic
{
    internal static class VehicleFactory
    {
        private static readonly int[] sr_CarNumberOfWindows = { 2, 3, 4, 5 };

        public enum eSupportedVehicles
        {
            GasolineCar = 1,
            ElectricCar,
            GasolineMotorcycle,
            ElectricMotorcycle,
            Truck,
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
            LicensePlate,
            Model,
            VehicleType,
            Color,
            NumberOfDoors,
            WheelCurrentPressure,
            WheelMaxPressure,
            WheelManufacturer,
            CurrentAmountOfGasoline,
            LicenseType,
            EngineVolume,
            HazardousMaterials,
            HaulVolume,
            CurrentAmountOfEnergy,
            OwnerName,
            OwnerPhoneNumber
        }

        private static readonly Dictionary<eSupportedVehicles, eEnergyTypes[]> sr_EnergyTypesDictionary = new Dictionary<eSupportedVehicles, eEnergyTypes[]>()
        {
            { eSupportedVehicles.ElectricCar, new eEnergyTypes[] { eEnergyTypes.Electricity } },
            { eSupportedVehicles.ElectricMotorcycle, new eEnergyTypes[] { eEnergyTypes.Electricity } },
            { eSupportedVehicles.GasolineCar, new eEnergyTypes[] { eEnergyTypes.Octan95 } },
            { eSupportedVehicles.GasolineMotorcycle, new eEnergyTypes[] { eEnergyTypes.Octan96 } },
            { eSupportedVehicles.GasolineTruck, new eEnergyTypes[] { eEnergyTypes.Soler } },
            { eSupportedVehicles.ElectricTruck, new eEnergyTypes[] { eEnergyTypes.Electricity } }
        };

        private static void WheelsArgumentsCollectionCreator(ArgumentsCollection i_ArgumentsCollection, int i_NumberOfWheels)
        {
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                i_ArgumentsCollection.AddArgument(
                    eArgumentKeys.WheelManufacturer,
                    i,
                    new ArgumentWrapper("Tire manufacturerer", null, false, typeof(string)));
                i_ArgumentsCollection.AddArgument(
                    eArgumentKeys.WheelMaxPressure,
                    i,
                    new ArgumentWrapper("Tire max air pressure", null, false, typeof(float)));
                i_ArgumentsCollection.AddArgument(
                    eArgumentKeys.WheelCurrentPressure,
                    i,
                    new ArgumentWrapper(
                    "Tire current air pressure", null, false, typeof(float)));
            }
        }

        private static void TicketArgumentsCollection(
            ArgumentsCollection i_ArgumentsCollection)
        {
            i_ArgumentsCollection.AddArgument(
                eArgumentKeys.OwnerName,
                new ArgumentWrapper("Owner's name", null, false, typeof(string)));
            i_ArgumentsCollection.AddArgument(
                eArgumentKeys.OwnerPhoneNumber,
                new ArgumentWrapper("Owner's phone number", null, false, typeof(string)));
        }

        private static void vehicleArgumentsCollection(
            ArgumentsCollection i_ArgumentsCollection)
        {
            i_ArgumentsCollection.AddArgument(
                eArgumentKeys.LicensePlate,
                new ArgumentWrapper("License plate number", null, false, typeof(string)));
            i_ArgumentsCollection.AddArgument(
                eArgumentKeys.Model,
                new ArgumentWrapper("Model", null, false, typeof(string)));
            
        }

        private static void CarArgumentsCollection(
           ArgumentsCollection i_ArgumentsCollection)
        {
            WheelsArgumentsCollectionCreator(i_ArgumentsCollection, Car.k_NumberOfWheels);
            i_ArgumentsCollection.AddArgument(
                eArgumentKeys.Color,
                new ArgumentWrapper("Exterior color", Enum.GetNames(typeof(eCarColors)), true, typeof(string)));
            i_ArgumentsCollection.AddArgument(
                eArgumentKeys.NumberOfDoors,
                new ArgumentWrapper("Number of doors", Enum.GetNames(typeof(eNumberOfCarDoors)), true, typeof(string)));
        }

        private static void MotorcycleArgumentsCollection(
            ArgumentsCollection i_ArgumentsCollection)
        {
            WheelsArgumentsCollectionCreator(i_ArgumentsCollection, Motorcycle.k_NumberOfWheels);
            i_ArgumentsCollection.AddArgument(
                eArgumentKeys.LicenseType,
                new ArgumentWrapper("License type", Enum.GetNames(typeof(Motorcycle.eLicenseType)), true, typeof(Motorcycle.eLicenseType)));
            i_ArgumentsCollection.AddArgument(
                eArgumentKeys.EngineVolume,
                new ArgumentWrapper("Engine volume in cubic centimeter", null, true, typeof(float)));
        }

        private static void TruckArgumentsCollection(
            ArgumentsCollection i_ArgumentsCollection)
        {
            WheelsArgumentsCollectionCreator(i_ArgumentsCollection, Truck.k_NumberOfWheels);
            i_ArgumentsCollection.AddArgument(
                eArgumentKeys.HazardousMaterials,
                new ArgumentWrapper("Contains hazardous materials", new[] { "True", "False" }, true, typeof(Motorcycle.eLicenseType)));
            i_ArgumentsCollection.AddArgument(
                eArgumentKeys.HaulVolume,
                new ArgumentWrapper("Container volume in cubic centimeter", null, true, typeof(float)));
        }

        private static void GasVehicleArgumentsCollection(
             ArgumentsCollection i_ArgumentsCollection)
        {
            i_ArgumentsCollection.AddArgument(
                VehicleFactory.eArgumentKeys.CurrentAmountOfGasoline,
                new ArgumentWrapper("Current amount of fuel in liters", null, false, typeof(float)));
        }

        private static void ElectricVehicleArgumentsCollection(
            ArgumentsCollection i_ArgumentsCollection)
        {
            i_ArgumentsCollection.AddArgument(
                VehicleFactory.eArgumentKeys.CurrentAmountOfEnergy,
                new ArgumentWrapper("Current amount of hours remaining in battery", null, false, typeof(int)));
        }
        
        internal static ArgumentsUtils.ArgumentsCollection GetGasolineCarArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            vehicleArgumentsCollection(argumentsCollection);
            GasVehicleArgumentsCollection(argumentsCollection);
            CarArgumentsCollection(argumentsCollection);

            return argumentsCollection;
        }

        internal static ArgumentsUtils.ArgumentsCollection GetElectricCarArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            vehicleArgumentsCollection(argumentsCollection);
            ElectricVehicleArgumentsCollection(argumentsCollection);
            CarArgumentsCollection(argumentsCollection);

            return argumentsCollection;
        }

        internal static ArgumentsUtils.ArgumentsCollection GetGasolineMotorcycleArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            vehicleArgumentsCollection(argumentsCollection);
            GasVehicleArgumentsCollection(argumentsCollection);
            MotorcycleArgumentsCollection(argumentsCollection);

            return argumentsCollection;
        }

        internal static ArgumentsUtils.ArgumentsCollection GetElectricMotorcycleArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            vehicleArgumentsCollection(argumentsCollection);
            ElectricVehicleArgumentsCollection(argumentsCollection);
            MotorcycleArgumentsCollection(argumentsCollection);

            return argumentsCollection;
        }

        internal static ArgumentsUtils.ArgumentsCollection GetElectricTruckArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            vehicleArgumentsCollection(argumentsCollection);
            ElectricVehicleArgumentsCollection(argumentsCollection);
            TruckArgumentsCollection(argumentsCollection);

            return argumentsCollection;
        }

        internal static ArgumentsUtils.ArgumentsCollection GetGasolineTruckArguments()
        {
            ArgumentsUtils.ArgumentsCollection argumentsCollection = new ArgumentsCollection();
            vehicleArgumentsCollection(argumentsCollection);
            GasVehicleArgumentsCollection(argumentsCollection);
            TruckArgumentsCollection(argumentsCollection);

            return argumentsCollection;
        }

        private static Wheel[] wheelsCollectionBuilder(ArgumentsCollection i_ArgumentsCollection, int i_NumberOfWheels)
        {
            Wheel[] wheels = new Wheel[i_NumberOfWheels];

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                string wheelManufacturer = (string)i_ArgumentsCollection[string.Format(
                    "{0}{1}",
                    eArgumentKeys.WheelManufacturer.ToString(),
                    i).ToString()].Response;
                float wheelMaxWheelPressure = (float)i_ArgumentsCollection[string.Format(
                    "{0}{1}",
                    eArgumentKeys.WheelMaxPressure.ToString(),
                    i).ToString()].Response;
                float wheelWheelPressure = (float)i_ArgumentsCollection[string.Format(
                    "{0}{1}",
                    eArgumentKeys.WheelCurrentPressure.ToString(),
                    i).ToString()].Response;
                wheels[i] = new Wheel(wheelManufacturer, wheelMaxWheelPressure, wheelWheelPressure);
            }

            return wheels;
        }

        private static Car createCar(ArgumentsCollection i_Arguments, Motor i_Motor)
        {
            string licensePlate = (string)i_Arguments[eArgumentKeys.LicensePlate].Response;
            string model = (string)i_Arguments[eArgumentKeys.Model].Response;
            eNumberOfCarDoors numberOfDoors = (eNumberOfCarDoors)i_Arguments[eArgumentKeys.NumberOfDoors].Response;
            eCarColors carColor = (eCarColors)i_Arguments[eArgumentKeys.Color].Response;
            Wheel[] wheels = wheelsCollectionBuilder(i_Arguments, Car.k_NumberOfWheels);

            return new Car(i_Motor, wheels, licensePlate, model, carColor, numberOfDoors);
        }

        private static Truck createTruck(ArgumentsCollection i_Arguments, Motor i_Motor)
        {
            string licensePlate = (string)i_Arguments[eArgumentKeys.LicensePlate].Response;
            string model = (string)i_Arguments[eArgumentKeys.Model].Response;
            bool isCarryingHazardousMaterials = (bool)i_Arguments[eArgumentKeys.HazardousMaterials].Response;
            int haulingVolume = (int)i_Arguments[eArgumentKeys.HaulVolume].Response;
            Wheel[] wheels = wheelsCollectionBuilder(i_Arguments, Motorcycle.k_NumberOfWheels);

            return new Truck(i_Motor, wheels, licensePlate, model, isCarryingHazardousMaterials, haulingVolume);
        }

        private static Motorcycle createMotorcycle(ArgumentsCollection i_Arguments, Motor i_Motor)
        {
            string licensePlate = (string)i_Arguments[eArgumentKeys.LicensePlate].Response;
            string model = (string)i_Arguments[eArgumentKeys.Model].Response;
            Motorcycle.eLicenseType licenseType = (Motorcycle.eLicenseType)i_Arguments[eArgumentKeys.LicenseType].Response;
            int engineVolume = (int)i_Arguments[eArgumentKeys.EngineVolume].Response;
            Wheel[] wheels = wheelsCollectionBuilder(i_Arguments, Motorcycle.k_NumberOfWheels);

            return new Motorcycle(i_Motor, wheels, licensePlate, model, licenseType, engineVolume);
        }

        private static Motor getElectricMotor(ArgumentsCollection i_Arguments)
        {
            float currentAmountOfBattery = (float)i_Arguments[eArgumentKeys.CurrentAmountOfEnergy].Response;
            Battery battery = new Battery(sr_EnergyTypesDictionary[eSupportedVehicles.GasolineCar], Car.k_MaxGasTank, currentAmountOfBattery);

            return new Motor(battery, eMotorType.Electric);
        }

        private static Motor getGasolineMotor(ArgumentsCollection i_Arguments)
        {
            float currentAmountOfGasoline = (float)i_Arguments[eArgumentKeys.CurrentAmountOfGasoline].Response;
            GasolineTank gasolineTank = new GasolineTank(sr_EnergyTypesDictionary[eSupportedVehicles.GasolineCar], Car.k_MaxGasTank, currentAmountOfGasoline);

            return new Motor(gasolineTank, eMotorType.Gasoline);
        }

        internal static Vehicle GetGasolineCar(ArgumentsCollection i_Arguments)
        {
            return createCar(i_Arguments, getGasolineMotor(i_Arguments));
        }

        internal static Vehicle GetElectricCar(ArgumentsCollection i_Arguments)
        {
            return createCar(i_Arguments, getElectricMotor(i_Arguments));
        }

        internal static Vehicle GetGasolineMotorcycle(ArgumentsCollection i_Arguments)
        {
            return createMotorcycle(i_Arguments, getGasolineMotor(i_Arguments));
        }

        internal static Vehicle GetElectricMotorcycle(ArgumentsCollection i_Arguments)
        {
            return createMotorcycle(i_Arguments, getElectricMotor(i_Arguments));
        }

        internal static Vehicle GetElectricTruck(ArgumentsCollection i_Arguments)
        {
            return createTruck(i_Arguments, getElectricMotor(i_Arguments));
        }

        internal static Vehicle GetGasolineTruck(ArgumentsCollection i_Arguments)
        {
            return createTruck(i_Arguments, getGasolineMotor(i_Arguments));
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
                        vehicle = GetElectricCar(i_ArgumentsCollection);
                        break;
                    }

                case eSupportedVehicles.GasolineCar:
                    {
                        vehicle = GetGasolineCar(i_ArgumentsCollection);
                        break;
                    }

                case eSupportedVehicles.ElectricMotorcycle:
                    {
                        vehicle = GetElectricMotorcycle(i_ArgumentsCollection);
                        break;
                    }

                case eSupportedVehicles.GasolineMotorcycle:
                    {
                        vehicle = GetGasolineMotorcycle(i_ArgumentsCollection);
                        break;
                    }

                case eSupportedVehicles.GasolineTruck:
                    {
                        vehicle = GetGasolineTruck(i_ArgumentsCollection);
                        break;
                    }

                case eSupportedVehicles.ElectricTruck:
                    {
                        vehicle = GetElectricTruck(i_ArgumentsCollection);
                        break;
                    }

                default:
                    {
                        vehicle = null;
                        break;
                    }
            }

            return vehicle;
        }

        internal static ArgumentsCollection GetArgumentsByVehicleType(
            eSupportedVehicles i_SupportedVehicle)
        {
            ArgumentsCollection vehicleArgumentsCollection;

            switch (i_SupportedVehicle)
            {
                case eSupportedVehicles.ElectricCar:
                    {
                        vehicleArgumentsCollection = GetElectricCarArguments();
                        break;
                    }

                case eSupportedVehicles.GasolineCar:
                    {
                        vehicleArgumentsCollection = GetGasolineCarArguments();
                        break;
                    }

                case eSupportedVehicles.ElectricMotorcycle:
                    {
                        vehicleArgumentsCollection = GetElectricMotorcycleArguments();
                        break;
                    }

                case eSupportedVehicles.GasolineMotorcycle:
                    {
                        vehicleArgumentsCollection = GetGasolineMotorcycleArguments();
                        break;
                    }

                case eSupportedVehicles.GasolineTruck:
                    {
                        vehicleArgumentsCollection = GetGasolineTruckArguments();
                        break;
                    }

                case eSupportedVehicles.ElectricTruck:
                    {
                        vehicleArgumentsCollection = GetElectricTruckArguments();
                        break;
                    }

                default:
                    {
                        vehicleArgumentsCollection = null;
                        break;
                    }
            }

            return vehicleArgumentsCollection;
        }
    }
}
