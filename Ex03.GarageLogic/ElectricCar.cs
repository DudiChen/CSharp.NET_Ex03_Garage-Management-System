using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        public ElectricCar(string i_Model, string i_LicensePlateNumber, eCarColor i_CarColor, ushort i_NumberOfDoors, Motor i_Motor) : base(i_Model, i_LicensePlateNumber,i_CarColor, i_NumberOfDoors, i_Motor)
        {

        }

        protected override Motor CreateMotor()
        {
            throw new NotImplementedException();
        }
    }
}
