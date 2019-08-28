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
        private readonly string r_ExceptionMessage;

        public ValueOutOfRangeException(Nullable<float> i_MaxValue, Nullable<float> i_MinValue) : base()
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
            r_ExceptionMessage = messageBuilder(r_MaxValue, r_MinValue);

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
                return r_ExceptionMessage;
            }
        }

        private string messageBuilder(Nullable<float> i_MaxValue, Nullable<float> i_MinValue)
        {
            StringBuilder exceptionMessageStringBuilder = new StringBuilder();
            exceptionMessageStringBuilder.Append("The value was ");
            if (i_MinValue != null)
            {
                exceptionMessageStringBuilder.AppendFormat("over the limit ");
            }
            else
            {
                if(i_MaxValue != null)
                {
                    exceptionMessageStringBuilder.AppendFormat("under the limit ");
                }
                else
                {
                    exceptionMessageStringBuilder.Append("out Of Range");
                }
            }
            
            return exceptionMessageStringBuilder.ToString();
        }
    }
}
