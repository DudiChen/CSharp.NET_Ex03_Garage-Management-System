using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;
using eMotorType = Ex03.GarageLogic.VehicleFactory.eMotorType;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected readonly string r_LicensePlateNumber;
        protected readonly string r_Model;
        protected readonly Wheel[] r_Wheels;
        protected readonly float r_MaxWheelAirPressure;
        protected readonly Motor r_Motor;

        public abstract override string ToString();

        protected internal Vehicle(Motor i_Motor, Wheel[] i_Wheels, float i_MaxWheelAirPressure, string i_LicensePlateNumber, string i_Model)
        {
            r_Motor = i_Motor;
            r_Wheels = i_Wheels;
            r_MaxWheelAirPressure = i_MaxWheelAirPressure;
            r_LicensePlateNumber = i_LicensePlateNumber;
            r_Model = i_Model;
        }

        internal float CalculateRemainingEnergyPercentage()
        {
            return r_Motor.CalculateRemainingEnergyPercentage();
        }

        internal string LicensePlateNumber
        {
            get
            {
                return r_LicensePlateNumber;
            }
        }

        internal string Model
        {
            get
            {
                return r_Model;
            }
        }

        internal int NumberOfWheels
        {
            get
            {
                return r_Wheels.Length;
            }
        }

        internal float MaxWheelAirPressure
        {
            get
            {
                return r_MaxWheelAirPressure;
            }
        }

        internal void InflateWheelsToMaxAirPressure()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                float airPressureAmountToAdd = r_MaxWheelAirPressure - wheel.CurrentWheelPressure;
                wheel.Inflate(airPressureAmountToAdd);
            }
        }

        public eMotorType MotorType
        {
            get
            {
                return r_Motor.MotorType;
            }
        }

        public eEnergyTypes[] GetSupportedEnergyTypes()
        {
            return r_Motor.GetSupportedEnergyTypes();
        }

        public float GetMaxEnergyCapacity()
        {
            return r_Motor.GetMaxEnergyCapacity();
        }

        public float GetRemainingEnergyLevel()
        {
            return r_Motor.GetRemainingEnergyLevel();
        }

        public void Energize(Nullable<eEnergyTypes> i_EnergyType, float i_AmountToAdd)
        {
            bool areValidParams = (i_EnergyType == null && r_Motor.MotorType == eMotorType.Electric) ||
                                  (i_EnergyType != null && r_Motor.MotorType == eMotorType.Gasoline);
            if (areValidParams)
            {
                r_Motor.Energize(i_EnergyType, i_AmountToAdd);
            }
            else
            {
                string exceptionMessage;
                if (i_EnergyType == null && r_Motor.MotorType == eMotorType.Gasoline)
                {
                    exceptionMessage = "Error: Received an EnergyType null value for a Gasoline motor type.";
                }
                else 
                {
                    exceptionMessage = "Error: For Electric motor type expected a EnergyType null value.";
                }

                throw new ArgumentException(exceptionMessage, nameof(i_EnergyType));
            }
        }

        protected string ToStringWheelArray()
        {
            StringBuilder wheelCollectionStringBuilder = new StringBuilder();
            uint wheelRowCounter = 1;
            foreach (Wheel wheel in r_Wheels)
            {
                wheelCollectionStringBuilder.AppendFormat("{2}\t\twheel number {0}: {1}", wheelRowCounter++, wheel.ToString(), Environment.NewLine);
            }

            return wheelCollectionStringBuilder.ToString();
        }

        protected string ToStringVehicle()
        {
            StringBuilder vehicleStringBuilder = new StringBuilder();

            vehicleStringBuilder.AppendFormat(
                "\tLicense plate number: {0}{4}\tModel: {1}{4}{2}{4}\tWheels: {3}",
                r_LicensePlateNumber,
                r_Model,
                r_Motor.ToString(),
                ToStringWheelArray(),
                    Environment.NewLine);

            return vehicleStringBuilder.ToString();
        }
    }
}
