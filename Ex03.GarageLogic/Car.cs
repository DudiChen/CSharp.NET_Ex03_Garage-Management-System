using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car: Vehicle
    {
        public enum eCarColor
        {
            WHITE, RED, BLACK, YELLOW
        }

        private readonly eCarColor r_carColor;
        private readonly ushort r_NumberOfDoors;

        protected Car(string i_Model, string i_LicensePlateNumber,eCarColor i_CarColor,ushort i_NumberOfDoors,Motor i_Motor) :base(i_Model, i_LicensePlateNumber, i_Motor)
        {
            r_carColor = i_CarColor;
            r_NumberOfDoors = i_NumberOfDoors;

        }

        public eCarColor Color
        {
            get
            {
                return r_carColor;
            }
        }

        public ushort NumberOfDoors
        {
            get
            {
                return r_NumberOfDoors;
            }
        }

    }
}
