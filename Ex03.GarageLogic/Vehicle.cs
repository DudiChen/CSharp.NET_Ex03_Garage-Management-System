﻿using System.Dynamic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_LicensePlateNumber;
        private readonly string r_Model;
        private float m_EnergyPercentage;
        private Wheel[] m_Wheels;
        private Motor m_Motor;

        protected Vehicle(string i_Model, string i_LicensePlateNumber)
        {
            m_EnergyPercentage = 0.0f;
            r_Model = i_Model;
            r_LicensePlateNumber = i_LicensePlateNumber;
            m_Motor = CreateMotor();
        }

        protected abstract Motor CreateMotor();
    }
}