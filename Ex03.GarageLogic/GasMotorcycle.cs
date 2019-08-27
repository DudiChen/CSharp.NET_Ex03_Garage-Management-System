using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasMotorcycle : Motorcycle
    {
        public GasMotorcycle(
            string i_Model,
            string i_LicensePlateNumber,
            eLicenseType i_LicenseType,
            int i_EngineVolume)
            : base(i_Model, i_LicensePlateNumber, i_LicenseType, i_EngineVolume)
        {

        }

        protected override Motor CreateMotor()
        {
            throw new NotImplementedException();
        }
    }
}
