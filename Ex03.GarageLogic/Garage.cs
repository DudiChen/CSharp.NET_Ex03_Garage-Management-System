using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Ex03.GarageLogic.ArgumentsUtils;
using eSupportedVehicles = Ex03.GarageLogic.VehicleFactory.eSupportedVehicles;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, GarageTicket> m_GarageTickets;
        private Dictionary<string, Vehicle> m_vehicleInventory;

        public enum eTicketStatus
        {
            InProgress, Ready, Paid
        }

        public Garage()
        {
            m_GarageTickets = new Dictionary<string, GarageTicket>();
            m_vehicleInventory = new Dictionary<string, Vehicle>();

        }
        internal void AddTicket(string i_VehicleLicenseNumber, GarageTicket i_GarageTicket)
        {
            if (!m_GarageTickets.ContainsKey(i_VehicleLicenseNumber))
            {
                m_GarageTickets.Add(i_VehicleLicenseNumber, i_GarageTicket);
            }
            else
            {
                m_GarageTickets[i_VehicleLicenseNumber].TicketStatus = eTicketStatus.InProgress;
            }
        }

        public bool ChangeVehicleStatus(string i_LicensePlateNumber, string i_StatusString)
        {
            eTicketStatus vehicleStatus = parseVehicleStatusFromString(i_StatusString);
            bool isStatusChangeRequired = false;
            eTicketStatus currentVehicleStatus = m_GarageTickets[i_LicensePlateNumber].TicketStatus;
            if (vehicleStatus != currentVehicleStatus)
            {
                m_GarageTickets[i_LicensePlateNumber].TicketStatus = vehicleStatus;
                isStatusChangeRequired = true;
            }

            return isStatusChangeRequired;
        }

        public bool HasVehicleVisited(string i_VehicleLicenseNumber)
        {
            return m_GarageTickets.ContainsKey(i_VehicleLicenseNumber);
        }

        internal List<GarageTicket> GetTicketListByStatus(eTicketStatus i_TicketStatus)
        {
            List<GarageTicket> garageTickets = new List<GarageTicket>();

            foreach (GarageTicket ticket in m_GarageTickets.Values)
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
            return new List<GarageTicket>(m_GarageTickets.Values);
        }

        internal GarageTicket getTicketByLicensePlateNumber(string i_VehicleLicenseNumber)
        {
            return m_GarageTickets[i_VehicleLicenseNumber];
        }

        public void AddVehicleToGarage(ArgumentsCollection i_Arguments, string i_VehicleTypeString, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            eSupportedVehicles vehicleType = parseVehicleTypeFromString(i_VehicleTypeString);
            Vehicle newVehicle = VehicleFactory.BuildVehicle(vehicleType, i_Arguments);

            m_vehicleInventory.Add(newVehicle.LicensePlateNumber, newVehicle);
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
            return Enum.GetNames(typeof(VehicleFactory.eEnergyTypes));
        }

        public List<string> GetListOfLicensePlateNumbers(string i_VehicleStatusString)
        {
            eTicketStatus vehicleStatus = parseVehicleStatusFromString(i_VehicleStatusString);
            List<string> licensePlateNumberList = new List<string>();
            foreach (GarageTicket ticket in m_GarageTickets.Values)
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
            return new List<string>(m_GarageTickets.Keys);
        }

        public string GetVehicleInfoByLicensePlateNumber(string i_LicensePlateNumber)
        {
            GarageTicket garageTicket = getTicketByLicensePlateNumber(i_LicensePlateNumber);
            StringBuilder showVehicleInfoStringBuilder = new StringBuilder();
            showVehicleInfoStringBuilder.AppendFormat(
                @"Owner's name: {0}
Owner's phone number: {1}{2}",
                garageTicket.OwnerName,
                garageTicket.OwnerPhoneNumber,
                Environment.NewLine);
            showVehicleInfoStringBuilder.AppendLine(m_vehicleInventory[i_LicensePlateNumber].ToString());
            return showVehicleInfoStringBuilder.ToString();
        }

        public void InflateWheelsToMaximum(string i_LicensePlateNumber)
        {
            Vehicle vehicle = m_vehicleInventory[i_LicensePlateNumber];
            vehicle.InflateWheelsToMaxAirPressure();
        }

        public void FuelGasolineVehicle()
        {

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
                throw new ArgumentException("Error: Received wrong argument value for VehicleType");
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
                throw new ArgumentException("Error: Received wrong argument value for VehicleType");
            }

            return result;
        }

        

        public void FillVehicleEnergyContainer(string i_EnergyType, string i_LicensePlateNumber)
        {
            if (!HasVehicleVisited(i_LicensePlateNumber))
            {
                throw new ArgumentException("Error: Received non-existing vehicle license plate number");
            }
            Vehicle vehicle = m_vehicleInventory[i_LicensePlateNumber];
            vehicle.Energize(parseVehicleTypeFromString());
        }
    }
}
