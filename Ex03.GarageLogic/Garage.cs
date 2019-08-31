using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Ex03.GarageLogic.ArgumentsUtils;
using eSupportedVehicles = Ex03.GarageLogic.VehicleFactory.eSupportedVehicles;
using eEnergyTypes = Ex03.GarageLogic.VehicleFactory.eEnergyTypes;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, GarageTicket> r_GarageTickets;
        private readonly Dictionary<string, Vehicle> r_VehicleInventory;

        public enum eTicketStatus
        {
            InProgress, Ready, Paid
        }

        public Garage()
        {
            r_GarageTickets = new Dictionary<string, GarageTicket>();
            r_VehicleInventory = new Dictionary<string, Vehicle>();

        }
        internal void AddTicket(string i_VehicleLicenseNumber, GarageTicket i_GarageTicket)
        {
            if (!r_GarageTickets.ContainsKey(i_VehicleLicenseNumber))
            {
                r_GarageTickets.Add(i_VehicleLicenseNumber, i_GarageTicket);
            }
            else
            {
                r_GarageTickets[i_VehicleLicenseNumber].TicketStatus = eTicketStatus.InProgress;
            }
        }

        public bool ChangeVehicleStatus(string i_LicensePlateNumber, string i_StatusString)
        {
            eTicketStatus vehicleStatus = parseVehicleStatusFromString(i_StatusString);
            bool isStatusChangeRequired = false;
            eTicketStatus currentVehicleStatus = r_GarageTickets[i_LicensePlateNumber].TicketStatus;
            if (vehicleStatus != currentVehicleStatus)
            {
                r_GarageTickets[i_LicensePlateNumber].TicketStatus = vehicleStatus;
                isStatusChangeRequired = true;
            }

            return isStatusChangeRequired;
        }

        public bool HasVehicleVisited(string i_VehicleLicenseNumber)
        {
            return r_GarageTickets.ContainsKey(i_VehicleLicenseNumber);
        }

        internal List<GarageTicket> GetTicketListByStatus(eTicketStatus i_TicketStatus)
        {
            List<GarageTicket> garageTickets = new List<GarageTicket>();

            foreach (GarageTicket ticket in r_GarageTickets.Values)
            {
                if (ticket.TicketStatus == i_TicketStatus)
                {
                    garageTickets.Add(ticket);
                }
            }

            return garageTickets;
        }

        internal List<GarageTicket> GetTicketList()
        {
            return new List<GarageTicket>(r_GarageTickets.Values);
        }

        internal GarageTicket GetTicketByLicensePlateNumber(string i_VehicleLicenseNumber)
        {
            return r_GarageTickets[i_VehicleLicenseNumber];
        }

        public void AddVehicleToGarage(ArgumentsCollection i_Arguments, string i_VehicleTypeString, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            eSupportedVehicles vehicleType = parseVehicleTypeFromString(i_VehicleTypeString);
            Vehicle newVehicle = VehicleFactory.BuildVehicle(vehicleType, i_Arguments);

            r_VehicleInventory.Add(newVehicle.LicensePlateNumber, newVehicle);
            AddTicket(newVehicle.LicensePlateNumber, new GarageTicket(i_OwnerName, i_OwnerPhoneNumber, newVehicle.LicensePlateNumber));
        }

        public ArgumentsCollection GetArgumentsByVehicleType(string i_VehicleTypeSting)
        {
            eSupportedVehicles vehicleType = parseVehicleTypeFromString(i_VehicleTypeSting);
            return VehicleFactory.GetArgumentsByVehicleType(vehicleType);
        }

        public string[] GetSupportedVehicles()
        {
            return Enum.GetNames(typeof(VehicleFactory.eSupportedVehicles));
        }

        public string[] GetSupportedEnergyTypes()
        {
            return Enum.GetNames(typeof(eEnergyTypes));
        }

        public string[] GetSupportedGasolineTypes()
        {
            return Enum.GetNames(typeof(VehicleFactory.eGasolineTypes));
        }

        public List<string> GetListOfLicensePlateNumbers(string i_VehicleStatusString)
        {
            eTicketStatus vehicleStatus = parseVehicleStatusFromString(i_VehicleStatusString);
            List<string> licensePlateNumberList = new List<string>();
            foreach (GarageTicket ticket in r_GarageTickets.Values)
            {
                if (ticket.TicketStatus == vehicleStatus)
                {
                    licensePlateNumberList.Add(ticket.VehicleLicenseNumber);
                }
            }

            return licensePlateNumberList;
        }

        public List<string> GetListOfLicensePlateNumbers()
        {
            return new List<string>(r_GarageTickets.Keys);
        }

        public string GetVehicleInfoByLicensePlateNumber(string i_LicensePlateNumber)
        {
            GarageTicket garageTicket = GetTicketByLicensePlateNumber(i_LicensePlateNumber);
            StringBuilder showVehicleInfoStringBuilder = new StringBuilder();

            showVehicleInfoStringBuilder.AppendFormat(
                    "\tOwner's name: {0}{3}\tOwner's phone number: {1}{3}\tvehicle status: {2}{3}",
                garageTicket.OwnerName,
                garageTicket.OwnerPhoneNumber,
                garageTicket.TicketStatus.ToString(),
                Environment.NewLine);
            showVehicleInfoStringBuilder.AppendLine(r_VehicleInventory[i_LicensePlateNumber].ToString());
                
            return showVehicleInfoStringBuilder.ToString();
        }

        public void InflateWheelsToMaximum(string i_LicensePlateNumber)
        {
            Vehicle vehicle = r_VehicleInventory[i_LicensePlateNumber];
            vehicle.InflateWheelsToMaxAirPressure();
        }

        public void FuelGasolineVehicle(string i_LicensePlateNumber, string i_GasolineType, float i_AmountToAdd)
        {
            eEnergyTypes gasolineType = parseEnergyTypeFromString(i_GasolineType);
            Vehicle vehicle = r_VehicleInventory[i_LicensePlateNumber];

            vehicle.Energize(gasolineType, i_AmountToAdd);
        }

        public void ChargeElectricVehicle(string i_LicensePlateNumber, float i_ElectricityHoursToAdd)
        {
            Vehicle vehicle = r_VehicleInventory[i_LicensePlateNumber];

            vehicle.Energize(null, i_ElectricityHoursToAdd);
        }

        private eSupportedVehicles parseVehicleTypeFromString(string i_VehicleTypeStr)
        {
            eSupportedVehicles result;
            try
            {
                result = (eSupportedVehicles)Enum.Parse(typeof(eSupportedVehicles), i_VehicleTypeStr);
            }
            catch (Exception e)
            {
                throw new FormatException("Error: Received wrong argument value for VehicleType");
            }

            return result;
        }

        private eEnergyTypes parseEnergyTypeFromString(string i_EnergyTypeStr)
        {
            eEnergyTypes result;
            try
            {

                result = (eEnergyTypes)Enum.Parse(typeof(eEnergyTypes), i_EnergyTypeStr);
            }
            catch (Exception e)
            {
                throw new FormatException("Error: Received wrong argument value for GasolineType");
            }

            return result;
        }

        private eTicketStatus parseVehicleStatusFromString(string i_VehicleStatusString)
        {
            eTicketStatus result;
            try
            {
                result = (eTicketStatus)Enum.Parse(typeof(eTicketStatus), i_VehicleStatusString);
            }
            catch (Exception e)
            {
                throw new FormatException("Error: Received wrong argument value for VehicleType");
            }

            return result;
        }
    }
}
