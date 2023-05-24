﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MinValue;
        private readonly float r_MaxValue;

        public ValueOutOfRangeException(float i_SentValue, float i_MinValue, float i_MaxValue)
            : base(string.Format("Invalid value: {0}. The value has to be in range: {1}-{2}",
                i_SentValue, i_MinValue, i_MaxValue))
        {
            r_MinValue = i_MinValue;
            r_MaxValue = i_MaxValue;
        }

        public ValueOutOfRangeException(float i_SentValue, float i_MinValue)
            : base(string.Format("Invalid value: {0}. The value has to be larger than {1}",
                i_SentValue, i_MinValue))
        {
            r_MinValue = i_MinValue;
        }

        public float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }
    }
}
