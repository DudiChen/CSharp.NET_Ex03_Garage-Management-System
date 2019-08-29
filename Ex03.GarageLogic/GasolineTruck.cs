using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasolineTruck : Truck
    {
        public GasolineTruck(
            string i_Model,
            string i_LicensePlateNumber,
            bool i_HaulingHazardousMaterials,
            float i_HaulingVolume)
            : base(i_Model, i_LicensePlateNumber, i_HaulingHazardousMaterials, i_HaulingVolume)
        {

        }

        protected override Motor CreateMotor()
        {
            throw new NotImplementedException();
        }
    }
}
