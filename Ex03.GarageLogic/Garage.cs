using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ex03.GarageLogic.ArgumentsUtils;

namespace Ex03.GarageLogic
{
    // TBD Access Modifiers!
    public class Garage
    {
        private Dictionary<string, GarageTicket> m_GarageTickets;
        private Dictionary<string, Vehicle> m_vehicleInventory;

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
                m_GarageTickets[i_VehicleLicenseNumber].TicketStatus = GarageTicket.eTicketStatus.InProgress;
            }
        }

        internal bool HasVisited(string i_VehicleLicenseNumber)
        {
            return m_GarageTickets.ContainsKey(i_VehicleLicenseNumber);
        }

        internal List<GarageTicket> GetTicketListByStatus(GarageTicket.eTicketStatus i_TicketStatus)
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

        internal List<GarageTicket> GetTicket()
        {
            return new List<GarageTicket>(m_GarageTickets.Values);
        }

        internal GarageTicket getTicket(string i_VehicleLicenseNumber)
        {
            return m_GarageTickets[i_VehicleLicenseNumber];
        }

        public void AddVehicleToGarage(ArgumentsCollection i_Arguments, VehicleFactory.eSupportedVehicles supportedVehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            Vehicle newVehicle = VehicleFactory.BuildVehicle(supportedVehicle, i_Arguments);

            if (m_vehicleInventory == null)
            {
                m_vehicleInventory = new Dictionary<string, Vehicle>();
            }

            m_vehicleInventory.Add(newVehicle.LicensePlateNumber, newVehicle);
            AddTicket(newVehicle.LicensePlateNumber, new GarageTicket(i_OwnerName, i_OwnerPhoneNumber, newVehicle.LicensePlateNumber));
        }

        public string[] GetSupportedVehicles()
        {
            return Enum.GetNames(typeof(VehicleFactory.eSupportedVehicles));
        }

        public List<string> GetVehiclesLicensePlates(GarageTicket.eTicketStatus i_TicketStatus)
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

        public List<string> GetVehiclesLicensePlates()
        {
            return new List<string>(m_GarageTickets.Keys);
        }

        public string ShowVehicleByLicensePlateNumber(string i_LicensePlateNumber)
        {
            return m_vehicleInventory[i_LicensePlateNumber].ToString();
        }
    }
}
