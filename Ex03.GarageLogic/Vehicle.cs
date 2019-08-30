using System;
using System.Collections.Generic;
using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;
using eMotorType = Ex03.GarageLogic.VehicleFactory.eMotorType;


namespace Ex03.GarageLogic
{
    internal abstract class Vehicle : IEnergyManagement
    {
        protected readonly string r_LicensePlateNumber;
        protected readonly string r_Model;
        protected Wheel[] m_Wheels;
        protected Motor m_Motor;


        protected internal Vehicle(Motor i_Motor, Wheel[] i_Wheels, string i_LicensePlateNumber, string i_Model)
        {
            m_Motor = i_Motor;
            m_Wheels = i_Wheels;
            r_LicensePlateNumber = i_LicensePlateNumber;
            r_Model = i_Model;
        }

        internal float CalculateRemainingEnergyPercentage()
        {
            return m_Motor.CalculateRemainingEnergyPercentage();
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

        internal void InflateWheel(uint i_WheelNumber, float i_AirPressureToAdd)
        {
            if (i_WheelNumber <= m_Wheels.Length)
            {
                m_Wheels[(int)i_WheelNumber].Inflate(i_AirPressureToAdd);
            }
            else
            {
                // Throw Exception
            }
        }

        public eMotorType MotorType
        {
            get
            {
                return m_Motor.MotorType;
            }
        }

        public eEnergyTypes[] GetSupportedEnergyTypes()
        {
            return m_Motor.GetSupportedEnergyTypes();
        }

        public float GetMaxEnergyCapacity()
        {
            return m_Motor.GetMaxEnergyCapacity();
        }

        public float GetRemainingEnergyLevel()
        {
            return m_Motor.GetRemainingEnergyLevel();
        }

        public void Energize(eEnergyTypes i_EnergyType, float i_AmountToAdd)
        {
            m_Motor.Energize(i_EnergyType, i_AmountToAdd);
        }

    }
}
