using System;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private const float k_MinTirePressure = 0.0f;
        private readonly string r_Manufacturer;
        private readonly float r_MaxTirePressure;
        private float m_CurrentTirePressure;

        internal Wheel(string i_Manufacturer, float i_MaxTirePressure, float i_CurrentTirePressure)
        {
            r_Manufacturer = i_Manufacturer;
            r_MaxTirePressure = i_MaxTirePressure;
            if (i_CurrentTirePressure >= k_MinTirePressure && i_CurrentTirePressure <= r_MaxTirePressure)
            {
                m_CurrentTirePressure = i_CurrentTirePressure;
            }
            else
            {
                // Throw Exception
            }
        }

        internal string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            }
        }

        internal float CurrentTirePressure
        {
            get
            {
                return m_CurrentTirePressure;
            }
        }

        ////internal float MaxTirePressure
        ////{
        ////    get
        ////    {
        ////        return r_MaxTirePressure;
        ////    }
        ////}

        internal void Inflate(float i_AirPressureToAdd)
        {
            if (m_CurrentTirePressure + i_AirPressureToAdd <= r_MaxTirePressure)
            {
                m_CurrentTirePressure += i_AirPressureToAdd;
            }
            else
            {
                // throw exception
            }
        }

        public override string ToString()
        {
            return string.Format("Manufacturer name: {0}   Current tire pressure: {1}", r_Manufacturer, m_CurrentTirePressure);
        }
    }
}
