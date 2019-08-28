using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Battery
    {
        private readonly float m_MaximumWorkingHours;
        private float m_RemainingWorkingHours;

        public Battery(float i_MaximumWorkingHours)
        {
            m_MaximumWorkingHours = i_MaximumWorkingHours;
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
            if (m_RemainingWorkingHours + i_HoursToAdd > m_MaximumWorkingHours)
            {
                throw new ValueOutOfRangeException();
            }
            else
            {
                m_RemainingWorkingHours += i_HoursToAdd;
            }
        }

    }
}
