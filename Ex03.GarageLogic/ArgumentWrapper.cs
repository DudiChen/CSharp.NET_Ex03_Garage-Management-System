using System;
using System.CodeDom;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class ArgumentWrapper
    {
        private readonly string r_DisplayName;
        private readonly string[] r_optionalValueStrings;
        private readonly bool r_isStrictToOptionalValues;
        private readonly Type r_ValidationType;
        private object m_InputValue;

        internal ArgumentWrapper(
            string i_DisplayName,
            string[] i_OptionalValueStrings,
            bool i_IsStrictToOptionalValues,
            Type i_ParameterValidationType)
        {
            r_DisplayName = i_DisplayName;
            r_optionalValueStrings = i_OptionalValueStrings;
            r_isStrictToOptionalValues = i_IsStrictToOptionalValues;
            r_ValidationType = i_ParameterValidationType;
            m_InputValue = null;
        }

        public string DisplayName
        {
            get
            {
                return r_DisplayName;
            }
        }

        public string[] OptionalValues
        {
            get
            {
                return r_optionalValueStrings;
            }
        }

        public bool IsStrictToOptionalValues
        {
            get
            {
                return r_isStrictToOptionalValues;
            }
        }

        public Type ResponseType
        {
            get
            {
                return r_ValidationType;
            }
        }

        public void InjectValue(string i_InputString)
        {
            if (r_ValidationType == typeof(int))
            {
                m_InputValue = int.Parse(i_InputString);
            }
            else if (r_ValidationType == typeof(float))
            {
                m_InputValue = float.Parse(i_InputString);
            }
            else if (r_ValidationType == typeof(bool))
            {
                int choiceInt = int.Parse(i_InputString);
                m_InputValue = bool.Parse(OptionalValues[choiceInt]);
            }
            else if (r_ValidationType.IsEnum)
            {
                m_InputValue = Enum.Parse(r_ValidationType, i_InputString);
            }
            else
            {
                m_InputValue = i_InputString;
            }
        }

        public object Response
        {
            get
            {
                return m_InputValue;
            }
        }
    }
}
