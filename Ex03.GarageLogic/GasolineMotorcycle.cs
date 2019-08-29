using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasolineMotorcycle : Motorcycle
    {
        public GasolineMotorcycle(
            string i_Model,
            string i_LicensePlateNumber,
            eLicenseType i_LicenseType,
            int i_EngineVolume)
            : base(i_Model, i_LicensePlateNumber, i_LicenseType, i_EngineVolume)
        {

        }

      
    }
}
