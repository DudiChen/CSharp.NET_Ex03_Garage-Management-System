﻿using System;
using System.Collections.Generic;
using eCarColors = Ex03.GarageLogic.VehicleFactory.eCarColors;
using eNumberOfCarDoors = Ex03.GarageLogic.VehicleFactory.eNumberOfCarDoors;
using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;

namespace Ex03.GarageLogic
{
    internal class Car: Vehicle
    {
        
        private readonly eCarColors r_carColor;
        private readonly eNumberOfCarDoors r_NumberOfDoors;
        internal const int k_NumberOfWheels = 4;
        internal const float k_MaxGasTank = 5.5f;
        

        protected internal Car(
            Motor i_Motor,
            Wheel[] i_Wheels,
            string i_LicensePlateNumber,
            string i_Model,
            eCarColors i_CarColor,
            eNumberOfCarDoors i_NumberOfDoors)
        : base(i_Motor, i_Wheels, i_LicensePlateNumber, i_Model)
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

        //internal override void Energize(eEnergyTypes i_EnergyType, float i_AmountToAdd)
        //{
        //    m_Motor.Energize(i_EnergyType, i_AmountToAdd);
        //}


    }
}
