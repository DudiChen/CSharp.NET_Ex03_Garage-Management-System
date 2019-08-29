namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private readonly string r_Manufacturer;
        private readonly float r_MaxTirePressure;
        private const float k_MinTirePressure = 0.0f;
        private float m_CurrentTirePressure;

        internal Wheel(string i_Manufacturer, float i_MaxTirePressure, float i_CurrentTirePressure)
        {
            r_Manufacturer = i_Manufacturer;
            r_MaxTirePressure = i_MaxTirePressure;
            if(i_CurrentTirePressure >= k_MinTirePressure && i_CurrentTirePressure <= r_MaxTirePressure)
            {
                m_CurrentTirePressure = i_CurrentTirePressure;
            }
            else
            {
                // Throw Exception
            }
            
        }

        internal string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            }
        }

        internal float MaxTirePressure
        {
            get
            {
                return r_MaxTirePressure;
            }
        }

        internal float CurrentTirePressure
        {
            get
            {
                return m_CurrentTirePressure;
            }
        }

        internal void Inflate(float i_AirPressureToAdd)
        {
            if(m_CurrentTirePressure + i_AirPressureToAdd <= r_MaxTirePressure)
            {
                m_CurrentTirePressure += i_AirPressureToAdd;
            }
            else
            {
                // throw exception
            }
        }


    }
}
