using System;

using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    internal class Battery
    {
        private readonly float r_MaximumWorkingHours;
        private float m_RemainingWorkingHours;

        public Battery(float i_MaximumWorkingHours)
        {
            r_MaximumWorkingHours = i_MaximumWorkingHours;
            m_RemainingWorkingHours = 0;
        }

        public float RemainingWorkingHours
        {
            get
            {
                return m_RemainingWorkingHours;
            }
        }

        public void Charge(float i_HoursToAdd)
        {
            if (m_RemainingWorkingHours + i_HoursToAdd <= r_MaximumWorkingHours)
            {
                m_RemainingWorkingHours += i_HoursToAdd;
            }
            else
            {
                throw new BatteryMaxWorkingHoursException(r_MaximumWorkingHours, m_RemainingWorkingHours, i_HoursToAdd);
            }
        }

    }
}
