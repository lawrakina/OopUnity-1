using System;
using Healper;
using Interface;
using UnityEngine;


namespace UserInput
{
    public sealed class PCInputHorizontal : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate(float f) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(StringManager.AXIS_HORIZONTAL));
        }
    }
}