using System;

namespace Ex03.GarageLogic.Exceptions
{
    class BatteryMaxWorkingHoursException : Exception
    {
        private readonly float r_MaximumWorkingHours;
        private readonly float r_RemainingWorkingHours;
        private readonly float r_HoursToAdd;

        public BatteryMaxWorkingHoursException(
            float i_MaximumWorkingHours,
            float i_RemainingWorkingHours,
            float i_HoursToAdd)
            : base(
                string.Format("Error: Adding {0} of Working-Hours yields {1} which exceeds the Max Working-Hours of {2}",
                    i_HoursToAdd, i_RemainingWorkingHours + i_HoursToAdd, i_MaximumWorkingHours))
        {
            r_MaximumWorkingHours = i_MaximumWorkingHours;
            r_RemainingWorkingHours = i_RemainingWorkingHours;
            r_HoursToAdd = i_HoursToAdd;
        }

        public BatteryMaxWorkingHoursException(
            Exception i_InnerException,
            float i_MaximumWorkingHours,
            float i_RemainingWorkingHours,
            float i_HoursToAdd)
            : base(
                string.Format("Error: Adding {0} of Working-Hours yields {1} which exceeds the Max Working-Hours of {2}",
                    i_HoursToAdd, i_RemainingWorkingHours + i_HoursToAdd, i_MaximumWorkingHours),
                i_InnerException)
        {
            r_MaximumWorkingHours = i_MaximumWorkingHours;
            r_RemainingWorkingHours = i_RemainingWorkingHours;
            r_HoursToAdd = i_HoursToAdd;
        }
    }
}
