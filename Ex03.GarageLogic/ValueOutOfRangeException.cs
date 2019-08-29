using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Exceptions
{
    class ValueOutOfRangeException : Exception
    {
        float m_MaxValue;
        float m_MinValue;
    }
}
