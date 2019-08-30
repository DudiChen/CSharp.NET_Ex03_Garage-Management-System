using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_HaulingHazardousMaterials;
        private readonly float r_HaulingVolume;

        internal Truck(Motor i_Motor, Wheel[] i_Wheels, string i_Model, string i_LicensePlateNumber,bool i_HaulingHazardousMaterials,float i_HaulingVolume)
            : base(i_Motor,i_Wheels,i_LicensePlateNumber,i_Model)
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
    }
}
