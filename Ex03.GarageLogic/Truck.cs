using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private bool m_HaulingHazardousMaterials;
        private readonly float r_HaulingVolume;

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
