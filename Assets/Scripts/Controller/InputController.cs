using Data;
using Interface;
using UnityEngine;


namespace Controller
{
    public sealed class InputController : IUpdated
    {
        #region Fields

        private readonly InputStruct _inputVector;

        #endregion

        
        #region ctor

        public InputController(InputStruct inputVector)
        {
            _inputVector = inputVector;
        }

        #endregion
        
        
        #region IUdpatable

        public void UpdateTick()
        {
            // _inputVector = new Vector3(
            //     UltimateJoystick.GetHorizontalAxis("Movement"),
            //     0.0f,
            //     UltimateJoystick.GetVerticalAxis("Movement"));
             _inputVector.InputVector = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }

        #endregion
    }
}