using System;
using System.Collections.Generic;
using System.Text;


namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private readonly float r_HaulingVolume;
        public const int k_NumberOfWheels = 16;
        private bool m_HaulingHazardousMaterials;

        internal Truck(Motor i_Motor, Wheel[] i_Wheels, string i_LicensePlateNumber, string i_Model, bool i_HaulingHazardousMaterials, float i_HaulingVolume)
            : base(i_Motor, i_Wheels, i_LicensePlateNumber, i_Model)
        {
            m_HaulingHazardousMaterials = i_HaulingHazardousMaterials;
            r_HaulingVolume = i_HaulingVolume;
        }

        public bool IsHaulingHazardousMaterials
        {
            get
            {
                return m_HaulingHazardousMaterials;
            }

            set
            {
                m_HaulingHazardousMaterials = value;
            }
        }

        public float HaulingVolume
        {
            get
            {
                return r_HaulingVolume;
            }
        }

        public override string ToString()
        {
            StringBuilder carDisplayString = new StringBuilder();
            carDisplayString.AppendLine(this.ToStringVehicle());
            carDisplayString.AppendFormat(
                @"Contains hazardous materials: {0}
Container volume in cubic centimeter: {1}",
                m_HaulingHazardousMaterials.ToString(),
                r_HaulingVolume);

            return carDisplayString.ToString();
        }
    }
}
