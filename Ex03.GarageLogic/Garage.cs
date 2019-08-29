using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    // TBD Access Modifiers!
    public class Garage
    { 
        private Dictionary<string, GarageTicket> m_GarageTickets;

        internal void AddTicket(string i_VehicleLicenseNumber, GarageTicket i_GarageTicket)
        {
            if(m_GarageTickets == null)
            {
                m_GarageTickets = new Dictionary<string, GarageTicket>();
            }

            if(!m_GarageTickets.ContainsKey(i_VehicleLicenseNumber))
            {
                m_GarageTickets.Add(i_VehicleLicenseNumber,i_GarageTicket);
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
            foreach(GarageTicket ticket in m_GarageTickets.Values)
            {
                if(ticket.TicketStatus == i_TicketStatus)
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
    }
}
