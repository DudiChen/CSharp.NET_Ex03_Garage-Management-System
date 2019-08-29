namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_LicensePlateNumber;
        private readonly string r_Model;
        private float m_EnergyPercentage;
        private Wheel[] m_Wheels;
        private IMotor m_Motor;

        protected Vehicle( string i_LicensePlateNumber, string i_Model,Wheel[] i_Wheels, IMotor i_Motor)
        {
            m_Motor = i_Motor;
            m_EnergyPercentage = 0.0f;
            r_Model = i_Model;
            r_LicensePlateNumber = i_LicensePlateNumber;
            
        }
    }
}
