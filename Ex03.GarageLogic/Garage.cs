using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ex03.GarageLogic.ArgumentsUtils;
using eSupportedVehicles = Ex03.GarageLogic.VehicleFactory.eSupportedVehicles;

namespace Ex03.GarageLogic
{
    // TBD Access Modifiers!
    public class Garage
    {
        private Dictionary<string, GarageTicket> m_GarageTickets;
        private Dictionary<string, Vehicle> m_vehicleInventory;

        public enum eTicketStatus
        {
            InProgress, Ready, Paid
        }

        internal void AddTicket(string i_VehicleLicenseNumber, GarageTicket i_GarageTicket)
        {
            if (m_GarageTickets == null)
            {
                m_GarageTickets = new Dictionary<string, GarageTicket>();
            }

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

        public void AddVehicleToGarage(ArgumentsCollection i_Arguments, string i_VehicleTypeString, string i_OwnerName,string i_OwnerPhoneNumber)
        {
            eSupportedVehicles vehicleType = parseVehicleTypeFromString(i_VehicleTypeString);
            Vehicle newVehicle = VehicleFactory.BuildVehicle(vehicleType, i_Arguments);
            if (m_vehicleInventory == null)
            {
                m_vehicleInventory = new Dictionary<string, Vehicle>();
            }

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

        public List<string> GetListOfLicensePlateNumbers(eTicketStatus i_TicketStatus)
        {
            List<string> licensePlateNumberList = new List<string>();

            foreach (GarageTicket ticket in m_GarageTickets.Values)
            {
                if (ticket.TicketStatus == i_TicketStatus)
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

        public string ShowVehicleByLicensePlateNumber(string i_LicensePlateNumber)
        {
            return m_vehicleInventory[i_LicensePlateNumber].ToString();
        }

        private eSupportedVehicles parseVehicleTypeFromString(string i_VehicleTypeStr)
        {
            eSupportedVehicles result;
            if (!Enum.TryParse(i_VehicleTypeStr, out result))
            {
                throw new ArgumentException("Error: Received wrong argument value for VehicleType");
            }

            return result;
        }

        private eTicketStatus parseVehicleStatusFromString(string i_VehicleStatusString)
        {
            eTicketStatus result;
            if (!Enum.TryParse(i_VehicleStatusString, out result))
            {
                throw new ArgumentException("Error: Received wrong argument value for VehicleStatus");
            }

            return result;
        }
    }
}
