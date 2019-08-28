using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private readonly Nullable<float> r_MaxValue;
        private readonly Nullable<float> r_MinValue;
        

        public ValueOutOfRangeException(Nullable<float> i_MaxValue, Nullable<float> i_MinValue)
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public Nullable<float> MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }

        public Nullable<float> MinValue
        {
            get
            {
                return r_MinValue;
            }
        }

        public override string Message
        {
            get
            {
                StringBuilder exceptionMessageStringBuilder = new StringBuilder();
                exceptionMessageStringBuilder.Append("The value was ");
                if(MinValue != null)
                {
                    exceptionMessageStringBuilder.AppendFormat("over the {0} limit ", MaxValue);
                }
                else
                {
                    exceptionMessageStringBuilder.AppendFormat("under the {0} limit ", MinValue);
                }

                return exceptionMessageStringBuilder.ToString();
            }
        }
    }
}
