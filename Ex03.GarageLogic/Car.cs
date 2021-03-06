﻿using System;
using System.Collections.Generic;
using System.Text;
using eCarColors = Ex03.GarageLogic.VehicleFactory.eCarColors;
using eNumberOfCarDoors = Ex03.GarageLogic.VehicleFactory.eNumberOfCarDoors;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private readonly eCarColors r_carColor;
        private readonly eNumberOfCarDoors r_NumberOfDoors;
        internal const int k_NumberOfWheels = 4;

        protected internal Car(
            Motor i_Motor,
            Wheel[] i_Wheels,
            float i_MaxWheelPressure,
            string i_LicensePlateNumber,
            string i_Model,
            eCarColors i_CarColor,
            eNumberOfCarDoors i_NumberOfDoors)
        : base(i_Motor, i_Wheels, i_MaxWheelPressure, i_LicensePlateNumber, i_Model)
        {
            r_carColor = i_CarColor;
            r_NumberOfDoors = i_NumberOfDoors;
        }

        internal eCarColors Color
        {
            get
            {
                return r_carColor;
            }
        }

        internal eNumberOfCarDoors NumberOfDoors
        {
            get
            {
                return r_NumberOfDoors;
            }
        }

        public override string ToString()
        {
            StringBuilder carDisplayString = new StringBuilder();
            carDisplayString.AppendLine(this.ToStringVehicle());
            carDisplayString.AppendFormat(
                "\tExterior color: {0}{2}\tNumber of doors: {1}",
                r_carColor,
                r_NumberOfDoors,
                Environment.NewLine);
            return carDisplayString.ToString();
        }
    }
}
