using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private readonly string r_Manufacturer;
        private readonly float r_MaxWheelPressure;
        private float m_CurrentWheelPressure;

        internal Wheel(string i_Manufacturer, float i_MaxWheelPressure, float i_CurrentWheelPressure)
        {
            r_Manufacturer = i_Manufacturer;
            r_MaxWheelPressure = i_MaxWheelPressure;
            m_CurrentWheelPressure = 0;
            Inflate(i_CurrentWheelPressure);
        }

        internal string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            }
        }

        internal float CurrentWheelPressure
        {
            get
            {
                return m_CurrentWheelPressure;
            }
        }

        internal void Inflate(float i_AirPressureToAdd)
        {
            if (m_CurrentWheelPressure + i_AirPressureToAdd > r_MaxWheelPressure || i_AirPressureToAdd < 0)
            {
                string message;
                if(i_AirPressureToAdd < 0)
                {
                    message = string.Format(
                        "Additional air pressure amount received was '{0}' : Value cannot be negative");
                }
                else 
                {
                    message = string.Format(
                        "The received air pressure amount of '{0}' exceeds the max allowed value of '{1}'",
                        i_AirPressureToAdd,
                        r_MaxWheelPressure);
                }

                throw new ValueOutOfRangeException(r_MaxWheelPressure, 0, message);
            }
            else
            {
                m_CurrentWheelPressure += i_AirPressureToAdd;
            }
        }

        public override string ToString()
        {
            return string.Format("Manufacturer name: {0}   Current Wheel pressure: {1}", r_Manufacturer, m_CurrentWheelPressure);
        }
    }
}
